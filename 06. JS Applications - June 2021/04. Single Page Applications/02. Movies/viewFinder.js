import addMoviePage from "./pages/addMovie.js";
import editMoviePage from "./pages/editMovie.js";
import homePage from "./pages/home.js";
import loginPage from "./pages/login.js";
import movieDetailsPage from "./pages/movieDetails.js";
import registerPage from "./pages/register.js";
import auth from "./services/authService.js";

let views = {
    "home": async () => await homePage.getView(),
    "login": async () => await loginPage.getView(),
    "register": async () => await registerPage.getView(),
    "logout": async () => await auth.logout(),
    "add": async () => await addMoviePage.getView(),
    "movie-details": async (id) => await movieDetailsPage.getView(id),
    "edit": async (id) => await editMoviePage.getView(id),
    "delete": async (id) => await movieDetailsPage.deleteMovie(id),
    "like": async (id) => await movieDetailsPage.likeMovie(id),
}

let navLinkSelector = undefined;
let navigationCallback = undefined;

function initialize(allLinkElements, linkSelector, callback) {
    allLinkElements.forEach(a => a.addEventListener("click", changeViewHandler));
    navLinkSelector = linkSelector;
    navigationCallback = callback;
}

export async function changeViewHandler(e) {
    let element = e.target.matches(navLinkSelector)
        ? e.target
        : e.target.closest(navLinkSelector);

    let route = element.dataset.route;
    let id = element.dataset.id;

    navigateTo(route, id);
}

export async function navigateTo(route, id) {
    if (views.hasOwnProperty(route)) {
        let viewPromise = views[route](id);

        navigationCallback(viewPromise);
    }
}

export async function redirectTo(route, id) {
    if (views.hasOwnProperty(route)) {
        let view = await views[route](id);
        return view;
    }
}

let viewFinder = {
    initialize,
    changeViewHandler,
    navigateTo,
    redirectTo
};

export default viewFinder;
