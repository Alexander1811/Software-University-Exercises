import { jsonRequest } from "./httpService.js";

let baseUrl = "http://localhost:3030/data/likes";

async function getLikes(bookId) {
    let result = await jsonRequest(`${baseUrl}?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`);
    return result;
}

async function hasAlreadyLikedBook(bookId, userId) {
    let result = await jsonRequest(`${baseUrl}?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
    return result == 1 ? true : false;
}

async function likeBook(bookId) {
    let result = await jsonRequest(baseUrl, "Post", {bookId: bookId}, true);
    return result;
}

export default {
    getLikes,
    hasAlreadyLikedBook,
    likeBook
}