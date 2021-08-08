import { editTemplate } from "./editTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _booksService = undefined;

let bookId = undefined;

function initialize(router, renderer, booksService) {
    _router = router;
    _renderer = renderer;
    _booksService = booksService;
}

async function getView(context) {
    bookId = context.params.id;
    let form = { submitHandler };
    let book = await _booksService.getBook(bookId);
    let templateResult = editTemplate(form, book);
    _renderer(templateResult);
}

async function submitHandler(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let book = {
        title: formData.get("title"), 
        description: formData.get("description"), 
        imageUrl: formData.get("imageUrl"), 
        type: formData.get("type")
    }

    if (Object.values(book).some(field => field.trim() == "")) {
        return alert("All fields are required!");
    }

    let updateResult = await _booksService.updateBook(bookId, book);
    _router(`/details/${bookId}`);
}

export default {
    getView,
    initialize
}