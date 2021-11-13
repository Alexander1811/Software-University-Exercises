function solve(carsArray) {
    let carBrandsMap = new Map();

    for (let i = 0; i < carsArray.length; i++) {
        let [carBrand, carModel, producedCars] = carsArray[i].split(" | ");
        producedCars = Number(producedCars);

        if (!carBrandsMap.has(carBrand)) {
            let carModels = new Map();
            carBrandsMap.set(carBrand, carModels);
        }

        let carModelsMap = carBrandsMap.get(carBrand);

        if (!carModelsMap.has(carModel)) {
            carModelsMap.set(carModel, 0);
        }

        let totalCars = carModelsMap.get(carModel) + producedCars;

        carModelsMap.set(carModel, totalCars);
    }

    for (const brand of carBrandsMap.keys()) {
        console.log(brand);
        let carModelsMap = carBrandsMap.get(brand);
        for (const model of carModelsMap.keys()) {
            console.log(`###${model} -> ${carModelsMap.get(model)}`);
        }
    }
}