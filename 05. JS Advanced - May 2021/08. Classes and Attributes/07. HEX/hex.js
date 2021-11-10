class Hex {
    constructor(decimalNumber) {
        this.value = Number(decimalNumber);
    }

    valueOf() {
        return this.value;
    }

    toString() {
        return `0x${(this.value.toString(16)).toUpperCase()}`;
    }

    plus(number) {
        let result = (this.value + Number(number.valueOf()));
        return new Hex(result);
    }

    minus(number) {
        let result = (this.value - Number(number.valueOf()));
        return new Hex(result);
    }

    parse(hex) {
        return parseInt(hex, 16);
    }
}
