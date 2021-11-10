import auth from "../services/authService.js";

let section = undefined;

function initialize(domElement) {
    section = domElement;
    let form = section.querySelector("#register-form");
    form.addEventListener("submit", registerHandler);
}

async function getView() {
    return section;
}

async function registerHandler(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let user = {
        email: formData.get("email"),
        password: formData.get("password")
    }
    let repeatPassword = formData.get("repeatPassword");

    if (user.email == "" || user.password == "" || repeatPassword == "") {
        return alert("All fields are required!");
    }
    if (user.password.length < 6) {
        return alert("The password must be at least 6 characters!");
    }
    if (user.password != repeatPassword) {
        return alert("The passwords do not match!");
    }

    await auth.register(user);
    form.reset();
}

let registerPage = {
    initialize,
    getView
};

export default registerPage;