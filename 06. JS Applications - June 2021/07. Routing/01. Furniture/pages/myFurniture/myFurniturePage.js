import authService from "../../services/authService.js";
import furnitureService from "../../services/furnitureService.js";
import { allMyFurniture } from "./myFurnitureTemplate.js";

async function getView(context) {
    let userId = authService.getUserId();
    let items = await furnitureService.getMyFurniture(userId);
    let templateResult = allMyFurniture(items);
    context.renderView(templateResult);
}

export default {
    getView
}