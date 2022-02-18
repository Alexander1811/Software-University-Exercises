import page from "./../node_modules/page/page.mjs";
import { LitRenderer } from "./rendering/litRenderer.js";
import authService from "./services/authService.js";
import memesService from "./services/memesService.js";

import nav from "./nav/nav.js";
import homePage from "./pages/home/homePage.js";
import feedPage from "./pages/feed/feedPage.js";
import loginPage from "./pages/login/loginPage.js";
import registerPage from "./pages/register/registerPage.js";
import profilePage from "./pages/profile/profilePage.js";
import createPage from "./pages/create/createPage.js";
import editPage from "./pages/edit/editPage.js";
import detailsPage from "./pages/details/detailsPage.js";
import notification from "./notifications/notification.js";

let appElement = document.querySelector("main");
let navElement = document.querySelector("nav");
let notificationBoxElement = document.querySelector("#errorBox");

let renderer = new LitRenderer();

let navRenderHandler = renderer.createRenderHandler(navElement);
let appRenderHandler = renderer.createRenderHandler(appElement);
let notificationRenderHandler = renderer.createRenderHandler(notificationBoxElement);

nav.initialize(page, navRenderHandler, authService);
homePage.initialize(page, appRenderHandler, memesService);
feedPage.initialize(page, appRenderHandler, memesService);
loginPage.initialize(page, appRenderHandler, authService);
registerPage.initialize(page, appRenderHandler, authService);
profilePage.initialize(page, appRenderHandler, authService, memesService);
createPage.initialize(page, appRenderHandler, memesService);
editPage.initialize(page, appRenderHandler, memesService);
detailsPage.initialize(page, appRenderHandler, authService, memesService);
notification.initialize(notificationRenderHandler, notificationBoxElement);

let defaultHomePage = authService.getUser() != null ? "/feed" : "/home";

page(decorateUser);
page(nav.getView);
page("/home", homePage.getView);
page("/feed", feedPage.getView);
page("/login", loginPage.getView);
page("/register", registerPage.getView);
page("/profile", profilePage.getView);
page("/create", createPage.getView);
page("/edit/:id", editPage.getView);
page("/details/:id", detailsPage.getView);
page("/index.html", defaultHomePage);
page("/", defaultHomePage);

page.start();

function decorateUser(context, next) {
    let user = authService.getUser();
    context.user = user;
    next();
}