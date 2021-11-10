function solve(fruit, weightInGrams, pricePerKilogram) {
    let weight = weightInGrams / 1000;
    let money = weight * pricePerKilogram;

    console.log(`I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}