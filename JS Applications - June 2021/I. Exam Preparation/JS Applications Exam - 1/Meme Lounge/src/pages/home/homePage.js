import { homeTemplate } from "./homeTemplate.js";

let _router = undefined;
let _renderer = undefined;

function initialize(router, renderer) {
    _router = router;
    _renderer = renderer;
}

async function getView() {
    let templateResult = homeTemplate();
    _renderer(templateResult);
}

export default {
    initialize,
    getView
}