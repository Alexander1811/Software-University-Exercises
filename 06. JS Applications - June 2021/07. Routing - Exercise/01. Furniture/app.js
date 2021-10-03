import page from "./../node_modules/page/page.mjs";
import renderingMiddleware from "./rendering/renderingMiddleware.js";
import authService from "./services/authService.js";

import nav from "./nav/nav.js";
import dashboardPage from "./pages/dashboard/dashboardPage.js";
import loginPage from "./pages/login/loginPage.js";
import registerPage from "./pages/register/registerPage.js";
import detailsPage from "./pages/details/detailsPage.js";
import createPage from "./pages/create/createPage.js";
import editPage from "./pages/edit/editPage.js";
import myFurniturePage from "./pages/myFurniture/myFurniturePage.js";

let appContainer = document.querySelector("#view-container");
let navContainer = document.querySelector("#navigation");
renderingMiddleware.initialize(appContainer, navContainer);

page("/dashboard", renderingMiddleware.decorateContext, nav.getView, dashboardPage.getView);
page("/login", renderingMiddleware.decorateContext, nav.getView, loginPage.getView);
page("/register", renderingMiddleware.decorateContext, nav.getView, registerPage.getView);
page("/logout", async (context) => { await authService.logout(); context.page.redirect("/login"); });
page("/details/:id", renderingMiddleware.decorateContext, nav.getView, detailsPage.getView);
page("/create", renderingMiddleware.decorateContext, nav.getView, createPage.getView);
page("/edit/:id", renderingMiddleware.decorateContext, nav.getView, editPage.getView);
page("/my-furniture", renderingMiddleware.decorateContext, nav.getView, myFurniturePage.getView);
page("/index.html", "/dashboard");
page("/", "/dashboard");

page.start();
page.redirect("/dashboard");