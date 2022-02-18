import { html, nothing } from "./../../../node_modules/lit-html/lit-html.js";

let memberTemplate = (member, status, handlers) => html`
<li id=${member._id}>${member.user.username}
    ${status == "owner" ? html`<a href="javascript:void(0)" class="tm-control action" @click=${handlers.removeHandler}>Remove from team</a>` : nothing}
</li>`

let pendingTemplate = (pending, status, handlers) => html`
<li id=${pending._id}>${pending.user.username}
    ${status == "owner" ? html`
    <a href="javascript:void(0)" class="tm-control action" @click=${handlers.approveHandler}>Approve</a>
    <a href="javascript:void(0)" class="tm-control action" @click=${handlers.declineHandler}>Decline</a>`
    : nothing}
</li>`;

let allMembersTemplate = (members, status, handlers) => html`
<ul class="tm-members">
    <li>My Username</li>
    ${members.map(member => memberTemplate(member, status, handlers))}
</ul>`;

let allPendingsTemplate = (pendings, status, handlers) => html`
<ul class="tm-members">
    ${pendings.map(pending => pendingTemplate(pending, status, handlers))}
</ul>`;

export let detailsTemplate = (team, status, handlers) => html`
<section id="team-home">
    <article data-team-id=${team._id} class="layout">
        <img src=${team.logoUrl} class="team-logo left-col">
        <div class="tm-preview">
            <h2>${team.name}</h2>
            <p>${team.description}</p>
            <span class="details">${team.members.length} Members</span>
            <div>
                ${status == "owner" ? html`<a href="/edit/${team._id}" class="action">Edit team</a>` : nothing}
                ${status == "member" ? html` <a href="javascript:void(0)" class="action invert" @click=${handlers.leaveHandler}>Leave team</a>` : nothing}
                ${status == "pending" ? html` Membership pending. <a href="javascript:void(0)" @click=${handlers.cancelHandler}>Cancel request</a>` : nothing}
                ${status == "nonMember" ? html` <a href="javascript:void(0)" class="action" @click=${handlers.joinHandler}>Join team</a>` : nothing}
            </div>
        </div>
        ${team.members.length > 0 
        ? html`
        <div class="pad-large">
            <h3>Members</h3>
            ${allMembersTemplate(team.members, status, handlers)}
        </div>`
        : nothing}
        ${team.pendings.length > 0 
        ? html`
       <div class="pad-large">
            <h3>Membership Requests</h3>
            ${allPendingsTemplate(team.pendings, status, handlers)}
        </div>`
        : nothing}        
    </article>
</section>`;