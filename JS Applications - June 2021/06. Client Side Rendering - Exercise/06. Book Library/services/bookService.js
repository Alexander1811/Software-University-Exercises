import { jsonRequest } from "./httpService.js";

let baseUrl = "http://localhost:3030/jsonstore/collections/books";

async function getAllBooks() {
    let result = await jsonRequest(baseUrl);
    return result;
}

async function getBook(id) {
    let result = await jsonRequest(`${baseUrl}/${id}`);
    return result;
}

async function createBook(book) {
    let result = await jsonRequest(baseUrl, "Post", book, true);
    return result;
}

async function updateBook(id, book) {
    let result = await jsonRequest(`${baseUrl}/${id}`, "Put", book, true);
    return result;
}

async function deleteBook(id) {
    let result = await jsonRequest(`${baseUrl}/${id}`, "Delete", undefined, true);
    return result;
}

export default {
    getAllBooks, getBook,
    createBook,
    updateBook,
    deleteBook
}