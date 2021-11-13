import { createTemplate } from "./createTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _listingsService = undefined;

function initialize(router, renderer, listingsService) {
    _router = router;
    _renderer = renderer;
    _listingsService = listingsService;
}

async function getView() {
    let form = { submitHandler };
    let templateResult = createTemplate(form);
    _renderer(templateResult);
}

async function submitHandler(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let listing = {
        brand: formData.get("brand"),
        model: formData.get("model"),
        year: Number(formData.get("year")),
        description: formData.get("description"),
        imageUrl: formData.get("imageUrl"),
        price: Number(formData.get("price"))
    }

    if (Object.values(listing).some(field => field == "" || field == 0)) {
        return alert("All fields are required!");
    }

    let createResult = await _listingsService.createListing(listing);
    _router("/all-listings");
}

export default {
    getView,
    initialize
}