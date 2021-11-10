function solve(inputArray, step) {
    let filteredArray = inputArray.filter((element, i) => i % step === 0);
    
    return filteredArray;
}