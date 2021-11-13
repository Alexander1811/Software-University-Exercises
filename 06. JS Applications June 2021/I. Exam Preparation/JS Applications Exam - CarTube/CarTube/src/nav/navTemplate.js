import { html } from "./../../node_modules/lit-html/lit-html.js";

export let navTemplate = (model) => html`
<a class="active" href="/home">Home</a>
<a href="/all-listings">All Listings</a>
<a href="/search">By Year</a>
${model.isLoggedIn
    ? html`
    <div id="profile">
        <a>Welcome ${model.username}</a>
        <a href="/my-listings">My Listings</a>
        <a href="/create">Create Listing</a>
        <a href="javascript:void(0)" @click=${model.logoutHandler}>Logout</a>
    </div>` 
        : html`
    <div id="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>`}`;