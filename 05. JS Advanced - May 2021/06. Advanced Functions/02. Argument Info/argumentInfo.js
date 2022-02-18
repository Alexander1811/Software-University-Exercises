function solve(...params) {
    let summary = [];
    let tally = {};

    getInput();

    printOutput();

    function getInput() {
        params.forEach(el => {
            let type = typeof (el);

            summary.push(`${type}: ${el}`);
            
            tally[type] = tally[type] != undefined ? tally[type] += 1 : 1;
        });
    }

    function printOutput() {
        summary.forEach(el => {
            console.log(el);
        });

        let result = []
        Object.keys(tally)
            .sort((a, b) => tally[b] - tally[a])
            .forEach(key => result.push(`${key} = ${tally[key]}`));

        console.log(result.join('\n'));
    }
}