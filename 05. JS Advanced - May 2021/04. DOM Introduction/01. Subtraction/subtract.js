function subtract() {
    let num1Element = document.getElementById("firstNumber").value;
    let num2Element = document.getElementById("secondNumber").value;

    let num1 = Number(num1Element);
    let num2 = Number(num2Element);

    let result = num1 - num2;

    let resultDiv = document.getElementById("result");
    resultDiv.textContent = result;
}