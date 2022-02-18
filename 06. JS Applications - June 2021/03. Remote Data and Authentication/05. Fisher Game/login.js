let registerForm = document.querySelector("#register-form");
registerForm.addEventListener("submit", registerHandler);

let loginForm = document.querySelector("#login-form");
loginForm.addEventListener("submit", loginHandler);

let url = "http://localhost:3030/users";

async function registerHandler(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let newUser = {
        email: formData.get("email"),
        password: formData.get("password")
    }

    if (!newUser.email || !newUser.password) {
        return alert("All fields are required!");
    }
    if (newUser.password != formData.get("rePass")) {
        return alert("Passwords don\'t match");
    }

    let registerResponse = await fetch(`${url}/register`, {
        headers: { "Content-Type": "application/json" },
        method: "Post",
        body: JSON.stringify(newUser)
    });

    let registerResult = await registerResponse.json();

    if (registerResponse.ok) {
        localStorage.setItem("token", registerResult.accessToken);
        localStorage.setItem("userId", registerResult._id);
        localStorage.setItem("email", registerResult.email);
        location.assign("./index.html");
    }
    else {
        alert(`Cannot register! ${registerResult.message}.`);
        window.location.reload();
    }
}

async function loginHandler(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let newUser = {
        email: formData.get("email"),
        password: formData.get("password")
    }

    if (!newUser.email || !newUser.password) {
        return alert("All fields are required!");
    }

    let loginResponse = await fetch(`${url}/login`, {
        headers: { "Content-Type": "application/json" },
        method: "Post",
        body: JSON.stringify(newUser)
    });

    let loginResult = await loginResponse.json();

    if (loginResponse.ok) {
        localStorage.setItem("token", loginResult.accessToken);
        localStorage.setItem("userId", loginResult._id);
        localStorage.setItem("email", loginResult.email);
        location.assign("./index.html");
    }
    else {
        alert("Cannot login! You are not registered or your password is invalid.");
        window.location.reload();
    }
}

function validateInput(email, password) {
    return email.trim() == "" || password.trim() == "";
}