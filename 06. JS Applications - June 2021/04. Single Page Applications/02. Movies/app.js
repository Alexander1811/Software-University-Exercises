import nav from "./pages/nav.js";
import registerPage from "./pages/register.js";
import loginPage from "./pages/login.js";
import homePage from "./pages/home.js";
import addMoviePage from "./pages/addMovie.js";
import editMoviePage from "./pages/editMovie.js";
import movieDetailsPage from "./pages/movieDetails.js";
import viewChanger from "./viewChanger.js";
import viewFinder from "./viewFinder.js";

setup();

async function setup() {
    let linkClass = "link";
    let linkSelector = `.${linkClass}`;

    loginPage.initialize(document.querySelector("#form-login"));
    registerPage.initialize(document.querySelector("#form-sign-up"));
    homePage.initialize(document.querySelector("#home-page"), linkClass);
    addMoviePage.initialize(document.querySelector("#add-movie"));
    editMoviePage.initialize(document.querySelector("#edit-movie"));
    movieDetailsPage.initialize(document.querySelector("#movie-details"), linkClass);

    nav.initialize(document.querySelector("#nav"));

    let appElement = document.querySelector("#main");

    viewChanger.initialize(appElement, ".view");
    viewFinder.initialize(document.querySelectorAll(linkSelector), linkSelector, viewChanger.changeView);

    viewFinder.navigateTo("home");
}