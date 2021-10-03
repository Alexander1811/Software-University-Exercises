import { render } from "./../node_modules/lit-html/lit-html.js";
import { matchesTemplate, townsTemplate } from "./templates/townTemplates.js";
import { towns } from "./towns.js";

let townsDiv = document.querySelector("#towns");
let inputTowns = towns.map(town => ({ name: town }));
render(townsTemplate(inputTowns), townsDiv);

let searchButton = document.querySelector("#search-button");
searchButton.addEventListener("click", search);

function search() {
   let searchText = document.querySelector("#searchText").value.toLowerCase();

   let allTowns = towns.map(town => ({ name: town }));
   let matchedTowns = allTowns.filter(town => town.name.toLocaleLowerCase().includes(searchText));
   matchedTowns.forEach(town => town.class = "active");

   render(townsTemplate(allTowns), townsDiv);

   let resultDiv = document.querySelector("#result");
   render(matchesTemplate(matchedTowns.length), resultDiv);
}