function solve() {
  let textAreas = document.querySelectorAll("#exercise textarea");
  let generateTextArea = textAreas[0];
  let buyTextArea = textAreas[1];

  let buttons = document.querySelectorAll("#exercise button");
  let generateButton = buttons[0];
  let buyButton = buttons[1];

  buyButton.addEventListener("click", buyItems);
  generateButton.addEventListener("click", generateItems);

  function generateItems() {
    let newItemsData = JSON.parse(generateTextArea.value);
    let tableBody = document.querySelector(".table tbody");

    newItemsData.forEach(el => {
      let tr = document.createElement("tr");

      let imageTd = createNestedTdElement("img", undefined, { src: el.img });
      let nameTd = createNestedTdElement("p", el.name);
      let priceTd = createNestedTdElement("p", el.price);
      let decFactorTd = createNestedTdElement("p", el.decFactor);
      let checkboxTd = createNestedTdElement("input", undefined, { type: "checkbox" });

      tr.appendChild(imageTd);
      tr.appendChild(nameTd);
      tr.appendChild(priceTd);
      tr.appendChild(decFactorTd);
      tr.appendChild(checkboxTd);

      tableBody.appendChild(tr);
    });
  }

  function buyItems() {
    let tableRows = Array.from(document.querySelectorAll(".table tbody tr"));
    let checkedRows = tableRows.filter(row => row.querySelectorAll("input:checked").length > 0);

    let names = checkedRows
      .map(row => row.querySelector("td:nth-of-type(2) p"))
      .map(x => x.textContent);

    let prices = checkedRows
      .map(row => row.querySelector("td:nth-of-type(3) p"))
      .map(x => Number(x.textContent));

    let decFactors = checkedRows
      .map(row => row.querySelector("td:nth-of-type(4) p"))
      .map(x => Number(x.textContent));

    let namesString = names.join(", ");
    let totalPrice = prices.reduce((acc, el) => acc + el, 0).toFixed(2);
    let averageDecFactor = decFactors.reduce((acc, el) => acc + el, 0) / decFactors.length;

    let result = `Bought furniture: ${namesString}\n`
      + `Total price: ${totalPrice}\n`
      + `Average decoration factor: ${averageDecFactor}`;

    buyTextArea.textContent = result;
  }

  function createNestedTdElement(tagName, value, attributes) {
    let td = document.createElement("td");
    let nestedElement = document.createElement(tagName);

    if (value != undefined) {
      if (["input", "textarea", "select"].includes(tagName)) {
        nestedElement.value = value;
      }
      else {
        nestedElement.textContent = value;
      }
    }

    if (attributes != undefined) {
      for (const key in attributes) {
        nestedElement.setAttribute(key, attributes[key]);
      }
    }

    td.appendChild(nestedElement);
    return td;
  }
}