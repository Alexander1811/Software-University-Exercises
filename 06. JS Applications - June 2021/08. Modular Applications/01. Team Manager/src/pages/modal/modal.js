import { modalTemplate } from "./modelTemplate.js";

let _router = undefined;
let _renderer = undefined;

function initialize(router, renderer) {
    _router = router;
    _renderer = renderer;
}

async function createModal(message) {
    let modal = {
        message
    }
    let promise = new Promise((resolve, reject) => {
        modal.handler = (value) => {
            _renderer(null);
            resolve(value);
        };
    })
    let templateResult = modalTemplate(modal);
    _renderer(templateResult);

    return promise;
}

export default {
    initialize,
    createModal
}