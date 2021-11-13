function solve(numbersArray) {
    let biggestNumber = 0;
    let resultArray = [];

    for (let i = 0; i < numbersArray.length; i++) {
        let currentElement = numbersArray[i];

        if (currentElement >= biggestNumber) {
            biggestNumber = currentElement;
            resultArray.push(biggestNumber);
        }
        else {
            continue;
        }
    }

    return resultArray;
}