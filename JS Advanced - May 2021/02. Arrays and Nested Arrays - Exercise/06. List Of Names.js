function solve(namesArray) {
    let resultArray = [];
    namesArray.sort((a, b) => a.toLowerCase().localeCompare(b.toLowerCase()));

    for (let i = 0; i < namesArray.length; i++) {
        resultArray.push(`${i + 1}.${namesArray[i]}`);
    }

    console.log(resultArray.join("\n"));
}