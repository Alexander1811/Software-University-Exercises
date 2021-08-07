import { jsonRequest } from "./httpService.js";

let baseUrl = "http://localhost:3030/data/teams";

async function getAllTeams() {
    let result = await jsonRequest(baseUrl);
    return result;
}

async function getTeam(id) {
    let result = await jsonRequest(`${baseUrl}/${id}`);
    return result;
}

async function createTeam(team) {
    let result = await jsonRequest(baseUrl, "Post", team, true);
    return result;
}

async function updateTeam(id, team) {
    let result = await jsonRequest(`${baseUrl}/${id}`, "Put", team, true);
    return result;
}

async function deleteTeam(id) {
    let result = await jsonRequest(`${baseUrl}/${id}`, "Delete", undefined, true);
    return result;
}

async function getMyTeams(userId) {
    let result = await jsonRequest(`${baseUrl}?where=_ownerId%3D%22${userId}%22`);
    return result;
}

export default {
    getAllTeams, getTeam,
    createTeam,
    updateTeam,
    deleteTeam,
    getMyTeams
}