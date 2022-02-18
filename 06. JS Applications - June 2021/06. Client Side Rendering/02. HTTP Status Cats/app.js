import { render } from "./../node_modules/lit-html/lit-html.js";
import { cats } from "./catSeeder.js";
import { catsTemplate } from "./templates/catTemplates.js";

let catsSection = document.querySelector("#allCats");

render(catsTemplate(cats, toggleStatusCodeButton), catsSection);

function toggleStatusCodeButton(e) {
    let button = e.target;
    button.textContent = button.textContent == "Show status code"
        ? "Hide status code"
        : "Show status code";

    let infoDiv = button.closest(".info");
    let statusDiv = infoDiv.querySelector(".status");

    if (statusDiv.classList.contains("hidden")) {
        statusDiv.classList.remove("hidden");
    } else {
        statusDiv.classList.add("hidden");
    }
}