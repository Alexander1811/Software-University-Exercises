import { browseTemplate } from "./browseTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _teamsService = undefined;
let _membersService = undefined;

function initialize(router, renderer, teamsService, membersService) {
    _router = router;
    _renderer = renderer;
    _teamsService = teamsService;
    _membersService = membersService;
}

async function getView(context) {
    let user = context.user;
    let viewModel = {
        isLoggedIn: user != undefined,
        teams: await _teamsService.getAllTeams()
    }
    let allMembers = await _membersService.getAllMembers();
    viewModel.teams.forEach(team => team.membersCount = allMembers.filter(member => member.teamId == team._id).length);
    let templateResult = browseTemplate(viewModel);
    _renderer(templateResult);
}

export default {
    initialize,
    getView
}