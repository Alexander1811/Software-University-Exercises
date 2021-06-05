function solve(number, operation1, operation2, operation3, operation4, operation5) {
    number = applyOperation(number, operation1);
    console.log(number);
    number = applyOperation(number, operation2);
    console.log(number);
    number = applyOperation(number, operation3);
    console.log(number);
    number = applyOperation(number, operation4);
    console.log(number);
    number = applyOperation(number, operation5);
    console.log(number);

    function applyOperation(number, operation) {
        switch (operation) {
            case "chop":
                number /= 2;
                break;
            case "dice":
                number = Math.sqrt(number);
                break;
            case "spice":
                number++;
                break;
            case "bake":
                number *= 3;
                break;
            case "fillet":
                number *= 0.8;
                break;
        }

        return number;
    }
}