import { jsonRequest } from "./httpService.js";
import { encodeQuery } from "./queryEncoder.js";

let baseUrl = "http://localhost:3030/data/members";

async function getAllMembers() {
    let queryObject = {
        where: `status="member"`
    }
    let query = encodeQuery(queryObject);
    let result = await jsonRequest(`${baseUrl}?${query}`);
    return result;
}

async function getPeopleInTeam(teamId) {
    let queryObject = {
        where: `teamId="${teamId}"`,
        load: `user=_ownerId:users`
    }
    let query = encodeQuery(queryObject);
    let result = await jsonRequest(`${baseUrl}?${query}`);
    return result;
}

async function joinTeam(teamId) {
    let result = await jsonRequest(baseUrl, "Post", { teamId: teamId }, true);
    return result;
}

async function approveMember(memberId) {
    let result = await jsonRequest(`${baseUrl}/${memberId}`, "Put", { status: "member" }, true);
    return result;
}

async function cancelRequest(memberId) {
    let result = await jsonRequest(`${baseUrl}/${memberId}`, "Delete", undefined, true);
    return result;
}

async function leaveTeam(memberId) {
    let result = await jsonRequest(`${baseUrl}/${memberId}`, "Delete", undefined, true);
    return result;
}

async function declineRequest(memberId) {
    let result = await jsonRequest(`${baseUrl}/${memberId}`, "Delete", undefined, true);
    return result;
}

async function removeMember(memberId) {
    let result = await jsonRequest(`${baseUrl}/${memberId}`, "Delete", undefined, true);
    return result;
}

export default {
    getAllMembers,
    getPeopleInTeam,
    joinTeam, approveMember, cancelRequest, leaveTeam, declineRequest, removeMember
}