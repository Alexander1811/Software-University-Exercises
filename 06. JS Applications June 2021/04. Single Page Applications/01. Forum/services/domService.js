function createNestedElement(tag, attributes, ...params) {
    let element = document.createElement(tag);
    let firstValue = params[0];

    if (params.length == 1 && typeof (firstValue) != "object") {
        if (["input", "textarea"].includes(tag)) {
            element.value = firstValue;
        }
        else {
            element.textContent = firstValue;
        }
    }
    else {
        element.append(...params);
    }

    if (attributes != undefined) {
        Object.keys(attributes).forEach(key => {
            element.setAttribute(key, attributes[key]);
        });
    }

    return element;
}

let timeFormats = {
    getHomepagePostTimeFormat: () => { return new Date().toISOString() },
    getTopicPagePostTimeFormat: (date) => { return date.replaceAll(/T|Z/g, ' ').split('.')[0] },
    getCommentTimeFormat: () => { return new Date().toLocaleString("en-US") }
}

let domService = {
    createNestedElement,
    timeFormats
}

export default domService;