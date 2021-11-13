function attachEvents() {
    let sendButton = document.querySelector("#submit");
    sendButton.addEventListener("click", createMessageHandler);

    let refreshButton = document.querySelector("#refresh");
    refreshButton.addEventListener("click", getAllMessagesHandler)

    let url = "http://localhost:3030/jsonstore/messenger";

    async function getAllMessagesHandler() {
        let getAllMessagesRequest = await fetch(url);
        let messages = await getAllMessagesRequest.json();

        let textarea = document.querySelector("#messages");

        textarea.value = Object.values(messages)
            .map(message => `${message.author}: ${message.content}`)
            .join('\n');

    }

    async function createMessageHandler() {
        let newMessage = {
            author: document.querySelector("#author").value,
            content: document.querySelector("#content").value
        }

        if (newMessage.author == "" || newMessage.content == "") {
            return alert("All fields are required!");
        }

        let createResponse = await fetch(url, {
            headers: { "Content-Type": "application/json" },
            method: "Post",
            body: JSON.stringify(newMessage)
        });

        if (!createResponse.ok) {
            return alert("Cannot send message!");
        }
    }
}

attachEvents();