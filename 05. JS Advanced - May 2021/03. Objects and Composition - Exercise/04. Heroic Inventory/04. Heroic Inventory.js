function solve(inputArray) {
    let heroesArray = [];

    for (let i = 0; i < inputArray.length; i++) {
        let [name, level, items] = inputArray[i].split(' / ');
        level = Number(level);
        items = items != undefined ? items.split(", ") : [];

        heroesArray.push({ name: name, level: level, items: items });
    }

    return JSON.stringify(heroesArray);
}