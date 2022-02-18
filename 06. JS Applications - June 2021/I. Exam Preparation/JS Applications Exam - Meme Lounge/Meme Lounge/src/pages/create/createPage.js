import notification from "../../notifications/notification.js";
import { createTemplate } from "./createTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _memesService = undefined;

function initialize(router, renderer, memesService) {
    _router = router;
    _renderer = renderer;
    _memesService = memesService;
}

async function getView() {
    let form = { submitHandler };
    let templateResult = createTemplate(form);
    _renderer(templateResult);
}

async function submitHandler(e) {
    e.preventDefault();

    try {
        let form = e.target;
        let formData = new FormData(form);
        let meme = {
            title: formData.get("title"),
            description: formData.get("description"),
            imageUrl: formData.get("imageUrl")
        }

        if (Object.values(meme).some(field => field.trim() == "")) {
            throw new Error("All fields are required!");
        }

        let createResult = await _memesService.createMeme(meme);
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