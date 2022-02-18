import { myBooksTemplate } from "./myBooksTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _authService = undefined;
let _booksService = undefined;

function initialize(router, renderer, authService, booksService) {
    _router = router;
    _renderer = renderer;
    _authService = authService;
    _booksService = booksService;
}

async function getView() {
    let user = _authService.getUser();
    let books = await _booksService.getMyBooks(user._id);
    let templateResult = myBooksTemplate(books);
    _renderer(templateResult);
}

export default {
    initialize, 
    getView
}