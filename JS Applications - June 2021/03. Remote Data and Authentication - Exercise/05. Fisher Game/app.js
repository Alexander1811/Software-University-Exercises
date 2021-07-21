let loginElement = document.querySelector("#guest");
let logoutElement = document.querySelector("#user");
let userEmail = document.querySelector("#userEmail");
logoutElement.addEventListener("click", logout);

let catchesContainer = document.querySelector("#catches");
catchesContainer.querySelectorAll(".catch").forEach(x => x.remove());

let loadButton = document.querySelector("#home-view aside .load");
loadButton.addEventListener("click", getCatchesHandler);

let addButton = document.querySelector("#addForm .add");
addButton.addEventListener("click", createCatchHandler);

checkIfUserIsLogged();

let url = "http://localhost:3030/data/catches";

async function getCatchesHandler() {
    catchesContainer.querySelectorAll(".catch").forEach(x => x.remove());

    let getCatchesResponse = await fetch(url);
    let catches = await getCatchesResponse.json();

    catchesContainer.append(...catches.map(c => createCatchDiv(c)));
}

async function createCatchHandler() {
    let form = document.querySelector("#addForm");

    let anglerInput = form.querySelector(".angler");
    let weightInput = form.querySelector(".weight");
    let speciesInput = form.querySelector(".species");
    let locationInput = form.querySelector(".location");
    let baitInput = form.querySelector(".bait");
    let captureTimeInput = form.querySelector(".captureTime");

    let newCatch = {
        angler: anglerInput.value,
        weight: Number(weightInput.value),
        species: speciesInput.value,
        location: locationInput.value,
        bait: baitInput.value,
        captureTime: Number(captureTimeInput.value)
    };

    if (validateInput(newCatch)) {
        return alert("All fields are required!");
    }

    let createResponse = await fetch(url, {
        headers: {
            "Content-Type": "application/json",
            "X-Authorization": localStorage.getItem("token")
        },
        method: "Post",
        body: JSON.stringify(newCatch)
    });

    if (!createResponse.ok) {
        return alert("Cannot add catch!");
    }

    let createResult = await createResponse.json();
    let createdCatch = createCatchDiv(createResult);
    catchesContainer.appendChild(createdCatch);

    getCatchesHandler();
}

async function updateCatchHandler(e) {
    let currentCatch = e.target.parentElement;

    let anglerInput = currentCatch.querySelector(".angler");
    let weightInput = currentCatch.querySelector(".weight");
    let speciesInput = currentCatch.querySelector(".species");
    let locationInput = currentCatch.querySelector(".location");
    let baitInput = currentCatch.querySelector(".bait");
    let captureTimeInput = currentCatch.querySelector(".captureTime");

    let updatedCatch = {
        angler: anglerInput.value,
        weight: Number(weightInput.value),
        species: speciesInput.value,
        location: locationInput.value,
        bait: baitInput.value,
        captureTime: Number(captureTimeInput.value)
    };

    if (validateInput(updatedCatch)) {
        return alert("All fields are required!");
    }

    let id = currentCatch.dataset.id;
    let updateResponse = await fetch(`${url}/${id}`, {
        headers: {
            "Content-Type": "application/json",
            "X-Authorization": localStorage.getItem("token")
        },
        method: "Put",
        body: JSON.stringify(updatedCatch)
    });

    if (!updateResponse.ok) {
        return alert("Cannot update catch!");
    }
}

async function deleteCatchHandler(e) {
    let currentCatch = e.target.parentElement;

    let id = currentCatch.dataset.id;
    let deleteResponse = await fetch(`${url}/${id}`, {
        headers: { "X-Authorization": localStorage.getItem("token") },
        method: "Delete"
    });

    if (!deleteResponse.ok) {
        return alert("Cannot delete catch!");
    }

    currentCatch.remove();
}

function createCatchDiv(currentCatch) {
    let anglerLable = createNestedElement("label", undefined, "Angler");
    let anglerInput = createNestedElement("input", { type: "text", class: "angler" }, currentCatch.angler);
    let hr1 = createNestedElement("hr");

    let weightLabel = createNestedElement("label", undefined, "Weight");
    let weightInput = createNestedElement("input", { type: "number", class: "weight" }, currentCatch.weight);
    let hr2 = createNestedElement("hr");

    let speciesLabel = createNestedElement("label", undefined, "Species");
    let speciesInput = createNestedElement("input", { type: "text", class: "species" }, currentCatch.species);
    let hr3 = createNestedElement("hr");

    let locationLabel = createNestedElement("label", undefined, "Location");
    let locationInput = createNestedElement("input", { type: "text", class: "location" }, currentCatch.location);
    let hr4 = createNestedElement("hr");

    let baitLabel = createNestedElement("label", undefined, "Bait");
    let baitInput = createNestedElement("input", { type: "text", class: "bait" }, currentCatch.bait);
    let hr5 = createNestedElement("hr");

    let captureTimeLabel = createNestedElement("label", undefined, "Capture Time");
    let captureTimeInput = createNestedElement("input", { type: "number", class: "captureTime" }, currentCatch.captureTime);
    let hr6 = createNestedElement("hr");

    let updateBtn = createNestedElement("button", { disabled: true, class: "update" }, "Update");
    updateBtn.addEventListener("click", updateCatchHandler);
    updateBtn.disabled = localStorage.getItem("userId") !== currentCatch._ownerId;

    let deleteBtn = createNestedElement("button", { disabled: true, class: "delete" }, "Delete");
    deleteBtn.addEventListener("click", deleteCatchHandler);
    deleteBtn.disabled = localStorage.getItem("userId") !== currentCatch._ownerId;

    let catchDiv = createNestedElement("div", { class: "catch" },
        anglerLable, anglerInput, hr1,
        weightLabel, weightInput, hr2,
        speciesLabel, speciesInput, hr3,
        locationLabel, locationInput, hr4,
        baitLabel, baitInput, hr5,
        captureTimeLabel, captureTimeInput, hr6,
        updateBtn, deleteBtn);
    catchDiv.dataset.id = currentCatch._id;
    catchDiv.dataset.ownerId = currentCatch._ownerId;

    return catchDiv;
}

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

async function logout() {
    let token = localStorage.getItem("token");

    await fetch("http://localhost:3030/users/logout", {
        headers: { "X-Authorization": token },
        method: "Get"
    });

    localStorage.removeItem("token");
    localStorage.removeItem("userId");
    localStorage.removeItem("email");

    checkIfUserIsLogged();

    getCatchesHandler();
}

function checkIfUserIsLogged() {
    if (localStorage.getItem("token") == null) {
        addButton.disabled = true;
        loginElement.style.display = "inline-block";
        logoutElement.style.display = "none";
        userEmail.textContent = "guest";
    }
    else {
        addButton.disabled = false;
        loginElement.style.display = "none";
        logoutElement.style.display = "inline-block";
        userEmail.textContent = localStorage.getItem("email");
    }
}

function validateInput(catchInput) {
    let input = [catchInput.angler, catchInput.weight, catchInput.species, catchInput.location, catchInput.bait, catchInput.captureTime];
    return input.includes("") || input.includes(0);
}

