function validate() {
    let submitButton = document.querySelector("#submit");
    submitButton.addEventListener("click", validateFormHandler);

    let isCompanyCheckbox = document.querySelector("#company");
    isCompanyCheckbox.addEventListener("change", onIsCompanyHandle);

    function validateFormHandler(e) {
        e.preventDefault();

        let usernameInput = document.querySelector("#username");
        let usernameRegex = /^[a-zA-Z0-9]{3,20}$/;
        let isUsernameValid = usernameRegex.test(usernameInput.value);
        setBorder(usernameInput, isUsernameValid);

        let emailRegex = /^.*@.*\..*$/;
        let emailInput = document.querySelector("#email");
        let isEmailValid = emailRegex.test(emailInput.value);
        setBorder(emailInput, isEmailValid);

        let passwordInput = document.querySelector("#password");
        let confirmPasswordInput = document.querySelector("#confirm-password");
        let passwordRegex = /^[\w]{5,15}$/;
        let arePasswordsValid = passwordRegex.test(passwordInput.value) &&
            passwordRegex.test(confirmPasswordInput.value) &&
            passwordInput.value == confirmPasswordInput.value;
        setBorder(passwordInput, arePasswordsValid);
        setBorder(confirmPasswordInput, arePasswordsValid);

        let companyNumberIsValid = false;
        let isCompanyCheckbox = document.querySelector("#company");
        if (isCompanyCheckbox.checked) {
            let companyNumberInput = document.querySelector("#companyNumber");
            if (companyNumberInput.value.trim() !== "" && !isNaN(Number(companyNumberInput.value))) {
                let companyNumber = Number(companyNumberInput.value);
                if (companyNumber >= 1000 && companyNumber <= 9999) {
                    companyNumberIsValid = true;
                }
            }
            setBorder(companyNumberInput, companyNumberIsValid);
        }

        let validDiv = document.querySelector("#valid");
        let areMainInputsValid = isUsernameValid && isEmailValid && arePasswordsValid;
        let isCompanyInfoValid = (isCompanyCheckbox.checked && companyNumberIsValid) || !isCompanyCheckbox.checked;
        let isValidDivValid = areMainInputsValid && isCompanyInfoValid;
        validDiv.style.display = isValidDivValid ? "block" : "none";
    }

    function onIsCompanyHandle(e) {
        let companyInfoFieldset = document.querySelector("#companyInfo");
        companyInfoFieldset.style.display = e.target.checked ? "block" : "none";
    }

    function setBorder(element, isValid) {
        if (isValid) {
            element.style.setProperty("border", "none");
        }
        else {
            element.style.setProperty("border", "2px solid red");
        }
    }
}
