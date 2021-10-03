import { jsonRequest } from "./httpService.js";

let baseUrl = "http://localhost:3030/data/catalog";

async function getAllItems() {
    let result = await jsonRequest(baseUrl);
    return result;
}

async function getItem(id) {
    let result = await jsonRequest(`${baseUrl}/${id}`);
    return result;
}

async function createItem(item) {
    let result = await jsonRequest(baseUrl, "Post", item, true);
    return result;
}

async function updateItem(id, item) {
    let result = await jsonRequest(`${baseUrl}/${id}`, "Put", item, true);
    return result;
}

async function deleteItem(id) {
    let result = await jsonRequest(`${baseUrl}/${id}`, "Delete", undefined, true);
    return result;
}

async function getMyFurniture(userId) {
    let result = await jsonRequest(`${baseUrl}?where=_ownerId%3D%22${userId}%22`);
    return result;
}

export default {
    getAllItems, getItem,
    createItem,
    updateItem,
    deleteItem,
    getMyFurniture
}