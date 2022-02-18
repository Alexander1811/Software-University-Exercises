function solve(numbers, argument) {
    return argument == "asc"
        ? numbers.sort((a, b) => Number(a) - Number(b))
        : numbers.sort((a, b) => Number(b) - Number(a));
}