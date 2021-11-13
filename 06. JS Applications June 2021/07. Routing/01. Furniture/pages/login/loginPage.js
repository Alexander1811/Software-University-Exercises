import authService from "../../services/authService.js";
import { loginTemplate } from "./loginTemplate.js";

async function getView(context) {
    let boundSubmitHandler = submitHandler.bind(null, context);
    let form = {
        submitHandler: boundSubmitHandler
    }
    let templateResult = loginTemplate(form);
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

    if (user.email.trim() == "" || user.password.trim() == "") {
        return alert("All fields are required!");
    }

    let loginResult = await authService.login(user);
    context.page.redirect("/dashboard");
}

export default {
    getView
}