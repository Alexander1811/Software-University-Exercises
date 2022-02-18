import { jsonRequest } from "./httpService.js";

let baseUrl = 'http://localhost:3030/jsonstore/collections/myboard';
let postsUrl = `${baseUrl}/posts`;
let commentsUrl = `${baseUrl}/comments`;

async function createPost(newPost) {
    let createResult = await jsonRequest(postsUrl, "Post", newPost);
    return createResult;
}

async function getPost(topicId) {
    let post = await jsonRequest(`${postsUrl}/${topicId}`);
    return post;
}

async function getAllPosts() {
    let posts = await jsonRequest(postsUrl);
    return posts;
}

async function createComment(newComment) {
    let createResult = await jsonRequest(commentsUrl, "Post", newComment);
    return createResult;
}

async function getAllComments(topicId) {
    let comments = await jsonRequest(`${commentsUrl}?where=postId%3D"${topicId}`);
    return comments;
}

let postingService = {
    createPost,
    getPost,
    getAllPosts,
    createComment,
    getAllComments
}

export default postingService;