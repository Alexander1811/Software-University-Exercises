import { myListingsTemplate } from "./myListingsTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _authService = undefined;
let _listingsService = undefined;

function initialize(router, renderer, authService, listingsService) {
    _router = router;
    _renderer = renderer;
    _authService = authService;
    _listingsService = listingsService;
}

async function getView() {
    let user = _authService.getUser();
    let listings = await _listingsService.getMyListings(user._id);
    let templateResult = myListingsTemplate(listings);
    _renderer(templateResult);
}

export default {
    initialize, 
    getView
}