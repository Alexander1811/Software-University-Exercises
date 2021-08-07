import notification from "../../notifications/notification.js";
import { editTemplate } from "./editTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _memesService = undefined;

let memeId = undefined;

function initialize(router, renderer, memesService) {
    _router = router;
    _renderer = renderer;
    _memesService = memesService;
}

async function getView(context) {
    memeId = context.params.id;
    let form = { submitHandler };
    let meme = await _memesService.getMeme(memeId);
    let templateResult = editTemplate(form, meme);
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

        let updateResult = await _memesService.updateMeme(memeId, meme);
        _router(`/details/${memeId}`);
    }
    catch (err) {
        notification.displayError(err);
    }
}

export default {
    getView,
    initialize
}