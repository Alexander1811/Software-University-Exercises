function solve(input) {
    let model = input.model;

    let power = Number(input.power);
    let volume = 0;

    if (power <= 90) {
        power = 90;
        volume = 1800;
    }
    else if (power <= 120) {
        power = 120;
        volume = 2400;
    }
    else if (power <= 200) {
        power = 200;
        volume = 3500;
    }

    let engine = { power, volume };

    let color = input.color;
    let type = input.carriage;

    let carriage = { type, color };

    let wheelsize = input.wheelsize % 2 != 0 ? input.wheelsize : input.wheelsize - 1;
    let wheels = [wheelsize, wheelsize, wheelsize, wheelsize];

    let car = { model, engine, carriage, wheels };

    return car;
}