import page from "./../node_modules/page/page.mjs";
import { LitRenderer } from "./rendering/litRenderer.js";
import authService from "./services/authService.js";
import booksService from "./services/booksService.js";
import likesService from "./services/likesService.js";

import nav from "./nav/nav.js";
import loginPage from "./pages/login/loginPage.js";
import registerPage from "./pages/register/registerPage.js";
import createPage from "./pages/create/createPage.js";
import editPage from "./pages/edit/editPage.js";
import detailsPage from "./pages/details/detailsPage.js";
import dashboardPage from "./pages/dashboard/dashboardPage.js";
import myBooksPage from "./pages/myBooks/myBooksPage.js";

let appElement = document.querySelector("main#site-content");
let navElement = document.querySelector("nav.navbar");

let renderer = new LitRenderer();

let navRenderHandler = renderer.createRenderHandler(navElement);
let appRenderHandler = renderer.createRenderHandler(appElement);

nav.initialize(page, navRenderHandler, authService);
dashboardPage.initialize(page, appRenderHandler, booksService);
loginPage.initialize(page, appRenderHandler, authService);
registerPage.initialize(page, appRenderHandler, authService);
createPage.initialize(page, appRenderHandler, booksService);
editPage.initialize(page, appRenderHandler, booksService);
detailsPage.initialize(page, appRenderHandler, authService, booksService, likesService);
myBooksPage.initialize(page, appRenderHandler, authService, booksService);

page(decorateUser);
page(nav.getView);
page("/dashboard", dashboardPage.getView);
page("/login", loginPage.getView);
page("/register", registerPage.getView);
page("/create", createPage.getView);
page("/edit/:id", editPage.getView);
page("/details/:id", detailsPage.getView);
page("/my-books", myBooksPage.getView);
page("/index.html", "/dashboard");
page("/", "/dashboard");

page.start();

function decorateUser(context, next) {
    let user = authService.getUser();
    context.user = user;
    next();
}