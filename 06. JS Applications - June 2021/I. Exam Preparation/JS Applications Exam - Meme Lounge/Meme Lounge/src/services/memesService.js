import { jsonRequest } from "./httpService.js";

let baseUrl = "http://localhost:3030/data/memes";

async function getAllMemes() {
    let result = await jsonRequest(`${baseUrl}?sortBy=_createdOn%20desc`);
    return result;
}

async function getMeme(id) {
    let result = await jsonRequest(`${baseUrl}/${id}`);
    return result;
}

async function createMeme(meme) {
    let result = await jsonRequest(baseUrl, "Post", meme, true);
    return result;
}

async function updateMeme(id, meme) {
    let result = await jsonRequest(`${baseUrl}/${id}`, "Put", meme, true);
    return result;
}

async function deleteMeme(id) {
    let result = await jsonRequest(`${baseUrl}/${id}`, "Delete", undefined, true);
    return result;
}

async function getMyMemes(userId) {
    let result = await jsonRequest(`${baseUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
    return result;
}

export default {
    getAllMemes, getMeme,
    createMeme,
    updateMeme,
    deleteMeme,
    getMyMemes
}