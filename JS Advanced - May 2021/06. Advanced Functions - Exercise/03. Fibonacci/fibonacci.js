function getFibonator() {
    let previous = 0, current = 1, next;

    return function () {
        next = previous + current;
        previous = current;
        current = next;
        return previous;
    }
}