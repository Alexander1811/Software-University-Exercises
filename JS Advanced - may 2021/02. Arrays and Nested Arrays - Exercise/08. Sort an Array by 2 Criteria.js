function solve(stringsArray) {
    stringsArray.sort((a, b) => {
        if (a.length < b.length) {
            return -1;
        }
        else if (a.length == b.length) {
            return a.toLowerCase().localeCompare(b.toLowerCase());
        }
        else if (a.length > b.length) {
            return 1;
        }
    });

    console.log(stringsArray.join("\n"));
}