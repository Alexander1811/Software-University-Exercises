import { loginTemplate } from "./loginTemplate.js";

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
    let templateResult = loginTemplate(form);
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

    if (user.email.trim() == "" || user.password.trim() == "") {
        form.errorMessage = "All fields are required!";
        return refreshPage(form);
    }

    let loginResult = await _authService.login(user);
    _router("/home");
}

function refreshPage(form) {
    form.submitHandler = submitHandler;
    let templateResult = loginTemplate(form);
    _renderer(templateResult);
}

export default {
    getView,
    initialize
}