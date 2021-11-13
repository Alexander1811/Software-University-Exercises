function attachEvents() {
    let postsSelect = document.querySelector("#posts");

    let postTitle = document.querySelector("#post-title");
    let postBody = document.querySelector("#post-body");
    let postCommentsUl = document.querySelector("#post-comments");

    let loadPostsButton = document.querySelector("#btnLoadPosts");
    loadPostsButton.addEventListener("click", loadPostsHandler);

    let viewButton = document.querySelector("#btnViewPost");
    viewButton.addEventListener("click", viewHandler);

    async function loadPostsHandler() {
        let postsRequest = await fetch("http://localhost:3030/jsonstore/blog/posts");
        let posts = await postsRequest.json();

        Object.keys(posts).forEach(key => {
            let post = posts[key];

            let postOption = document.createElement("option");
            postOption.value = key;
            postOption.textContent = post.title;

            postsSelect.appendChild(postOption);
        });
    }

    async function viewHandler() {
        Array.from(postCommentsUl.children).forEach(li => li.remove());

        let selectedPostId = postsSelect.value;

        let commentsRequest = await fetch("http://localhost:3030/jsonstore/blog/comments");
        let comments = await commentsRequest.json();

        Object.keys(comments)
            .filter(key => comments[key].postId == selectedPostId)
            .forEach(key => {
                let comment = comments[key];

                let commentLi = document.createElement("li");
                commentLi.id = comment.id;
                commentLi.textContent = comment.text;

                postCommentsUl.appendChild(commentLi);
            });

        let postRequest = await fetch(`http://localhost:3030/jsonstore/blog/posts/${selectedPostId}`);
        let post = await postRequest.json();

        postTitle.textContent = post.title;
        postBody.textContent = post.body;
    }
}

attachEvents();