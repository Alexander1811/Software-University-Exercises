function solve(stringsArray, rotations) {   
    for (let i = 0; i < rotations; i++) {
        stringsArray.unshift(stringsArray.pop());
    }

    console.log(stringsArray.join(' '));
}