function solve() {
  let textAreaElement = document.getElementById("input");

  let text = textAreaElement.value;
  let sentences = text.split('.').filter(x => x.length > 0).map(x => x + '.');

  let resultDiv = document.getElementById("output");

  let paragraphsCount = Math.ceil(sentences.length / 3);

  for (let i = 0; i < paragraphsCount; i++) {
    resultDiv.innerHTML += `<p>${sentences.splice(0, 3).join('')}</p>`;
  }
}