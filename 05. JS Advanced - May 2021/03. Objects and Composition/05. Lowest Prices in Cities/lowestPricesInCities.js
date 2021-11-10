function solve(inputArray) {
    let products = {};

    for (let i = 0; i < inputArray.length; i++) {
        let [townName, productName, productPrice] = inputArray[i].split(" | ");
        productPrice = Number(productPrice);

        if (!products.hasOwnProperty(productName)) {
            products[productName] = {};
        }

        products[productName][townName] = productPrice;
    }

    let resultArray = [];

    for (const key in products) {
        let townWithLowestPrice = Object.entries(products[key]).sort((a, b) => a[1] - b[1])[0];

        let townName = townWithLowestPrice[0];
        let productLowestPrice = townWithLowestPrice[1];

        resultArray.push(`${key} -> ${productLowestPrice} (${townName})`)
    }

    return resultArray.join('\n');
}