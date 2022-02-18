function solve(matrix = [[]]) {
    let isMagical = true;

    for (let row = 0; row < matrix.length && isMagical; row++) {
        let currentRow = matrix[row];
        let rowSum = currentRow.reduce((a, b) => a + b, 0);
        for (let col = 0; col < currentRow.length; col++) {
            let currentCol = getCol(matrix, col);
            let colSum = currentCol.reduce((a, b) => a + b, 0);

            if (rowSum != colSum) {
                isMagical = false;
                break;
            }
        }
    }

    return isMagical;

    function getCol(matrix, col) {
        let column = [];
        for (let i = 0; i < matrix.length; i++) {
            column.push(matrix[i][col]);
        }

        return column;
    }
}