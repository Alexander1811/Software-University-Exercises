import modal from "../modal/modal.js";
import { detailsTemplate } from "./detailsTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _teamsService = undefined;
let _membersService = undefined;

let userMembership = undefined;

function initialize(router, renderer, teamsService, membersService) {
    _router = router;
    _renderer = renderer;
    _teamsService = teamsService;
    _membersService = membersService;
}

async function getView(context) {
    let id = context.params.id;
    let user = context.user;
    let team = await _teamsService.getTeam(id);
    let people = await _membersService.getPeopleInTeam(id);
    team.members = people.filter(person => person.status == "member");
    team.pendings = people.filter(person => person.status == "pending");
    if (team.members.length == 0) { _router("/browse-teams"); }
    let status = getStatus(user, team, people);
    let handlers = { joinHandler, approveHandler, cancelHandler, leaveHandler, declineHandler, removeHandler };
    let templateResult = detailsTemplate(team, status, handlers);
    _renderer(templateResult);
}

function getStatus(user, team, people) {
    if (user != undefined) {
        if (user._id == team._ownerId) {
            return "owner";
        }
        else {
            userMembership = people.find(person => person._ownerId == user._id);
            if (userMembership == undefined) {
                return "nonMember";
            }
            else if (userMembership.status == "member") {
                return "member";
            }
            else if (userMembership.status == "pending") {
                return "pending";
            }
        }
    }
    else {
        return "guest";
    }
}

async function joinHandler(e) {
    let teamId = e.target.closest("article").dataset.teamId;
    await _membersService.joinTeam(teamId);
    _router(`/details/${teamId}`);
}

async function approveHandler(e) {
    let teamId = e.target.closest("article").dataset.teamId;
    let memberId = e.target.parentElement.id;
    await _membersService.approveMember(memberId);
    _router(`/details/${teamId}`);
}

async function cancelHandler(e) {
    let modalResult = await modal.createModal("Are you sure you want to cancel your request?");

    if (modalResult) {
        let teamId = e.target.closest("article").dataset.teamId;
        let memberId = userMembership._id;
        await _membersService.cancelRequest(memberId);
        _router(`/details/${teamId}`);
    }
}

async function leaveHandler(e) {
    let modalResult = await modal.createModal("Are you sure you want to leave?");

    if (modalResult) {
        let teamId = e.target.closest("article").dataset.teamId;
        let memberId = userMembership._id;
        await _membersService.leaveTeam(memberId);
        _router(`/details/${teamId}`);
    }
}

async function declineHandler(e) {
    let modalResult = await modal.createModal("Are you sure you want to decline this member\' request to join?");

    if (modalResult) {
        let teamId = e.target.closest("article").dataset.teamId;
        let memberId = e.target.parentElement.id;
        await _membersService.declineRequest(memberId);
        _router(`/details/${teamId}`);
    }
}

async function removeHandler(e) {
    let modalResult = await modal.createModal("Are you sure you want to remove this member?");

    if (modalResult) {
        let teamId = e.target.closest("article").dataset.teamId;
        let memberId = e.target.parentElement.id;
        await _membersService.removeMember(memberId);
        _router(`/details/${teamId}`);
    }
}

export default {
    initialize,
    getView
}