function solve() {
    let onScreenButton = document.querySelector("#container button");
    onScreenButton.addEventListener("click", onScreenHandler);

    let clearButton = document.querySelector("#archive > button");
    clearButton.addEventListener("click", clearHandler);

    function onScreenHandler(e) {
        e.preventDefault();

        let movieInputs = document.querySelectorAll("#container input");
        let nameInput = movieInputs[0];
        let hallInput = movieInputs[1];
        let priceInput = movieInputs[2];

        let name = nameInput.value;
        let hall = hallInput.value;
        let price = priceInput.value;

        if (name.trim() == "" || hall.trim() == "" || price.trim() == "" || isNaN(Number(price))) {
            return;
        }
        else {
            price = Number(priceInput.value).toFixed(2);
        }

        let li = document.createElement("li");

        let nameSpan = document.createElement("span");
        nameSpan.textContent = name;

        let hallStrong = document.createElement("strong");
        hallStrong.textContent = `Hall: ${hall}`;

        let rightSectonDiv = document.createElement("div");

        let priceStrong = document.createElement("strong");
        priceStrong.textContent = price;

        let ticketsSoldInput = document.createElement("input");
        ticketsSoldInput.setAttribute("placeholder", "Tickets Sold");

        let archiveButton = document.createElement("button");
        archiveButton.textContent = "Archive";
        archiveButton.addEventListener("click", archiveHandler);

        rightSectonDiv.appendChild(priceStrong);
        rightSectonDiv.appendChild(ticketsSoldInput);
        rightSectonDiv.appendChild(archiveButton);

        li.appendChild(nameSpan);
        li.appendChild(hallStrong);
        li.appendChild(rightSectonDiv);

        let moviesUl = document.querySelector("#movies ul");
        moviesUl.appendChild(li);

        hallInput.value = "";
        priceInput.value = "";
        nameInput.value = "";
    }

    function archiveHandler(e) {
        let movieLi = e.target.parentElement.parentElement;

        let ticketsSoldInput = movieLi.querySelector("div input");
        let ticketsSold = ticketsSoldInput.value;

        if (ticketsSold.trim() == "" || isNaN(Number(ticketsSold))) {
            return;
        }
        else {
            ticketsSold = Number(ticketsSold);
        }

        let priceStrong = movieLi.querySelector("div strong");
        let price = Number(priceStrong.textContent);

        let hallStrong = movieLi.querySelector("strong");
        let totalPrice = price * ticketsSold;
        hallStrong.textContent = `Total amount: ${totalPrice.toFixed(2)}`;

        let rightSectionDiv = movieLi.querySelector("div");
        rightSectionDiv.remove();

        let deleteButton = document.createElement("button");
        deleteButton.textContent = "Delete";
        deleteButton.addEventListener("click", deleteHandler);

        movieLi.appendChild(deleteButton);

        let archiveUl = document.querySelector("#archive ul");
        archiveUl.appendChild(movieLi);
    }

    function deleteHandler(e) {
        let movieLi = e.target.parentElement;
        movieLi.remove();
    }

    function clearHandler() {
        let archiveLis = Array.from(document.querySelectorAll("#archive ul li"));
        archiveLis.forEach(li => li.remove());
    }
}