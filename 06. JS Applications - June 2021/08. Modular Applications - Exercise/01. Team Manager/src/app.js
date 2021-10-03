import page from "./../node_modules/page/page.mjs";
import { LitRenderer } from "./rendering/litRenderer.js";
import authService from "./services/authService.js";
import membersService from "./services/membersService.js";
import teamsService from "./services/teamsService.js";

import nav from "./nav/nav.js";
import homePage from "./pages/home/homePage.js";
import browsePage from "./pages/browse/browsePage.js";
import loginPage from "./pages/login/loginPage.js";
import registerPage from "./pages/register/registerPage.js";
import detailsPage from "./pages/details/detailsPage.js";
import createPage from "./pages/create/createPage.js";
import editPage from "./pages/edit/editPage.js";
import myTeamsPage from "./pages/myTeams/myTeamsPage.js";
import modal from "./pages/modal/modal.js";

let appElement = document.querySelector("#app");
let navElement = document.querySelector("#titlebar");
let modalElement = document.querySelector("#modal");

let litHandler = new LitRenderer();

let navRenderHandler = litHandler.createRenderHandler(navElement);
let appRenderHandler = litHandler.createRenderHandler(appElement);
let modalRenderHandler = litHandler.createRenderHandler(modalElement);

nav.initialize(page, navRenderHandler, authService);
homePage.initialize(page, appRenderHandler);
browsePage.initialize(page, appRenderHandler, teamsService, membersService);
loginPage.initialize(page, appRenderHandler, authService);
registerPage.initialize(page, appRenderHandler, authService);
detailsPage.initialize(page, appRenderHandler, teamsService, membersService);
createPage.initialize(page, appRenderHandler, teamsService);
editPage.initialize(page, appRenderHandler, teamsService);
myTeamsPage.initialize(page, appRenderHandler, teamsService, membersService);
modal.initialize(page, modalRenderHandler);

page(decorateUser)
page(nav.getView);
page("/home", homePage.getView);
page("/browse-teams", browsePage.getView);
page("/login", loginPage.getView);
page("/register", registerPage.getView);
page("/logout", loginPage.getView);
page("/details/:id", detailsPage.getView);
page("/create", createPage.getView);
page("/edit/:id", editPage.getView);
page("/my-teams", myTeamsPage.getView);
page("/index.html", "/home");
page("/", "/home");

page.start();

function decorateUser(context, next){
    let user = authService.getUser();
    context.user = user;
    next();
}