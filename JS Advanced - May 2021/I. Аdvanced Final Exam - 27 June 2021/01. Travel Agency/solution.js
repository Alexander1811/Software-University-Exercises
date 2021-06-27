window.addEventListener('load', solution);

function solution() {
  let fullNameInput = document.querySelector("#fname");
  let emailInput = document.querySelector("#email");
  let phoneInput = document.querySelector("#phone");
  let addressInput = document.querySelector("#address");
  let postalCodeInput = document.querySelector("#code");

  let submitButton = document.querySelector("#submitBTN");
  submitButton.addEventListener("click", getInformationHandler);

  let previewUl = document.querySelector("#infoPreview");

  function getInformationHandler(e) {
    e.preventDefault();

    let fullName = fullNameInput.value;
    let email = emailInput.value;
    let phone = phoneInput.value;
    let address = addressInput.value;
    let code = postalCodeInput.value;

    if (!fullNameInput.value || !emailInput.value) {
      return;
    }

    fullNameInput.value = "";
    emailInput.value = "";
    phoneInput.value = "";
    addressInput.value = "";
    postalCodeInput.value = "";

    e.target.disabled = true;

    let editButton = document.querySelector("#editBTN");
    editButton.disabled = false;

    let continueButton = document.querySelector("#continueBTN");
    continueButton.disabled = false;

    let fullNameLi = document.createElement("li");
    fullNameLi.textContent = `Full Name: ${fullName}`;

    let emailLi = document.createElement("li");
    emailLi.textContent = `Email: ${email}`;

    let phoneLi = document.createElement("li");
    phoneLi.textContent = `Phone Number: ${phone}`;

    let addressLi = document.createElement("li");
    addressLi.textContent = `Address: ${address}`;

    let codeLi = document.createElement("li");
    codeLi.textContent = `Postal Code: ${code}`;

    previewUl.appendChild(fullNameLi);
    previewUl.appendChild(emailLi);
    previewUl.appendChild(phoneLi);
    previewUl.appendChild(addressLi);
    previewUl.appendChild(codeLi);

    editButton.addEventListener('click', () => {
      while (previewUl.firstChild) {
        previewUl.removeChild(previewUl.firstChild);
      }

      fullNameInput.value = fullNameLi.textContent.split(':')[1].trim();
      emailInput.value = emailLi.textContent.split(':')[1].trim();
      phoneInput.value = phoneLi.textContent.split(':')[1].trim();
      addressInput.value = addressLi.textContent.split(':')[1].trim();
      postalCodeInput.value = codeLi.textContent.split(':')[1].trim();

      submitButton.disabled = false;
      editButton.disabled = true;
      continueButton.disabled = true;
    });

    continueButton.addEventListener('click', (e) => {
      let blockDiv = document.querySelector("#block");

      while (blockDiv.firstChild) {
        blockDiv.removeChild(blockDiv.firstChild);
      }
      let thanksHeader = document.createElement("h3");
      thanksHeader.textContent = "Thank you for your reservation!";

      blockDiv.appendChild(thanksHeader);
    })
  }
}