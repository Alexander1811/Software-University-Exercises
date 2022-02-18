import { html, nothing } from "./../../../node_modules/lit-html/lit-html.js";

let recordTemplate = (car) => html`
<div class="listing">
    <div class="preview">
        <img src=${car.imageUrl}>
    </div>
    <h2>${car.brand} ${car.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${car.year}</h3>
            <h3>Price: ${car.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${car._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>`;

let resultTemplate = (matches) => html`
${matches.length > 0 
? html`${matches.map(match => recordTemplate(match))}`
: html`<p class="no-cars"> No results.</p>`}`;

export let searchTemplate = (onSearchClick, year, matches) => html`
<section id="search-cars">
    <h1>Filter by year</h1>
    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
        <button class="button-list" @click=${onSearchClick}>Search</button>
    </div>
    <h2>Results:</h2>
    <div class="listings">
        ${year != undefined 
        ? resultTemplate(matches)
        : nothing}
    </div>
</section>`;
