import { detailsTemplate } from "./detailsTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _authService = undefined;
let _memesService = undefined;

let memeId = undefined;
let userId = undefined;

function initialize(router, renderer, authService, memesService) {
    _router = router;
    _renderer = renderer;
    _authService = authService;
    _memesService = memesService;
}

async function getView(context) {
    memeId = context.params.id;
    let meme = await _memesService.getMeme(memeId);
    let ownerId = meme._ownerId;
    let user = await _authService.getUser();
    if (user != undefined) {
        userId = user._id;
    }
    let isOwner = ownerId == userId;
    let buttons = { deleteHandler };
    let templateResult = detailsTemplate(meme, isOwner, buttons);
    _renderer(templateResult);
}

async function deleteHandler() {
    if (confirm("Are you sure you want to delete this meme?")) {
        let deleteResult = await _memesService.deleteMeme(memeId);
        _router("/meme-feed");
    }
}

export default {
    initialize,
    getView
}