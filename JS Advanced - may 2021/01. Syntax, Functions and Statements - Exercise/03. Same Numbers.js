function solve(number) {
    let numberString = String(number)
    let isRepeating = true;
    let sum = Number(numberString[0]);

    for (let i = 0; i < numberString.length - 1; i++) {
        let currentDigit = Number(numberString[i]);
        let nextDigit = Number(numberString[i + 1]);

        if (currentDigit != nextDigit) {
            isRepeating = false;
        }

        sum += nextDigit;
    }

    console.log(isRepeating);
    console.log(sum);
}