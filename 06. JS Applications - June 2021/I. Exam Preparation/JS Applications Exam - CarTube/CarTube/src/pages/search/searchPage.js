import { searchTemplate } from "./searchTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _listingsService = undefined;

let year = undefined;
let matches = undefined;

function initialize(router, renderer, listingsService) {
    _router = router;
    _renderer = renderer;
    _listingsService = listingsService;
}

async function getView() {
    let matchesArray = matches != undefined ? matches : [];
    let templateResult = searchTemplate(onSearchClick, year, matchesArray);
    _renderer(templateResult);
}

async function onSearchClick(e) {
    year = e.target.parentElement.querySelector("input").value;
    matches = Object.values(await _listingsService.getByYear(year));

    let matchesArray = matches != undefined ? matches : [];
    let templateResult = searchTemplate(onSearchClick, year, matchesArray);
    _renderer(templateResult);
}

export default {
    getView,
    initialize
}