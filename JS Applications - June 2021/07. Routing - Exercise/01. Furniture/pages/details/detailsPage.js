import authService from "../../services/authService.js";
import furnitureService from "../../services/furnitureService.js";
import { detailsTemplate } from "./detailsTemplate.js";

async function getView(context) {
    let id = context.params.id;    
    let item = await furnitureService.getItem(id);
    item.img = item.img.startsWith('.') ? item.img.substring(1) : item.img;
    let isOwner = authService.getUserId() == item._ownerId;
    let boundDeleteHandler = deleteHandler.bind(null, context, id);
    let templateResult = detailsTemplate(item, boundDeleteHandler, isOwner);
    context.renderView(templateResult);
}

async function deleteHandler(context, id) {
    if (confirm("Are you sure you want to delete this item?")) {
        await furnitureService.deleteItem(id);
        context.page.redirect("/dashboard");
    }
}

export default {
    getView
}