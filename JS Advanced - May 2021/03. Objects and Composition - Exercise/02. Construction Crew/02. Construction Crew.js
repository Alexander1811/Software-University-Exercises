function solve(worker) {
    let weight = worker.weight; 
    let experience = worker.experience;
    let levelOfHydrated = worker.levelOfHydrated;
    let dizziness = worker.dizziness;

    if (dizziness == true) {
        let requiredAmountOfWater = 0.1 * weight * experience;

        worker.levelOfHydrated += requiredAmountOfWater;
        worker.dizziness = false;
    }

    return worker;
}

console.log(solve({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}
))