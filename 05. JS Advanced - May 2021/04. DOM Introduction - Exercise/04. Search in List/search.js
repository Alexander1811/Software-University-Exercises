function search() {
   let searchElement = document.getElementById("searchText");
   let allLiElements = Array.from(document.querySelectorAll("#towns li"));

   let searchText = searchElement.value;

   allLiElements.forEach(el => {
      el.style.fontWeight = "normal";
      el.style.textDecoration = "none";
   });

   let targetLis = allLiElements
      .filter(el => el.textContent.includes(searchText))
      .map(el => {
         el.style.fontWeight = "bold";
         el.style.textDecoration = "underline";
      });

   let resultDiv = document.getElementById("result");
   resultDiv.textContent = `${targetLis.length} matches found`;
}
