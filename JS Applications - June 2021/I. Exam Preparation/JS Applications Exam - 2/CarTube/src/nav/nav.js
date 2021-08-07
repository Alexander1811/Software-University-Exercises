import { navTemplate } from "./navTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _authService = undefined;

function initialize(router, renderer, authService) {
    _router = router;
    _renderer = renderer;
    _authService = authService;
}

async function getView(context, next) {
    let user = context.user;
    let viewModel = {
        isLoggedIn: user != undefined,
        username: user != undefined ? user.username : undefined,
        logoutHandler: logoutHandler
    }
    let templateResult = navTemplate(viewModel);
    _renderer(templateResult);
    next();
}

async function logoutHandler() {
    await _authService.logout();
    _router("/home");
}

export default {
    initialize,
    getView
}