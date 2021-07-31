import { render } from "./../node_modules/lit-html/lit-html.js";
import bookService from "./services/bookService.js";
import { allBooksTemplate, allFormsTemplate, bookLibraryTemplate } from "./templates/bookTemplates.js";

let body = document.body;
let addForm = {
    id: "add-form",
    type: "add",
    title: "Add Book",
    buttonText: "Submit",
    submitHandler: createBookHandler,
}
let editForm = {
    id: "edit-form",
    type: "edit",
    title: "Edit Book",
    buttonText: "Save",
    submitHandler: editBookHandler,
    class: "hidden",
    idValue: "",
    authorValue: "",
    titleValue: ""
}

let forms = [addForm, editForm];
let books = [];
renderPage();

async function loadBooksHandler() {
    let bookObj = Object.entries(await bookService.getAllBooks());
    books = bookObj.map(([key, value]) => {
        return {
            _id: key,
            title: value.title,
            author: value.author
        }
    });

    reloadBooksTable();
}

async function createBookHandler(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let newBook = {
        author: formData.get("author"),
        title: formData.get("title")
    }

    if (Object.values(newBook).some(field => field.trim() == "")) {
        return alert("All fields are required!");
    }

    let createResult = await bookService.createBook(newBook);
    books.push(createResult);

    form.reset();
    reloadBooksTable();
}

async function editBookHandler(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let id = formData.get("id");
    let editedBook = {
        _id: id,
        author: formData.get("author"),
        title: formData.get("title")
    }

    if (Object.values(editedBook).some(field => field.trim() == "")) {
        return alert("All fields are required!");
    }
    
    let editResult = await bookService.updateBook(id, editedBook);
    books = books.filter(x => x._id !== id);
    books.push(editResult);
    
    form.reset();
    addForm.class = "undefined";
    editForm.class = "hidden";
    changeForms();
    reloadBooksTable();
}

async function deleteBookHandler(e) {
    let id = e.target.closest(".book").dataset.id;
    await bookService.deleteBook(id);
    books = books.filter(x => x._id !== id);
    
    addForm.class = "undefined";
    editForm.class = "hidden";
    changeForms();
    reloadBooksTable();
}

async function prepareEdit(e) {
    let currentBook = e.target.closest(".book");
    let id = currentBook.dataset.id;
    let book = await bookService.getBook(id);

    addForm.class = "hidden";
    editForm.class = "undefined";
    editForm.idValue = id;
    editForm.authorValue = book.author;
    editForm.titleValue = book.title;

    changeForms();
}

function renderPage() {
    render(bookLibraryTemplate(books, forms, loadBooksHandler, editBookHandler, deleteBookHandler), body);
}

function reloadBooksTable() {
    let booksContainer = document.querySelector("#books-container");
    render(allBooksTemplate(books, prepareEdit, deleteBookHandler), booksContainer);
}

function changeForms() {
    let formsSection = document.querySelector("#forms-section");
    render(allFormsTemplate(forms), formsSection)
}
