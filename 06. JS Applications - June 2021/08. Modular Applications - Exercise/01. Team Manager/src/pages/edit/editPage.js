import { editTemplate } from "./editTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _teamsService = undefined;

let teamId = undefined;

function initialize(router, renderer, teamsService) {
    _router = router;
    _renderer = renderer;
    _teamsService = teamsService;
}

async function getView(context) {
    teamId = context.params.id;
    let form = { submitHandler };
    let team = await _teamsService.getTeam(teamId);
    let templateResult = editTemplate(form, team);
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
        return refreshPage(form, team);
    }

    let updateResult = await _teamsService.updateTeam(teamId, team);
    _router(`/details/${updateResult._id}`);
}

function refreshPage(form, team) {
    form.submitHandler = submitHandler;
    let templateResult = editTemplate(form, team);
    _renderer(templateResult);
}

export default {
    getView,
    initialize
}