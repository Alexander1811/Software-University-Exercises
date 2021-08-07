import { createTemplate } from "./createTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _teamsService = undefined;

function initialize(router, renderer, teamsService) {
    _router = router;
    _renderer = renderer;
    _teamsService = teamsService;
}

async function getView() {
    let form = { submitHandler };
    let templateResult = createTemplate(form);
    _renderer(templateResult);
}

async function submitHandler(e) {
    e.preventDefault();

    let form = e.target;
    let formData = new FormData(form);
    let team = {
        name: formData.get("name"),
        logoUrl: formData.get("logoUrl"),
        description: formData.get("description")
    }

    if (Object.values(team).some(field => field.trim() == "")) {
        form.errorMessage = "All fields are required!";
        return refreshPage(form);
    }

    let createResult = await _teamsService.createTeam(team);
    _router(`/details/${createResult._id}`);
}

function refreshPage(form) {
    form.submitHandler = submitHandler;
    let templateResult = createTemplate(form);
    _renderer(templateResult);
}

export default {
    getView,
    initialize
}