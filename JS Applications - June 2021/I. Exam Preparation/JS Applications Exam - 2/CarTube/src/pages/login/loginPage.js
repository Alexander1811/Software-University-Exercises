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
    let form = { submitHandler };
    let templateResult = loginTemplate(form);
    _renderer(templateResult);
}

async function submitHandler(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let user = {
        username: formData.get("username"),
        password: formData.get("password")
    }

    if (Object.values(user).some(field => field.trim() == "")) {
        return alert("All fields are required!");
    }

    let loginResult = await _authService.login(user);
    _router("/all-listings");
}

export default {
    getView,
    initialize
}