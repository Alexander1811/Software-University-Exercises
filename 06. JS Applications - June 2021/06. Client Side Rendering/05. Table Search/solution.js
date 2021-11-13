import { render } from "./../node_modules/lit-html/lit-html.js";
import { tableTemplate } from "./templates/tableTemplates.js";

let baseUrl = "http://localhost:3030/jsonstore/advanced/table";

let infoTable = document.querySelector("#info-table");
let allRows = [];
loadRows();

let searchButton = document.querySelector("#searchBtn");
searchButton.addEventListener("click", onClick);

async function loadRows() {
   let tableResponse = await fetch(baseUrl);
   let tableObj = await tableResponse.json();

   let tableRows = Object.values(tableObj);
   allRows = tableRows;

   render(tableTemplate(tableRows), infoTable);
}

function onClick() {
   let searchInput = document.querySelector("#searchField");
   let searchText = searchInput.value.toLowerCase();

   if (searchText.trim() == "") {
      return alert("Search field cannot be empty!");
   }

   let matchedRows = allRows.filter(row => {
      infoInputs = Object.values(row);

      return infoInputs.some(value => {
         if (value == undefined) { return false; }
         return value.toLowerCase().includes(searchText);
      });
   });
   matchedRows.forEach(row => row.class = "select");

   render(tableTemplate(allRows), infoTable);

   allRows.forEach(row => row.class = undefined);

   searchInput.value = "";
}