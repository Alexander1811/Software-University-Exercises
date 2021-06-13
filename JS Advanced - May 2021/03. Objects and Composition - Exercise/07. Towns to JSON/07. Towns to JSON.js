function solve(inputArray) {
    let titles = serializeRow(inputArray[0]);
    let rows = inputArray.slice(1).map(row => serializeRow(row).reduce(accumulateIntoObject, {}));

    return JSON.stringify(rows);

    function serializeRow(str) {
        return str.split(/\s*\|\s*/gim).filter(x => x != '').map(x => parseNumber(x));
    }

    function parseNumber(num) {
        return isNaN(Number(num)) ? num : Number(Number(num).toFixed(2));
    }

    function accumulateIntoObject(obj, el, i) {
        obj[titles[i]] = el;
        return obj;
    }
}