function solve(inputArray) {
    let productCatalogue = {};

    for (let i = 0; i < inputArray.length; i++) {
        let [productName, productPrice] = inputArray[i].split(" : ");
        productPrice = Number(productPrice);

        let initial = productName[0].toUpperCase();

        if (productCatalogue[initial] == undefined) {
            productCatalogue[initial] = {};
        }

        productCatalogue[initial][productName] = productPrice;
    }

    let resultArray = [];

    let initalsSorted = Object.keys(productCatalogue).sort((a, b) => a.localeCompare(b));

    for (const key of initalsSorted) {
        let products = Object.entries(productCatalogue[key]).sort((a, b) => a[0].localeCompare(b[0]));
        let productsAsStrings = products.map(x => `  ${x[0]}: ${x[1]}`).join('\n');

        resultArray.push(key);
        resultArray.push(productsAsStrings);

    }

    return resultArray.join('\n');
}