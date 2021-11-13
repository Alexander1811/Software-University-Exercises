function solve(juicesArray) {
    let juicesAmount = new Map();
    let juicesBottles = new Map();

    for (let i = 0; i < juicesArray.length; i++) {
        let [juiceName, juiceQuantity] = juicesArray[i].split(" => ");
        juiceQuantity = Number(juiceQuantity);
        
        if (!juicesAmount.has(juiceName)) {
            juicesAmount.set(juiceName, 0);
        }

        let totalQuantity = juicesAmount.get(juiceName) + juiceQuantity;

        if (totalQuantity >= 1000) {
            if (!juicesBottles.has(juiceName)) {
                juicesBottles.set(juiceName, 0);
            }

            let newBottles = Math.trunc(totalQuantity / 1000);
            let totalBottles = juicesBottles.get(juiceName) + newBottles;
            juicesBottles.set(juiceName, totalBottles);
        }

        juicesAmount.set(juiceName, totalQuantity % 1000);
    }

    console.log([...juicesBottles].map(([key, value]) => `${key} => ${value}`).join('\n'));
}