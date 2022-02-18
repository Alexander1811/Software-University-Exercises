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
    let form = {
        submitHandler
    };
    let templateResult = registerTemplate(form);
    _renderer(templateResult);
}

async function submitHandler(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let user = {
        email: formData.get("email"),
        username: formData.get("username"),
        password: formData.get("password")
    }
    let repeatPassword = formData.get("repass");

    if (user.email.trim() == "" || user.password.trim() == "" || repeatPassword.trim() == "") {
        form.errorMessage = "All fields are required!";
        return refreshPage(form);
    }
    if (user.password != repeatPassword) {
        form.errorMessage = "The passwords do not match!";
        return refreshPage(form);
    }

    let registerResult = await _authService.register(user);
    _router("/home");
}

function refreshPage(form) {
    form.submitHandler = submitHandler;
    let templateResult = registerTemplate(form);
    _renderer(templateResult);
}

export default {
    initialize,
    getView
}