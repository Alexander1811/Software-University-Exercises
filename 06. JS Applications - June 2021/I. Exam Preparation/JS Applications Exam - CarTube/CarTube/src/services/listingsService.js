import { jsonRequest } from "./httpService.js";

let baseUrl = "http://localhost:3030/data/cars";

async function getAllListings() {
    let result = await jsonRequest(`${baseUrl}?sortBy=_createdOn%20desc`);
    return result;
}

async function getListing(id) {
    let result = await jsonRequest(`${baseUrl}/${id}`);
    return result;
}

async function createListing(Listing) {
    let result = await jsonRequest(baseUrl, "Post", Listing, true);
    return result;
}

async function updateListing(id, Listing) {
    let result = await jsonRequest(`${baseUrl}/${id}`, "Put", Listing, true);
    return result;
}

async function deleteListing(id) {
    let result = await jsonRequest(`${baseUrl}/${id}`, "Delete", undefined, true);
    return result;
}

async function getMyListings(userId) {
    let result = await jsonRequest(`${baseUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
    return result;
}

async function getByYear(year) {
    let result = await jsonRequest(`${baseUrl}?where=year%3D${year}`);
    return result;
}

export default {
    getAllListings, getListing,
    createListing,
    updateListing,
    deleteListing,
    getMyListings, getByYear
}