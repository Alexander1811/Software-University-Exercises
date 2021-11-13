import authService from "../../services/authService.js";
import { registerTemplate } from "./registerTemplate.js";

async function getView(context) {
    let boundSubmitHandler = submitHandler.bind(null, context);
    let form = {
        submitHandler: boundSubmitHandler
    }
    let templateResult = registerTemplate(form);
    context.renderView(templateResult);
}

async function submitHandler(context, e) {
    e.preventDefault();
    
    let form = e.target;
    let formData = new FormData(form);
    let user = {
        email: formData.get("email"),
        password: formData.get("password")
    }
    let repeatPassword = formData.get("rePass");

    if (user.email.trim() == "" || user.password.trim() == "" || repeatPassword.trim() == "") {
        return alert("All fields are required!");
    }
    if (user.password != repeatPassword) {
        form.reset();
        return alert("The passwords do not match!");
    }

    let registerResult = await authService.register(user);
    context.page.redirect("/dashboard");
}

export default {
    getView
}