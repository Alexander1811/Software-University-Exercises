let { assert } = require("chai");

let numberOperations = require("./numberOperations");

describe("numberOperations", () => {
    describe("powNumber", () => {
        it("should return correct result when input is valid", () => {
            assert.strictEqual(numberOperations.powNumber(2), 4);
            assert.strictEqual(numberOperations.powNumber(-5.5), -5.5 * -5.5);
            assert.strictEqual(numberOperations.powNumber(0), 0);
            assert.strictEqual(numberOperations.powNumber(9), 81);
        });
    });

    describe("numberCheck", () => {
        it("should return an error when input is not a number", () => {
            assert.throw(() => numberOperations.numberChecker("2A"), Error, "The input is not a number!");
            assert.throw(() => numberOperations.numberChecker(undefined), Error, "The input is not a number!");
            assert.throw(() => numberOperations.numberChecker([2, 7]), Error, "The input is not a number!");
        });

        it("should return that the number is lower than 100", () => {
            assert.strictEqual(numberOperations.numberChecker(0), "The number is lower than 100!");
            assert.strictEqual(numberOperations.numberChecker(-23), "The number is lower than 100!");
            assert.strictEqual(numberOperations.numberChecker(35.8), "The number is lower than 100!");
            assert.strictEqual(numberOperations.numberChecker(99.99), "The number is lower than 100!");
        });

        it("should return that the number is equal or more than 100", () => {
            assert.strictEqual(numberOperations.numberChecker(100), "The number is greater or equal to 100!");
            assert.strictEqual(numberOperations.numberChecker(101), "The number is greater or equal to 100!");
            assert.strictEqual(numberOperations.numberChecker(231), "The number is greater or equal to 100!");
            assert.strictEqual(numberOperations.numberChecker(555.55), "The number is greater or equal to 100!");
        });
    });

    describe("sumArrays", () => {
        it("should return result correctly", () => {
            assert.deepEqual(numberOperations.sumArrays([-2, 3, 4], [2, 4, 5]), ([0, 7, 9]));
            assert.deepEqual(numberOperations.sumArrays([12, 3.5, 4], [2, 8.5, 5, 3, 4, 5]), ([14, 12, 9, 3, 4, 5]));
            assert.deepEqual(numberOperations.sumArrays([0, 3, 4, 2.1], [21, 43.3]), ([21, 46.3, 4, 2.1]));
        });
    });
});