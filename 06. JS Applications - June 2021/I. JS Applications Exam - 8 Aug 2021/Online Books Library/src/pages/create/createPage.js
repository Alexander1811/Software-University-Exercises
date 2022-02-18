import { createTemplate } from "./createTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _booksService = undefined;

function initialize(router, renderer, booksService) {
    _router = router;
    _renderer = renderer;
    _booksService = booksService;
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
    let book = {
        title: formData.get("title"), 
        description: formData.get("description"), 
        imageUrl: formData.get("imageUrl"), 
        type: formData.get("type")
    }

    if (Object.values(book).some(field => field.trim() == "")) {
        return alert("All fields are required!");
    }

    let createResult = await _booksService.createBook(book);
    _router("/dashboard");

}

export default {
    getView,
    initialize
}