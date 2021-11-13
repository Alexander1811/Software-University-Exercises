import domService from "../services/domService.js";
import postingService from "../services/postingService.js";

let commentsDiv = document.querySelector("#comments");

let commentsForm = document.querySelector("#comment-form");
commentsForm.addEventListener("submit", createCommentHandler);

let topicId = undefined;

async function getPostHandler(id) {
    [...commentsDiv.children].forEach(comment => comment.remove());
    topicId = id;

    let themeHeading = document.querySelector("#theme");
    let topic = await postingService.getPost(topicId);
    themeHeading.textContent = topic.title;

    commentsDiv.appendChild(createTopicHeaderDiv(topic));

    let comments = await postingService.getAllComments(topicId);

    Object.values(comments).filter(comment => comment.topicId == topicId).forEach(comment => {
        commentsDiv.appendChild(createCommentWrapperDiv(comment));
    });
}

async function createCommentHandler(e) {
    e.preventDefault();

    let formData = new FormData(commentsForm);
    let newComment = {
        postText: formData.get("postText"),
        username: formData.get("username"),
        topicId: topicId,
        date: domService.timeFormats.getCommentTimeFormat()
    }

    if (newComment.username.trim() == "") {
        return alert("Username cannot be empty!");
    }
    if (newComment.postText.trim() == "") {
        return alert("Cannot post empty comment!");
    }

    let createResult = await postingService.createComment(newComment);

    commentsDiv.appendChild(createCommentWrapperDiv(createResult));

    commentsForm.reset();
}

function createTopicHeaderDiv(topic) {
    let headerDiv = domService.createNestedElement("div", { class: "header" });

    let profileImg = domService.createNestedElement("img", { src: "./static/profile.png", alt: "avatar" });

    let infoP = domService.createNestedElement("p");
    let usernameSpan = domService.createNestedElement("span", undefined, topic.username);

    let postingTime = domService.createNestedElement("time", undefined, domService.timeFormats.getTopicPagePostTimeFormat(topic.date));
    infoP.textContent = " posted on ";
    infoP.prepend(usernameSpan);
    infoP.appendChild(postingTime);

    let contetnParagraph = domService.createNestedElement("p", { class: "post-content" }, topic.postText);

    headerDiv.appendChild(profileImg);
    headerDiv.appendChild(infoP);
    headerDiv.appendChild(contetnParagraph);

    return headerDiv;
}

function createCommentWrapperDiv(comment) {
    let commentWrapperDiv = domService.createNestedElement("div", { class: "topic-name-wrapper" });

    let topicNameDiv = domService.createNestedElement("div", { class: "topic-name" });

    let infoP = domService.createNestedElement("p", undefined, " commented on ");
    let nameStrong = domService.createNestedElement("strong", undefined, comment.username);
    let timeElement = domService.createNestedElement("time", undefined, comment.date);
    infoP.prepend(nameStrong);
    infoP.appendChild(timeElement);

    let contentDiv = domService.createNestedElement("div", { class: "post-content" });
    let contentParagraph = domService.createNestedElement("p", undefined, comment.postText);
    contentDiv.appendChild(contentParagraph);

    topicNameDiv.appendChild(infoP);
    topicNameDiv.appendChild(contentParagraph);

    commentWrapperDiv.appendChild(topicNameDiv);

    return commentWrapperDiv;
}

let topicPage = {
    getPostHandler
}

export default topicPage;