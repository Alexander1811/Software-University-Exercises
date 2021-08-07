import { allListingsTemplate } from "./allListingsTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _listingsService = undefined;

function initialize(router, renderer, listingsService) {
    _router = router;
    _renderer = renderer;
    _listingsService = listingsService;
}

async function getView() {
    let listings = await _listingsService.getAllListings();
    let templateResult = allListingsTemplate(listings);
    _renderer(templateResult);
}

export default {
    initialize,
    getView
}