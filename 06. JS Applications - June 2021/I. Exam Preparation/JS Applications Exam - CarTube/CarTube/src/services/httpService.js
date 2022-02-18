import authService from "./authService.js";

export async function jsonRequest(url, method, body, isAuthorized, skipResult) {
    try {
        if (method == undefined) {
            method = "Get";
        }

        let headers = {};
        if (["post", "put", "patch"].includes(method.toLowerCase())) {
            headers["Content-Type"] = "application/json";
        }
        if (isAuthorized) {
            headers["X-Authorization"] = authService.getUser().accessToken;
        }

        let options = {
            headers,
            method
        }

        if (body != undefined) {
            options.body = JSON.stringify(body);
        }

        let response = await fetch(url, options);
        if (!response.ok) {
            let messageText = await response.text();
            throw new Error(`${JSON.parse(messageText).message}`);
        }
        if (!skipResult) {
            let result = await response.json();
            return result;
        }
    }
    catch (err) {
        return alert(err);
    }
}