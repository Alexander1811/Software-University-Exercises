import { html } from "./../../node_modules/lit-html/lit-html.js";

let townLiTemplate = (town) => html`<li>${town}</li>`;

export let townsTemplate = (towns) => html`
<ul>
    ${towns.map(town => townLiTemplate(town))}
</ul>`;