import { html } from "./../../../node_modules/lit-html/lit-html.js";

export let modalTemplate = (modal) => html`
<div class="overlay">
    <div class="modal">
        <p>${modal.message}</p>
        <a href="javascript:void(0)" class="action" @click=${(e) => modal.handler(true)}>Accept</a>
        <a href="javascript:void(0)" class="action" @click=${(e) => modal.handler(false)}>Decline</a>
    </div>
</div>`;

