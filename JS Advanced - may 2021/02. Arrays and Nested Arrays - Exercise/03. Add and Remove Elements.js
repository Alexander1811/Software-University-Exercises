function solve(commandsArray) {
    let resultArray = [];
    let number = 0;

    for (let i = 0; i < commandsArray.length; i++) {
        let command = commandsArray[i];
        
        number++;

        if (command == "add") {
            resultArray.push(number);
        }
        else if (command == "remove") {
            resultArray.pop();
        }
    }

    if (resultArray.length > 0) {
        resultArray.forEach(element => console.log(element));
    }
    else {
        console.log("Empty");
    }
}