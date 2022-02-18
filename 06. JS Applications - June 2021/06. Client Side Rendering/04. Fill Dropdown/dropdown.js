import { render } from "./../node_modules/lit-html/lit-html.js";
import { menuOptionsTemplate } from "./templates/optionTemplates.js";

let baseUrl = "http://localhost:3030/jsonstore/advanced/dropdown";

let selectMenu = document.querySelector("#menu");
let options = [];
loadOptions();

let form = document.querySelector("#option-form");
form.addEventListener("submit", addOption);

async function loadOptions() {
    let optionsResponse = await fetch(baseUrl);
    let optionsObj = await optionsResponse.json();
    options = Object.values(optionsObj);

    render(menuOptionsTemplate(options), selectMenu);

    let submitButton = document.querySelector("#submit");
    submitButton.disabled = false;
}

async function addOption(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let newOption = {
        text: formData.get("text")
    }

    if (newOption.text.trim() == "") {
        return alert("Cannot add empty field!");
    }

    let createReponse = await fetch(baseUrl, {
        headers: { "Content-Type": "json/application" },
        method: "Post",
        body: JSON.stringify(newOption)
    });

    if (createReponse.ok) {
        let createdOption = await createReponse.json();
        options.push(createdOption);
        render(menuOptionsTemplate(options), selectMenu);
    }

    form.reset();
}