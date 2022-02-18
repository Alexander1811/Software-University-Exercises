import { jsonRequest } from "./httpService.js";

let baseUrl = "http://localhost:3030/data/books";

async function getAllBooks() {
    let result = await jsonRequest(`${baseUrl}?sortBy=_createdOn%20desc`);
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

async function getMyBooks(userId) {
    let result = await jsonRequest(`${baseUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
    return result;
}

export default {
    getAllBooks, getBook,
    createBook,
    updateBook,
    deleteBook,
    getMyBooks
}