import { registerTemplate } from "./registerTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _authService = undefined;

function initialize(router, renderer, authService) {
    _router = router;
    _renderer = renderer;
    _authService = authService;
}

async function getView() {
    let form = { submitHandler };
    let templateResult = registerTemplate(form);
    _renderer(templateResult);
}

async function submitHandler(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let user = {
        email: formData.get("email"),
        password: formData.get("password")
    }
    let repeatPassword = formData.get("confirm-pass");

    if (Object.values(user).some(field => field.trim() == "")) {
        return alert("All fields are required!");
    }
    if (user.password != repeatPassword) {
        return alert("The passwords do not match!");
    }

    let registerResult = await _authService.register(user);
    _router("/dashboard");
}

export default {
    initialize,
    getView
}