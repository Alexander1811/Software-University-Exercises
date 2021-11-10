function solve(x1, y1, x2, y2) {
    calculateDistance(x1, y1, 0, 0);
    calculateDistance(x2, y2, 0, 0);
    calculateDistance(x1, y1, x2, y2);

    function calculateDistance(x_1, y_1, x_2, y_2) {
        let distance = Math.sqrt(Math.pow((x_2 - x_1), 2) + Math.pow(y_2 - y_1, 2));

        if (Number.isInteger(distance)) {
            console.log(`{${x_1}, ${y_1}} to {${x_2}, ${y_2}} is valid`);
        }
        else {
            console.log(`{${x_1}, ${y_1}} to {${x_2}, ${y_2}} is invalid`);
        }
    }
}