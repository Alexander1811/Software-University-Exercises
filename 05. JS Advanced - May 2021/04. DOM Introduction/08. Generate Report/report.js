function generateReport() {

    let tableElements = document.getElementsByTagName('table')[0];
    let tableHeaders = tableElements.querySelector('thead tr');
    let tableBody = tableElements.querySelector('tbody');

    let checkedHeadersIndicesAndColumnData = getCheckedHeadersIndexesAndColumnData(tableHeaders);

    let cellsData = getCellsData(checkedHeadersIndicesAndColumnData, tableBody);

    let outputElement = document.querySelector('#output');
    outputElement.value = JSON.stringify(cellsData);

    function getCheckedHeadersIndexesAndColumnData(tableHeaders) {
        let columnData = [];

        for (let i = 0; i < tableHeaders.cells.length; i++) {
            if (tableHeaders.children[i].firstElementChild.checked) {
                let columnIndexAndContent = { [i]: tableHeaders.children[i].textContent.toLowerCase().trim() };
                columnData.push(columnIndexAndContent);
            }
        }

        return columnData;
    }

    function getCellsData(checkedHeadersIndicesAndColumnData, tableBody) {
        let cellsData = [];

        let rows = tableBody.children;

        for (let row = 0; row < rows.length; row++) {
            let object = {};

            let currentRow = rows[row];

            let cols = currentRow.children;

            for (let col = 0; col < cols.length; col++) {
                checkedHeadersIndicesAndColumnData.forEach(el => {
                    let keyIndex = Number(Object.keys(el)[0]);
                    let valueContent = Object.values(el)[0];

                    if (keyIndex == col) {
                        object[valueContent] = cols[col].textContent;
                    };
                });
            }

            cellsData.push(object);
        }

        return cellsData;
    }
}