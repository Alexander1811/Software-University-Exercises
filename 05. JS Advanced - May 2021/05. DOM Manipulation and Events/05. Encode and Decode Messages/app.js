function encodeAndDecodeMessages() {
    let messageElement = document.querySelector("textarea[placeholder=\"Write your message here...\"]");
    let receivedMessageElement = document.querySelector("textarea[placeholder=\"No messages...\"]");

    let encodeButton = document.querySelectorAll("button")[0];
    let decodeButton = document.querySelectorAll("button")[1];

    let caeserShift = 1;

    encodeButton.addEventListener("click", () => {
        let encodedText = messageElement.value
            .split('')
            .map(x => String.fromCharCode(x.charCodeAt(0) + caeserShift))
            .join('');

        receivedMessageElement.textContent = encodedText;
        messageElement.value = "";
    });

    decodeButton.addEventListener("click", () => {
        let decodedText = receivedMessageElement.value
            .split('')
            .map(x => String.fromCharCode(x.charCodeAt(0) - caeserShift))
            .join('');

        receivedMessageElement.textContent = decodedText;
    });
}