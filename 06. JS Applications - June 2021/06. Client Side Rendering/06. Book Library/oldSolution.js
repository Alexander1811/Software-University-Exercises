let booksTableBody = document.querySelector("#books-table tbody");
booksTableBody.querySelectorAll("tr").forEach(tr => tr.remove());
booksTableBody.addEventListener("click", changeBookHandler);

let loadBooksButton = document.querySelector("#loadBooks");
loadBooksButton.addEventListener("click", loadBooksHandler);

let createForm = document.querySelector("#createForm");
createForm.addEventListener("submit", createBookHandler);

let editForm = document.querySelector("#editForm");
editForm.addEventListener("submit", editBookHandler);

let url = "http://localhost:3030/jsonstore/collections/books";

async function loadBooksHandler() {
    booksTableBody.querySelectorAll("tr").forEach(tr => tr.remove());

    let booksRequest = await fetch(url);
    let books = await booksRequest.json();

    Object.keys(books).forEach(id => {
        let book = books[id];
        let bookTr = createBookTr(book, id);

        booksTableBody.appendChild(bookTr);
    });
}

async function createBookHandler(e) {
    e.preventDefault();

    let formData = new FormData(e.target);
    let newBook = {
        author: formData.get("author"),
        title: formData.get("title")
    }

    if (validateInput(newBook.author, newBook.title)) {
        return alert("All fields are required!");
    }

    let createResponse = await fetch(url, {
        headers: { "Content-Type": "application/json" },
        method: "Post",
        body: JSON.stringify(newBook)
    });

    if (!createResponse.ok) {
        return alert("Cannot add book!");
    }

    let createResult = await createResponse.json();
    let createdBook = createBookTr(createResult);
    booksTableBody.appendChild(createdBook);
}

function changeBookHandler(e) {
    if (e.target.className == "editBtn") {
        changeFormsAndClearInput(createForm);

        let bookTr = e.target.parentElement.parentElement;
        let id = bookTr.dataset.id;

        loadBookForEditting(id);
    }
    else if (e.target.className == "deleteBtn") {
        if (confirm("Are you sure you want to delete this book?")) {

            deleteBookHandler(e);
        }
    }
}

async function editBookHandler(e) {
    e.preventDefault();

    let formData = new FormData(e.target);
    let id = formData.get("bookId");
    let newBook = {
        author: formData.get("author"),
        title: formData.get("title")
    }

    if (validateInput(newBook.author, newBook.title)) {
        return alert("All fields are required!");
    }

    let editResponse = await fetch(`${url}/${id}`, {
        headers: { "Content-Type": "application/json" },
        method: "Put",
        body: JSON.stringify(newBook)
    });

    if (!editResponse.ok) {
        return alert("Cannot edit book!");
    }

    let editResult = await editResponse.json();
    let editedBook = createBookTr(editResult, editResult._id);
    let editedBookTr = booksTableBody.querySelector(`tr.book[data-id="${id}"]`);
    editedBookTr.replaceWith(editedBook);

    changeFormsAndClearInput(editForm);
}

async function deleteBookHandler(e) {
    let deletedBookTr = e.target.closest('.book');
    let id = deletedBookTr.dataset.id;

    let deleteResponse = await fetch(`${url}/${id}`, {
        headers: { "Content-type": "application/json" },
        method: "Delete"
    });

    if (!deleteResponse.ok) {
        return alert("Cannot delete book!");
    }

    deletedBookTr.remove();
}

async function loadBookForEditting(id) {
    let bookRequest = await fetch(`${url}/${id}`);
    let book = await bookRequest.json();

    editForm.querySelector("[name=\"bookId\"]").value = id;
    editForm.querySelector("[name=\"title\"]").value = book.title;
    editForm.querySelector("[name=\"author\"]").value = book.author;
}

function createBookTr(book, id) {
    let bookTr = document.createElement("tr");
    bookTr.dataset.id = id;
    bookTr.classList.add("book");

    let titleTd = document.createElement("td");
    titleTd.textContent = book.title;
    titleTd.classList.add("title");

    let authorTd = document.createElement("td");
    authorTd.textContent = book.author;
    authorTd.classList.add("author");

    let buttonsTd = document.createElement("td");

    let editButton = document.createElement("button");
    editButton.textContent = "Edit";
    editButton.classList.add("editBtn");

    let deleteButton = document.createElement("button");
    deleteButton.textContent = "Delete";
    deleteButton.classList.add("deleteBtn");

    buttonsTd.appendChild(editButton);
    buttonsTd.appendChild(deleteButton);

    bookTr.appendChild(titleTd);
    bookTr.appendChild(authorTd);
    bookTr.appendChild(buttonsTd);

    return bookTr;
}//done

function changeFormsAndClearInput(formType) {
    let formId = formType.id;

    if (formId == "createForm") {
        createForm.style.display = "none";
        editForm.style.display = "block";
    }
    else if (formId == "editForm") {
        createForm.style.display = "block";
        editForm.style.display = "none";
        createForm.querySelector("[name=\"title\"]").value = "";
        createForm.querySelector("[name=\"author\"]").value = "";
        editForm.querySelector("[name=\"bookId\"]").value = "";
    }
}

function validateInput(author, title) {
    return author.trim() == "" || title.trim() == "";
}