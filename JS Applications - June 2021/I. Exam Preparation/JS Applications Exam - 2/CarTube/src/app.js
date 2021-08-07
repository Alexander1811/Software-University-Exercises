import page from "./../node_modules/page/page.mjs";
import { LitRenderer } from "./rendering/litRenderer.js";
import authService from "./services/authService.js";
import listingsService from "./services/listingsService.js";

import nav from "./nav/nav.js";
import homePage from "./pages/home/homePage.js";
import allListingsPage from "./pages/allListings/allListingsPage.js";
import loginPage from "./pages/login/loginPage.js";
import registerPage from "./pages/register/registerPage.js";
import detailsPage from "./pages/details/detailsPage.js";
import createPage from "./pages/create/createPage.js";
import editPage from "./pages/edit/editPage.js";
import myListingsPage from "./pages/myListings/myListingsPage.js";
import searchPage from "./pages/search/searchPage.js";

let appElement = document.querySelector("#site-content");
let navElement = document.querySelector("nav");

let renderer = new LitRenderer();

let navRenderHandler = renderer.createRenderHandler(navElement);
let appRenderHandler = renderer.createRenderHandler(appElement);

nav.initialize(page, navRenderHandler, authService);
homePage.initialize(page, appRenderHandler, listingsService);
allListingsPage.initialize(page, appRenderHandler, listingsService);
loginPage.initialize(page, appRenderHandler, authService);
registerPage.initialize(page, appRenderHandler, authService);
detailsPage.initialize(page, appRenderHandler, authService, listingsService);
createPage.initialize(page, appRenderHandler, listingsService);
editPage.initialize(page, appRenderHandler, listingsService);
myListingsPage.initialize(page, appRenderHandler, authService, listingsService);
searchPage.initialize(page, appRenderHandler, listingsService);

page(decorateUser);
page(nav.getView);
page("/home", homePage.getView);
page("/all-listings", allListingsPage.getView);
page("/login", loginPage.getView);
page("/register", registerPage.getView);
page("/details/:id", detailsPage.getView);
page("/create", createPage.getView);
page("/edit/:id", editPage.getView);
page("/my-listings", myListingsPage.getView);
page("/search", searchPage.getView);
page("/index.html", "/home");
page("/", "/home");

page.start();

function decorateUser(context, next) {
    let user = authService.getUser();
    context.user = user;
    next();
}