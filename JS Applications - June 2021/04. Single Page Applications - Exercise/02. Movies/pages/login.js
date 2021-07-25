import auth from "../services/authService.js";

let section = undefined;

function initialize(domElement) {
    section = domElement;
    let form = section.querySelector("#login-form");
    form.addEventListener("submit", loginHandler);
}

async function getView() {
    return section;
}

async function loginHandler(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let user = {
        email: formData.get("email"),
        password: formData.get("password")
    }

    if (user.email == "" || user.password == "") {
        return alert("All fields are required!");
    }
    if (user.password.length < 6) {
        return alert("The password must be at least 6 characters!");
    }

    await auth.login(user);
    form.reset();
}

let loginPage = {
    initialize,
    getView
};

export default loginPage;