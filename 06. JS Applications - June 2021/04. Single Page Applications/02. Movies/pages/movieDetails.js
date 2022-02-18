import auth from "../services/authService.js";
import domService from "../services/domService.js";
import likesService from "../services/likesService.js";
import movieService from "../services/movieService.js";
import viewFinder from "../viewFinder.js";

let section = undefined;
let navLinkClass = undefined;

function initialize(domElement, linkClass) {
    section = domElement;
    navLinkClass = linkClass;
}

async function getView(movieId) {
    let movieDetailsContainer = section.querySelector("#movie-details-container");
    [...movieDetailsContainer.children].forEach(movie => movie.remove());

    let userId = auth.getUserId();

    let movieDetails = await movieService.getMovie(movieId);
    let userLikesArray = await likesService.getUserLikes(movieId, userId);
    let movieLikes = await likesService.getMovieLikes(movieId);

    let movieDetailsHTML = createMovieDetailsDiv(movieDetails, userLikesArray.length > 0, movieLikes);

    movieDetailsContainer.appendChild(movieDetailsHTML);

    return section;
}

async function likeMovie(movieId) {
    await likesService.likeMovie({ movieId: movieId })

    return viewFinder.redirectTo("movie-details", movieId);
}

async function deleteMovie(movieId) {
    await movieService.deleteMovie(movieId);

    return viewFinder.redirectTo("home", movieId);
}

function createMovieDetailsDiv(movieDetails, hasLiked, likes) {
    let movieDetailsDiv = domService.createNestedElement("div", { class: "row bg-light text-dark" });

    let titleHeading = domService.createNestedElement("h1", undefined, `Movie title: ${movieDetails.title}`);

    let imageDiv = domService.createNestedElement("div", { class: "col-md-8" });
    let image = domService.createNestedElement("img", { class: "img-thumbnail", src: movieDetails.img, alt: "Movie" });
    imageDiv.appendChild(image);

    let descriptionDiv = domService.createNestedElement("div", { class: "col-md-4 text-center" });
    let descriptionHeading = domService.createNestedElement("h3", { class: "my-3" }, "Movie Description");
    let descriptionP = domService.createNestedElement("p", undefined, movieDetails.description);
    descriptionDiv.appendChild(descriptionHeading);
    descriptionDiv.appendChild(descriptionP);

    let deleteButton = domService.createNestedElement("a", { class: `btn btn-danger ${navLinkClass}`, "data-route": "delete", "data-id": movieDetails._id, href: "#" }, "Delete");
    deleteButton.addEventListener("click", viewFinder.changeViewHandler);
    let editButton = domService.createNestedElement("a", { class: `btn btn-warning ${navLinkClass}`, "data-route": "edit", "data-id": movieDetails._id, href: "#" }, "Edit");
    editButton.addEventListener("click", viewFinder.changeViewHandler);
    let likeButton = domService.createNestedElement("a", { class: `btn btn-primary ${navLinkClass}`, "data-route": "like", "data-id": movieDetails._id, href: "#" }, "Like");
    likeButton.addEventListener("click", viewFinder.changeViewHandler);

    let isOwner = auth.getUserId() == movieDetails._ownerId;
    let isRegistered = auth.getToken() != null;
    if (isOwner) {
        descriptionDiv.appendChild(deleteButton);
        descriptionDiv.appendChild(editButton);
    }
    if (!hasLiked && !isOwner && isRegistered) {
        descriptionDiv.appendChild(likeButton);
    }

    if (hasLiked || isOwner || !isRegistered) {
        let likeSpan = domService.createNestedElement("span", { class: "enrolled-span" }, `Liked: ${likes}`);
        descriptionDiv.appendChild(likeSpan);
    }

    movieDetailsDiv.appendChild(titleHeading);
    movieDetailsDiv.appendChild(imageDiv);
    movieDetailsDiv.appendChild(descriptionDiv);

    return movieDetailsDiv;
}

let movieDetailsPage = {
    initialize,
    getView,
    likeMovie,
    deleteMovie
};

export default movieDetailsPage;