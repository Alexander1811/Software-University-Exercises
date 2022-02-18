import { html } from "./../../node_modules/lit-html/lit-html.js";

let optionTemplate = (option) => html`<option .value=${option._id}>${option.text}</option>`;

export let menuOptionsTemplate = (options) => html`${options.map(option => optionTemplate(option))}`;