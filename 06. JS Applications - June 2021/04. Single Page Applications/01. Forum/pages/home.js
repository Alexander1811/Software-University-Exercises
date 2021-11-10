import viewChanger from "../app.js";
import domService from "../services/domService.js";
import postingService from "../services/postingService.js";

let topicContainer = document.querySelector("#topic-container");

let postForm = document.querySelector("#post-form");
postForm.addEventListener("submit", createPostHandler);

let cancelButton = postForm.querySelector(".cancel");
cancelButton.addEventListener("click", postForm.reset());

async function getPostsHandler() {
    [...topicContainer.children].forEach(post => post.remove());

    let posts = await postingService.getAllPosts();

    Object.values(posts).forEach(post => {
        topicContainer.appendChild(createTopicWrapperDiv(post));
    });
}

async function createPostHandler(e) {
    e.preventDefault();

    let formData = new FormData(postForm);
    let title = formData.get("topicName");
    let username = formData.get("username");
    let postText = formData.get("postText");

    let newPost = {
        username: username,
        title: title,
        postText: postText,
        date: domService.timeFormats.getHomepagePostTimeFormat()
    }

    if (Object.values(newPost).some(field => field == "")) {
        return alert("All fields are required!");
    }

    let createResult = await postingService.createPost(newPost);

    topicContainer.appendChild(createTopicWrapperDiv(createResult));

    postForm.reset();
}

function createTopicWrapperDiv(post) {
    let id = post._id;
    let nameWrapperDiv = domService.createNestedElement("div", { "id": id, class: "topic-name-wrapper" });
    nameWrapperDiv.addEventListener("click", viewChanger.navigatoToTopicPage);
    let nameDiv = domService.createNestedElement("div", { class: "topic-name" });

    let titleA = domService.createNestedElement("a", { class: "normal", href: "#" });
    let titleHeading = domService.createNestedElement("h2", undefined, post.title);
    titleA.appendChild(titleHeading);

    let columnsDiv = domService.createNestedElement("div", { class: "columns" });
    let insideColumnDiv = domService.createNestedElement("div");

    let dateP = domService.createNestedElement("p", undefined, "Date: ");
    let date = domService.createNestedElement("date");
    dateP.appendChild(date);
    let time = domService.createNestedElement("time", undefined, post.date);
    date.appendChild(time);

    let nicknameDiv = domService.createNestedElement("div", { class: "nick-name" });
    let usernameP = domService.createNestedElement("p", undefined, "Username: ");
    let nameSpan = domService.createNestedElement("span", undefined, post.username);
    usernameP.appendChild(nameSpan);
    nicknameDiv.appendChild(usernameP);

    insideColumnDiv.appendChild(dateP);
    insideColumnDiv.appendChild(nicknameDiv);
    columnsDiv.appendChild(insideColumnDiv);

    nameDiv.appendChild(titleA);
    nameDiv.appendChild(columnsDiv);

    nameWrapperDiv.appendChild(nameDiv);

    return nameWrapperDiv;
}

let homeModule = {
    getPostsHandler
}

export default homeModule;