import movieService from "../services/movieService.js";
import viewFinder from "../viewFinder.js";

let section = undefined;

function initialize(domElement) {
    section = domElement;
    let form = section.querySelector("#edit-form");
    form.addEventListener("submit", editHandler);
}

async function getView(id) {
    let movieDetails = await movieService.getMovie(id);

    let titleInput = section.querySelector("input[name=\"title\"]");
    let descriptionInput = section.querySelector("textarea[name=\"description\"]");
    let imageUrlInput = section.querySelector("input[name=\"imageUrl\"]");

    let form = section.querySelector("#edit-form");
    form.dataset.id = id;

    titleInput.value = movieDetails.title;
    descriptionInput.textContent = movieDetails.description;
    imageUrlInput.value = movieDetails.img;

    return section;
}

async function editHandler(e) {
    e.preventDefault();

    let form = e.target;
    let id = form.dataset.id;
    let formData = new FormData(form);
    let editedMovie = {
        title: formData.get("title"),
        description: formData.get("description"),
        img: formData.get("imageUrl"),
    }

    await movieService.updateMovie(id, editedMovie);

    form.reset();
    viewFinder.navigateTo("movie-details", id);
}

let editMoviePage = {
    initialize,
    getView
};

export default editMoviePage;