import { html } from "./../../node_modules/lit-html/lit-html.js";
import { ifDefined } from "./../../node_modules/lit-html/directives/if-defined.js"

let townLiTemplate = (town) => html`<li class=${ifDefined(town.class)}>${town.name}</li>`;

export let townsTemplate = (towns) => html`
<ul>
    ${towns.map(town => townLiTemplate(town))}
</ul>`;

export let matchesTemplate = (matches) => html`<div>${matches} matches found</div>`