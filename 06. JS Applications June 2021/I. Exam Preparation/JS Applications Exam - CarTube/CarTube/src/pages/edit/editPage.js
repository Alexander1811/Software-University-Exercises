import { editTemplate } from "./editTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _listingsService = undefined;

let listingId = undefined;

function initialize(router, renderer, listingsService) {
    _router = router;
    _renderer = renderer;
    _listingsService = listingsService;
}

async function getView(context) {
    listingId = context.params.id;
    let form = { submitHandler };
    let listing = await _listingsService.getListing(listingId);
    let templateResult = editTemplate(form, listing);
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

    let updateResult = await _listingsService.updateListing(listingId, listing);
    _router(`/details/${listingId}`);
}

export default {
    getView,
    initialize
}