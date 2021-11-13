import { jsonRequest } from "./httpService.js";

let baseUrl = "http://localhost:3030";

async function createMovie(newMovie) {
    let createResult = await jsonRequest(`${baseUrl}/data/movies`, "Post", newMovie, true);
    return createResult;
}

async function updateMovie(id, editedMovie) {
    let updateResult = await jsonRequest(`${baseUrl}/data/movies/${id}`, "Put", editedMovie, true);
    return updateResult;
}

async function getMovie(movieId) {
    let movie = await jsonRequest(`${baseUrl}/data/movies/${movieId}`);
    return movie;
}

async function getAllMovies() {
    let movies = await jsonRequest(`${baseUrl}/data/movies`);
    return movies;
}

async function deleteMovie(movieId) {
    let deleteResult = await jsonRequest(`${baseUrl}/data/movies/${movieId}`, "Delete", undefined, true);
    return deleteResult;
}

let movieService = {
    createMovie,
    updateMovie,
    getMovie,
    getAllMovies,
    deleteMovie
}

export default movieService;