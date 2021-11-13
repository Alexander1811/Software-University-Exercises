import notification from "../../notifications/notification.js";
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

    try {
        let form = e.target;
        let formData = new FormData(form);
        let user = {
            email: formData.get("email"),
            username: formData.get("username"),
            password: formData.get("password")
        }
        let repeatPassword = formData.get("repeatPass");

        if (Object.values(user).some(field => field.trim() == "")) {
            throw new Error("All fields are required!");
        }
        if (user.password != repeatPassword) {
            throw new Error("The passwords do not match!");
        }

        let registerResult = await _authService.register(user);
        _router("/meme-feed");
    }
    catch (err) {
        notification.displayError(err);
    }
}

export default {
    initialize,
    getView
}