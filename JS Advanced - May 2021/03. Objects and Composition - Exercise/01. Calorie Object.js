function solve(inputArray) {
    let calorieObject = {};
    for (let i = 0; i < inputArray.length; i += 2) {
        let key = inputArray[i];
        calorieObject[key] = Number(inputArray[i + 1]);
    }

    return calorieObject;
}