import { notificationTemplate } from "./notificationTemplate.js";

let _renderer = undefined;
let errorBox = undefined;

function initialize(renderer, domErrorContainer) {
    _renderer = renderer;
    errorBox = domErrorContainer;
}

async function displayError(error) {
    let templateResult = notificationTemplate(error.message);
    _renderer(templateResult);
    errorBox.style.display = "block";

    setTimeout(function () {
        errorBox.style.display = "none";
    }, 3000);
}

export default {
    displayError,
    initialize
}