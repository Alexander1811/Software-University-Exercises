import { feedTemplate } from "./feedTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _memesService = undefined;

function initialize(router, renderer, memesService) {
    _router = router;
    _renderer = renderer;
    _memesService = memesService;
}

async function getView() {
    let memes = await _memesService.getAllMemes();
    let templateResult = feedTemplate(memes);
    _renderer(templateResult);
}

export default {
    initialize,
    getView
}