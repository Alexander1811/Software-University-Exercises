function solution() {
    let supply = createMicroelementsObject(0, 0, 0, 0);

    let recipes = {
        apple() {
            supply.carbohydrate -= 1;
            supply.flavour -= 2;
        },
        lemonade() {
            supply.carbohydrate -= 10;
            supply.flavour -= 20;
        },
        burger() {
            supply.carbohydrate -= 5;
            supply.fat -= 7;
            supply.flavour -= 3;
        },
        eggs() {
            supply.protein -= 5;
            supply.fat -= 1;
            supply.flavour -= 1;
        },
        turkey() {
            supply.protein -= 10;
            supply.carbohydrate -= 10;
            supply.fat -= 10;
            supply.flavour -= 10;
        }
    }



    return function getInstructions(input) {
        let arguments = input.split(' ');
        let command = arguments[0];

        if (command == "restock") {
            let microelement = arguments[1]
            let quantity = Number(arguments[2]);

            supply[microelement] += quantity;

            return "Success";
        }
        else if (command == "prepare") {
            let recipe = arguments[1];
            let quantity = Number(arguments[2]);

            let stateBefore = Object.assign({}, supply);
            let stateAfter;

            for (let i = 0; i < quantity; i++) {

                recipes[recipe]();

                stateAfter = checkQuantity(supply);

                if (stateAfter.includes("Error")) {
                    supply = Object.assign({}, stateBefore);
                    break;
                }
            }

            return stateAfter;
        }
        else if (command == "report") {
            return `protein=${supply.protein} carbohydrate=${supply.carbohydrate} fat=${supply.fat} flavour=${supply.flavour}`;
        }
    }

    function checkQuantity(supply) {
        for (const [key, value] of Object.entries(supply)) {
            if (value < 0) {
                return `Error: not enough ${key} in stock`;
            }
        }

        return "Success";
    }

    function createMicroelementsObject(protein, carbohydrate, fat, flavour) {
        return {
            protein: protein,
            carbohydrate: carbohydrate,
            fat: fat,
            flavour: flavour
        }
    }
}