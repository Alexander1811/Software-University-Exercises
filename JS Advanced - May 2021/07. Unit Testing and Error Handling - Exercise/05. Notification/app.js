function notify(message) {
  let notificationDiv = document.querySelector("#notification");
  
  notificationDiv.textContent = message;
  notificationDiv.style.display = "block";

  notificationDiv.addEventListener("click", (e) => {
    e.target.style.display = "none";
  });
}