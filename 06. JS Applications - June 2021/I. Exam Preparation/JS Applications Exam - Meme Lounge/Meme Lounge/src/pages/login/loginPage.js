import notification from "../../notifications/notification.js";
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

    try {
        let form = e.target;
        let formData = new FormData(form);
        let user = {
            email: formData.get("email"),
            password: formData.get("password")
        }

        if (Object.values(user).some(field => field.trim() == "")) {
            throw new Error("All fields are required!");
        }

        let loginResult = await _authService.login(user);
        _router("/meme-feed");
    }
    catch (err) {
        notification.displayError(err);
    }
}

export default {
    getView,
    initialize
}