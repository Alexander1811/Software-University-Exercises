import { html, nothing } from "./../../../node_modules/lit-html/lit-html.js";

export let detailsTemplate = (book, isOwner, isLoggedIn, buttons, likes, hasLiked) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${book.title}</h3>
        <p class="type">Type: ${book.type}</p>
        <p class="img"><img src=${book.imageUrl}></p>
        <div class="actions">
            ${isOwner
        ? html`
            <a class="button" href="/edit/${book._id}">Edit</a>
            <a class="button" href="javascript:void(0)" @click=${buttons.deleteHandler}>Delete</a>`
        : nothing}

            <!-- Bonus -->
            <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
            ${isLoggedIn & !isOwner & !hasLiked
        ? html`<a class="button" href="javascript:void(0)" @click=${buttons.likeHandler}>Like</a>`
        : nothing}

            <!-- ( for Guests and Users )  -->
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${likes}</span>
            </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${book.description}</p>
    </div>
</section>`;