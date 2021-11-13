import domService from "../services/domService.js";
import movieService from "../services/movieService.js";
import viewFinder from "../viewFinder.js";

let section = undefined;
let navLinkClass = undefined;

function initialize(domElement, linkClass) {
    section = domElement;
    navLinkClass = linkClass;
}

async function getView() {
    let movieContainer = section.querySelector("#movie-container");
    movieContainer.querySelectorAll(".movie").forEach(movie => movie.remove());

    let movies = await movieService.getAllMovies();

    movies.map(movie => createMovieDiv(movie)).forEach(movie => movieContainer.appendChild(movie));

    return section;
}

let homePage = {
    initialize,
    getView
};

function createMovieDiv(movie) {
    let movieDiv = domService.createNestedElement("div", { class: "card mb-4 movie" });

    let image = domService.createNestedElement("img", { class: "card-img-top", src: movie.img, alt: "Card image cap", width: 400 });

    let titleDiv = domService.createNestedElement("div", { class: "card-body" });
    let titleHeading = domService.createNestedElement("div", { class: "card-title" }, movie.title);
    titleDiv.appendChild(titleHeading);

    let detailsDiv = domService.createNestedElement("div", { class: "card-footer" });
    let detailsA = domService.createNestedElement("a", { class: `${navLinkClass}`, "data-route": "movie-details", "data-id": movie._id, href: "#/details/6lOxMFSMkML09wux6sAF" });
    let detailsButton = domService.createNestedElement("button", { type: "button", class: "btn btn-info" }, "Details");
    detailsButton.addEventListener("click", viewFinder.changeViewHandler);
    detailsA.appendChild(detailsButton);
    detailsDiv.appendChild(detailsA);

    movieDiv.appendChild(image);
    movieDiv.appendChild(titleDiv);
    movieDiv.appendChild(detailsDiv);

    return movieDiv;
}

export default homePage;