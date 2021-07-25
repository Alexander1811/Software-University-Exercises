import homeModule from "./pages/home.js";
import topicPage from "./pages/topic.js";

let homePage = document.querySelector("#homepage");
let commentsPage = document.querySelector("#comment-page");

setup();
async function setup() {
    await homeModule.getPostsHandler();

    let homeElement = document.querySelector("li a");
    homeElement.addEventListener("click", navigateToHomePage);
}

async function navigateToHomePage() {
    homePage.classList.remove("hidden");
    commentsPage.classList.add("hidden");
}

async function navigatoToTopicPage(e) {
    let id = e.currentTarget.id;
    await topicPage.getPostHandler(id);

    homePage.classList.add("hidden");
    commentsPage.classList.remove("hidden");
}

let viewChanger = {
    navigateToHomePage,
    navigatoToTopicPage
}

export default viewChanger;