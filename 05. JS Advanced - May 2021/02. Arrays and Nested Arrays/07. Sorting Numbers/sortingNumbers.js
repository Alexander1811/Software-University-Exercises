function solve(numbersArray) {
    numbersArray.sort((a, b) => a - b).reverse();

    let resultArray = [];

    while (numbersArray.length > 0) {
        resultArray.push(numbersArray.pop());
        if (numbersArray.length > 0) {
            resultArray.push(numbersArray.shift());
        }
    }

    return resultArray;
}