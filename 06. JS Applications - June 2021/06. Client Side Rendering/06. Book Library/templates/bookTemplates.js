import { html } from "./../../node_modules/lit-html/lit-html.js";
import { ifDefined } from "./../../node_modules/lit-html/directives/if-defined.js";

let formTemplate = (form) => html`
<form @submit=${form.submitHandler} class=${ifDefined(form.class)} id=${form.id}>
    ${form.type === 'edit' ? html` <input type="hidden" name="id" value=${form.idValue}>` : ""}
    <h3>${form.title}</h3>
    <label>TITLE</label>
    <input type="text" name="title" placeholder="Title..." value=${ifDefined(form.titleValue)}>
    <label>AUTHOR</label>
    <input type="text" name="author" placeholder="Author..." value=${ifDefined(form.authorValue)}>
    <input type="submit" value=${form.buttonText}>
</form>`;

export let allFormsTemplate = (forms) => html`${forms.map(form => formTemplate(form))}`;

let tableTemplate = (books, editHandler, deleteHandler) => html` 
<table>
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody id="books-container">
        ${allBooksTemplate(books, editHandler, deleteHandler)}
    </tbody>
</table>`;

let bookTemplate = (book, editHandler, deleteHandler) => html`
<tr class="book" data-id=${book._id}>
    <td>${book.title}</td>
    <td>${book.author}</td>
    <td>
        <button class="editBtn" @click=${editHandler}>Edit</button>
        <button class="deleteBtn" @click=${deleteHandler}>Delete</button>
    </td>
</tr>`;

export let allBooksTemplate = (books, editHandler, deleteHandler) => html`${books.map(book => bookTemplate(book, editHandler, deleteHandler))}`;

export let bookLibraryTemplate = (books, forms, loadBooksHandler, editHandler, deleteHandler) => html`
    <button id="loadBooks" @click=${loadBooksHandler}>LOAD ALL BOOKS</button>
    ${tableTemplate(books, editHandler, deleteHandler)}
    <section id="forms-section"> ${allFormsTemplate(forms)}</section>`;