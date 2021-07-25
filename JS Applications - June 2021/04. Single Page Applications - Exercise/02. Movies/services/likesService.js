import { jsonRequest } from "./httpService.js";

let baseUrl = "http://localhost:3030";

async function likeMovie(body) {
    let likeResult = await jsonRequest(`${baseUrl}/data/likes`, "Post", body, true);
    return likeResult;
}

async function getUserLikes(movieId, userId) {
    let userLikesResult = await jsonRequest(`${baseUrl}/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${userId}%22`);
    return userLikesResult;
}

async function getMovieLikes(movieId) {
    let movieLikesResult = await jsonRequest(`${baseUrl}/data/likes?where=movieId%3D%22${movieId}%22&distinct=_ownerId&count`);
    return movieLikesResult;
}

let likesService = {
    likeMovie,
    getUserLikes,
    getMovieLikes
}

export default likesService;