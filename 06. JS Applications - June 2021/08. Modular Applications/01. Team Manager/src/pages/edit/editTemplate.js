import { html, nothing } from "./../../../node_modules/lit-html/lit-html.js";

export let editTemplate = (form, team) => html`
<section id="edit">
    <article class="narrow">
        <header class="pad-med">
            <h1>Edit Team</h1>
        </header>
        <form id="edit-form" class="main-form pad-large" @submit=${form.submitHandler}>
            ${form.errorMessage != undefined ? html`<div class="error">${form.errorMessage}</div>` : nothing}
            <label>Team name: <input type="text" name="name" value=${team.name}></label>
            <label>Logo URL: <input type="text" name="logoUrl" value=${team.logoUrl}></label>
            <label>Description: <textarea name="description">${team.description}</textarea></label>
            <input class="action cta" type="submit" value="Save Changes">
        </form>
    </article>
</section>`;