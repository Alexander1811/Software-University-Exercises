function getArticleGenerator(articles) {
    let contentElement = document.querySelector("#content");

    return function showNext() {
        let article = document.createElement("article");
        if (articles.length != 0) {
            article.textContent = updateArticle(articles)
            contentElement.appendChild(article);
        }
    };

    function updateArticle() {
        return articles.shift();
    }
}
