import { profileTemplate } from "./profileTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _authService = undefined;
let _memesService = undefined;

function initialize(router, renderer, authService, memesService) {
    _router = router;
    _renderer = renderer;
    _authService = authService;
    _memesService = memesService;
}

async function getView() {
    let user = _authService.getUser();
    user.memes = await _memesService.getMyMemes(user._id);
    let templateResult = profileTemplate(user);
    _renderer(templateResult);
}

export default {
    initialize, 
    getView
}