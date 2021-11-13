import { html } from "./../../node_modules/lit-html/lit-html.js";
import { ifDefined } from "./../../node_modules/lit-html/directives/if-defined.js"

let rowTemplate = (row) => html`
<tr class=${ifDefined(row.class)}>
    <td>${row.firstName} ${row.lastName}</td>
    <td>${row.email}</td>
    <td>${row.course}</td>
</tr>`;

export let tableTemplate = (rows) => html`${rows.map(row => rowTemplate(row))}`;