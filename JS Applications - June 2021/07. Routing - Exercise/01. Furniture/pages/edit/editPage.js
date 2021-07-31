import furnitureService from "../../services/furnitureService.js";
import { editTemplate } from "./editTemplate.js";

async function getView(context) {
    let id = context.params.id;
    let editedItem = await furnitureService.getItem(id);
    let boundSubmitHandler = submitHandler.bind(null, context);
    form = {
        submitHandler: boundSubmitHandler,
        values: {
            make: editedItem.make,
            model: editedItem.model,
            year: editedItem.year,
            description: editedItem.description,
            price: editedItem.price,
            img: editedItem.img,
            material: editedItem.material
        },
        invalidFields: {
            make: false,
            model: false,
            year: false,
            description: false,
            price: false,
            img: false
        }
    }
    let templateResult = editTemplate(form);
    context.renderView(templateResult);
}

let form = undefined;
async function submitHandler(context, e) {
    e.preventDefault();
    let id = context.params.id;

    let formData = new FormData(e.target);
    let editedItem = {
        make: formData.get("make"),
        model: formData.get("model"),
        year: Number(formData.get("year")),
        description: formData.get("description"),
        price: Number(formData.get("price")),
        img: formData.get("img"),
        material: formData.get("material")
    }

    form.invalidFields = {};

    if (editedItem.make.length < 4) {
        form.invalidFields.make = true;
    }
    if (editedItem.model.length < 4) {
        form.invalidFields.model = true;
    }
    if (editedItem.year < 1950 || editedItem.year > 2050) {
        form.invalidFields.year = true;
    }
    if (editedItem.description.length < 10) {
        form.invalidFields.description = true;
    }
    if (editedItem.price <= 0) {
        form.invalidFields.price = true;
    }
    if (editedItem.img.trim() == "") {
        form.invalidFields.img = true;
    }

    if (Object.keys(form.invalidFields).length > 0) {
        let templateResult = editTemplate(form);
        context.renderView(templateResult);
    }
    else {
        let editResult = await furnitureService.updateItem(id, editedItem);
        context.page.redirect("/dashboard")
    }
}

export default {
    getView
}