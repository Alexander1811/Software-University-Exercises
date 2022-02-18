import { html } from "./../../node_modules/lit-html/lit-html.js";

export let navTemplate = (model) => html`
<nav>
    <a href="/feed">All Memes</a>
    ${model.isLoggedIn
        ? html`
    <div class="user">
        <a href="/create">Create Meme</a>
        <div class="profile">
            <span>Welcome, ${model.email}</span>
            <a href="/profile">My Profile</a>
            <a href="javascript:void(0)" @click=${model.logoutHandler}>Logout</a>
        </div>
    </div>`
        : html`
    <div class="guest">
        <div class="profile">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
        </div>
        <a class="active" href="/home">Home Page</a>
    </div>`}
</nav>`