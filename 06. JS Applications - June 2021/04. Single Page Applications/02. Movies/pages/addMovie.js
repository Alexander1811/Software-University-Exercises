import movieService from "../services/movieService.js";
import viewFinder from "../viewFinder.js";

let section = undefined;

function initialize(domElement) {
    section = domElement;
    let form = section.querySelector("#add-form");
    form.addEventListener("submit", addHandler);
}

async function getView() {
    return section;
}

async function addHandler(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let newMovie = {
        title: formData.get("title"),
        description: formData.get("description"),
        img: formData.get("imageUrl"),
    }

    if (newMovie.title == "" || newMovie.description == "" || newMovie.img == "") {
        alert("All fields are required!");
        return false;
    }

    await movieService.createMovie(newMovie);

    form.reset();
    viewFinder.navigateTo("home");
}

let addMoviePage = {
    initialize,
    getView
};

export default addMoviePage;