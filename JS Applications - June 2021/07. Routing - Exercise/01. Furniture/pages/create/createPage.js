import furnitureService from "../../services/furnitureService.js";
import { createTemplate } from "./createTemplate.js";

async function getView(context) {
    let boundSubmitHandler = submitHandler.bind(null, context);
    form = {
        submitHandler: boundSubmitHandler,
        invalidFields: {
            make: true,
            model: true,
            year: true,
            description: true,
            price: true,
            img: true
        }
    }
    let templateResult = createTemplate(form);
    context.renderView(templateResult);
}

let form = undefined;
async function submitHandler(context, e) {
    e.preventDefault();

    let formData = new FormData(e.target);
    let newItem = {
        make: formData.get("make"),
        model: formData.get("model"),
        year: Number(formData.get("year")),
        description: formData.get("description"),
        price: Number(formData.get("price")),
        img: formData.get("img"),
        material: formData.get("material")
    }

    form.invalidFields = {};

    if (newItem.make.length < 4) {
        form.invalidFields.make = true;
    }
    if (newItem.model.length < 4) {
        form.invalidFields.model = true;
    }
    if (newItem.year < 1950 || newItem.year > 2050) {
        form.invalidFields.year = true;
    }
    if (newItem.description.length < 10) {
        form.invalidFields.description = true;
    }
    if (newItem.price <= 0) {
        form.invalidFields.price = true;
    }
    if (newItem.img.trim() == "") {
        form.invalidFields.img = true;
    }

    if (Object.keys(form.invalidFields).length > 0) {
        let templateResult = createTemplate(form);
        context.renderView(templateResult);
    }
    else {
        let createResult = await furnitureService.createItem(newItem);
        context.page.redirect("/dashboard");
    }
}

export default {
    getView
}