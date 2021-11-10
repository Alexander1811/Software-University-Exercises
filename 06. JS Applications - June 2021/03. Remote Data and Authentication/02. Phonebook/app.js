function attachEvents() {
    let phonebookUl = document.querySelector("#phonebook");

    let loadButton = document.querySelector("#btnLoad");
    loadButton.addEventListener("click", loadContactsHandler);

    let createButton = document.querySelector("#btnCreate");
    createButton.addEventListener("click", createContactHandler);

    let url = "http://localhost:3030/jsonstore/phonebook";

    async function loadContactsHandler() {
        phonebookUl.querySelectorAll("li").forEach(li => li.remove());

        let contactsRequest = await fetch(url);
        let contacts = await contactsRequest.json();

        Object.values(contacts).forEach(contact => {
            let contactLi = createContactLi(contact);
            
            phonebookUl.appendChild(contactLi);
        });
    }

    async function createContactHandler() {
        let newContact = {
            person: document.querySelector("#person").value,
            phone: document.querySelector("#phone").value
        }

        if (validateInputAndClearFields(newContact.person, newContact.phone)) {
            return alert("All fields are required!");
        }

        let createResponse = await fetch(url, {
            headers: { "Content-Type": "application/json" },
            method: "Post",
            body: JSON.stringify(newContact)
        });

        if (!createResponse.ok) {
            return alert("Cannot add contact!");
        }

        loadContactsHandler();
    }

    async function deleteContactHandler(e) {
        let id = e.target.id;

        let deleteResponse = await fetch(`${url}/${id}`, {
            headers: { "Content-type": "application/json" },
            method: "Delete"
        });

        if (!deleteResponse.ok) {
            return alert("Cannot delete contact!");
        }

        e.target.parentElement.remove();
    }

    function createContactLi(contact) {
        let contactLi = document.createElement("li");
        contactLi.textContent = `${contact.person}: ${contact.phone}`;

        let deleteButton = document.createElement("button");
        deleteButton.textContent = "Delete";
        deleteButton.setAttribute("id", contact._id);
        deleteButton.addEventListener("click", deleteContactHandler);

        contactLi.appendChild(deleteButton);

        return contactLi;
    }

    function validateInputAndClearFields(personInput, phoneInput) {
        if (personInput.value.trim() == "" || phoneInput.value.trim() == "") {
            personInput.value = "";
            phoneInput.value = "";

            return true;
        }
        else {
            personInput.value = "";
            phoneInput.value = "";

            return false;
        }
    }
}

attachEvents();