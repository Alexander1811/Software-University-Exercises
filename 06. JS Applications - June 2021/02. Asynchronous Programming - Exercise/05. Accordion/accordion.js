function solution() {
    (async () => {
        let articlesRequest = await fetch("http://localhost:3030/jsonstore/advanced/articles/details");
        let articles = await articlesRequest.json();

        let mainSection = document.querySelector("#main");

        Object.keys(articles).forEach(key => {
            let article = articles[key];
            let articleHtml = createHtmlArticle(article._id, article.title, article.content);
            mainSection.appendChild(articleHtml);
        });
    })();

    function createHtmlArticle(userId, title, content) {
        let articleDiv = document.createElement("div");
        articleDiv.classList.add("accordion");

        let headDiv = document.createElement("div");
        headDiv.classList.add("head");

        let titleSpan = document.createElement("span");
        titleSpan.textContent = title;

        let showMoreButton = document.createElement("button");
        showMoreButton.classList.add("button");
        showMoreButton.id = userId;
        showMoreButton.textContent = "More";
        showMoreButton.addEventListener("click", showHiddenInfoHandler);

        headDiv.appendChild(titleSpan);
        headDiv.appendChild(showMoreButton);

        let extraDiv = document.createElement("div");
        extraDiv.classList.add("extra");

        let contentP = document.createElement("span");
        contentP.textContent = content;

        extraDiv.appendChild(contentP);

        articleDiv.appendChild(headDiv);
        articleDiv.appendChild(extraDiv);

        return articleDiv;
    }

    function showHiddenInfoHandler(e) {
        let showMoreButton = e.target;
        let contentDiv = showMoreButton.parentElement.parentElement.querySelector("div .extra");

        showMoreButton.textContent = showMoreButton.textContent == "More" ? "Less" : "More";
        contentDiv.style.display = contentDiv.style.display == "block" ? "none" : "block";
    }
}

solution();