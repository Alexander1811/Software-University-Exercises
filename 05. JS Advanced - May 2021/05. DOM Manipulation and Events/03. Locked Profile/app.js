function lockedProfile() {
    let buttonElements = Array.from(document.querySelectorAll("#main .profile button"));

    buttonElements.forEach(el => {
        el.addEventListener("click", toggleButton);
    });

    function toggleButton(e) {
        let button = e.target;
        let profile = button.parentElement;
        let radioButton = profile.querySelector("input:checked");

        if (radioButton.value == "unlock") {
            let hiddenFieldElement = button.previousElementSibling;
            hiddenFieldElement.style.display = hiddenFieldElement.style.display == "block" ? "none" : "block";
            button.textContent = button.textContent == "Show more" ? "Hide it" : "Show more";
        }
    }
}