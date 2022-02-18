function solve(httpObject) {
    validateMethod(httpObject);
    validateUri(httpObject);
    validateVersion(httpObject);
    validateMessage(httpObject);

    return httpObject;

    function validateMethod(httpObject) {
        let validMethods = ["GET", "POST", "DELETE", "CONNECT"];
        let propertyName = "method";
        let methodName = httpObject[propertyName];

        if (!validMethods.includes(methodName)) {
            throw new Error("Invalid request header: Invalid Method");
        }
    }

    function validateUri(httpObject) {
        let validResourceAddressRegex = /^\*$|^[\w.]+$/;
        let propertyName = "uri";
        let uriAddress = httpObject[propertyName];

        if (uriAddress == undefined || !validResourceAddressRegex.test(uriAddress)) {
            throw new Error("Invalid request header: Invalid URI");
        }
    }

    function validateVersion(httpObject) {
        let validVersions = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"];
        let propertyName = "version";
        let versionName = httpObject[propertyName];

        if (!validVersions.includes(versionName)) {
            throw new Error("Invalid request header: Invalid Version");
        }
    }

    function validateMessage(httpObject) {
        let validMessageRegex = /^[^<>\\\&'"]*$/;
        let propertyName = "message";
        let messageContent = httpObject[propertyName];

        if (messageContent == undefined || !validMessageRegex.test(messageContent)) {
            throw new Error("Invalid request header: Invalid Message");
        }
    }
}