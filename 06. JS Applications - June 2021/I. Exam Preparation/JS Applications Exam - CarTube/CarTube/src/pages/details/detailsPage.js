import { detailsTemplate } from "./detailsTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _authService = undefined;
let _listingsService = undefined;

let listingId = undefined;
let userId = undefined;

function initialize(router, renderer, authService, listingsService) {
    _router = router;
    _renderer = renderer;
    _authService = authService;
    _listingsService = listingsService;
}

async function getView(context) {
    listingId = context.params.id;
    let listing = await _listingsService.getListing(listingId);
    let ownerId = listing._ownerId;
    let user = await _authService.getUser();
    if (user != undefined) {
        userId = user._id;
    }
    let isOwner = ownerId == userId;
    let buttons = { deleteHandler };
    let templateResult = detailsTemplate(listing, isOwner, buttons);
    _renderer(templateResult);
}

async function deleteHandler() {
    if (confirm("Are you sure you want to delete this listing?")) {
        let deleteResult = await _listingsService.deleteListing(listingId);
        _router("/all-listings")
    }
}

export default {
    initialize,
    getView
}