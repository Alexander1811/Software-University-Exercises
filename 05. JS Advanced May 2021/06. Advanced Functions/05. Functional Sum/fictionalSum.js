function add(num) {
    let sum = 0;

    function updateSum(number) {
        sum += number;
        return updateSum;
    }

    updateSum.toString = () => { return sum; };

    return updateSum(num);
}