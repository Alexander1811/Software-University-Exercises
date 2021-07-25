import nav from "../pages/nav.js";
import viewFinder from "../viewFinder.js";
import { jsonRequest } from "./httpService.js";

function getToken() {
    return localStorage.getItem("authToken");
}

function getUserId() {
    return localStorage.getItem("userId");
}

function getEmail() {
    return localStorage.getItem("email");
}

function checkIfUserIsLogged() {
    return localStorage.getItem("authToken") != null;
}

async function login(user) {
    let url = "http://localhost:3030/users/login";
    let result = await jsonRequest(url, "Post", user);
    localStorage.setItem("authToken", result.accessToken);
    localStorage.setItem("userId", result._id);
    localStorage.setItem("email", result.email);
    nav.loginUser();
    viewFinder.navigateTo("home");
}

async function register(user) {
    let url = "http://localhost:3030/users/register";
    let result = await jsonRequest(url, "Post", user);
    localStorage.setItem("authToken", result.accessToken);
    localStorage.setItem("userId", result._id);
    localStorage.setItem("email", result.email);
    nav.loginUser();
    viewFinder.navigateTo("home");
}

async function logout() {
    await jsonRequest("http://localhost:3030/users/logout", "Get", undefined, true, true);
    localStorage.clear();
    nav.logoutUser();
    return viewFinder.redirectTo("login");
}

let auth = {
    getToken,
    getUserId,
    getEmail,
    register,
    login,
    logout,
    checkIfUserIsLogged
}

export default auth;