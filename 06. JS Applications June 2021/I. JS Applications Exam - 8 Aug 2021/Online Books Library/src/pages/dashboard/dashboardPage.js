import { dashboardTemplate } from "./dashboardTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _booksService = undefined;

function initialize(router, renderer, booksService) {
    _router = router;
    _renderer = renderer;
    _booksService = booksService;
}

async function getView() {
    let books = await _booksService.getAllBooks();
    let templateResult = dashboardTemplate(books);
    _renderer(templateResult);
}

export default {
    initialize,
    getView
}