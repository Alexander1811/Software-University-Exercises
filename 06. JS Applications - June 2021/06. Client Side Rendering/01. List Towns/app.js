import { render } from "./../node_modules/lit-html/lit-html.js";
import { townsTemplate } from "./templates/townTemplates.js";

let rootDiv = document.querySelector("#root");

let form = document.querySelector("#towns-form");
form.addEventListener("submit", loadTownsHandler);

function loadTownsHandler(e){
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let towns = formData.get("towns").split(', ');

    render(townsTemplate(towns), rootDiv);
}