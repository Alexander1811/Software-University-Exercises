function addItem() {
    let textElement = document.querySelector("#newItemText");
    let valueElement = document.querySelector("#newItemValue");

    let newOptionElement = document.createElement("option");
    newOptionElement.textContent = textElement.value;
    newOptionElement.value = valueElement.value;

    let menuElement = document.getElementById("menu");
    menuElement.appendChild(newOptionElement);

    textElement.value = "";
    valueElement.value = "";
}