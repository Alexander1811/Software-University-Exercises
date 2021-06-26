function solve() {
   let createButton = document.querySelector("aside > section > form > button.create");
   createButton.addEventListener("click", createPostHandler);

   function createPostHandler(e) {
      e.preventDefault();

      let creatorElement = document.querySelector("#creator");
      let titleElement = document.querySelector("#title");
      let categoryElement = document.querySelector("#category");
      let contentElement = document.querySelector("#content");

      let title = titleElement.value;
      let creator = creatorElement.value;
      let category = categoryElement.value;
      let content = contentElement.value;

      let article = document.createElement("article");

      let headerElement = document.createElement("h1");
      headerElement.textContent = title;

      let creatorP = document.createElement("p");
      creatorP.textContent = "Creator:";
      let creatorTextStrong = document.createElement("strong");
      creatorTextStrong.textContent = creator;
      creatorP.appendChild(creatorTextStrong);

      let categoryP = document.createElement("p");
      categoryP.textContent = "Category:";
      let categoryTextStrong = document.createElement("strong");
      categoryTextStrong.textContent = category;
      categoryP.appendChild(categoryTextStrong);

      let contentP = document.createElement("p");
      contentP.textContent = content;

      let buttonsDiv = document.createElement("div");
      buttonsDiv.classList.add("buttons");

      let deleteButton = document.createElement("button");
      deleteButton.textContent = "Delete";
      deleteButton.classList.add("btn", "delete");
      deleteButton.addEventListener("click", deletePostHandler)

      let archiveButton = document.createElement("button");
      archiveButton.textContent = "Archive";
      archiveButton.classList.add("btn", "archive");
      archiveButton.addEventListener("click", archivePostHandler)

      buttonsDiv.appendChild(deleteButton);
      buttonsDiv.appendChild(archiveButton);

      article.appendChild(headerElement);
      article.appendChild(categoryP);
      article.appendChild(creatorP);
      article.appendChild(contentP);
      article.appendChild(buttonsDiv);

      let sectionElement = document.querySelector(".site-content > main > section");

      sectionElement.appendChild(article);
   }

   function archivePostHandler(e) {
      let olElement = document.querySelector(".archive-section > ol");
      
      let articleElement = e.target.parentElement.parentElement;
      let titleElement = articleElement.querySelector("h1");
      let title = titleElement.textContent;

      let liElement = document.createElement("li");
      liElement.textContent = title;

      let archiveLis = Array.from(olElement.querySelectorAll("li"));
      archiveLis.push(liElement);
      archiveLis
         .sort((a, b) => a.textContent.localeCompare(b.textContent))
         .forEach(li => olElement.appendChild(li));

      articleElement.remove();
   }

   function deletePostHandler(e) {
      let articleElement = e.target.parentElement.parentElement;
      articleElement.remove();
   }
}
