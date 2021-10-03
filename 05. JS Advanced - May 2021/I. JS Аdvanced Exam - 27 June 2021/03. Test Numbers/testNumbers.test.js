let { assert, expect } = require("chai");

let testNumbers = require("./testNumbers");

describe("testNumbers", () => {
    describe("sumNumbers", () => {
        it("should throw error when one or both of the parameters is not a number", () => {
            assert.strictEqual(testNumbers.sumNumbers(2), undefined);
            assert.strictEqual(testNumbers.sumNumbers(2, "2"), undefined);
            assert.strictEqual(testNumbers.sumNumbers(2, true), undefined);
            assert.strictEqual(testNumbers.sumNumbers(2, [2]), undefined);
        });

        it("should return correct result when input is valid", () => {
            assert.strictEqual(testNumbers.sumNumbers(2, 2), (4).toFixed(2));
            assert.strictEqual(testNumbers.sumNumbers(-5.5, 2.5), (-3).toFixed(2));
            assert.strictEqual(testNumbers.sumNumbers(9, -3), (6).toFixed(2));
        });
    });

    describe("numberChecker", () => {
        it("should throw error when one or both of the parameters is not a number", () => {
            assert.throw(() => testNumbers.numberChecker(), "The input is not a number!");
            assert.throw(() => testNumbers.numberChecker("2A"), "The input is not a number!");
            assert.throw(() => testNumbers.numberChecker("NAN"), "The input is not a number!");
        });

        it("should return that the number is even", () => {
            assert.strictEqual(testNumbers.numberChecker(2), "The number is even!");
            assert.strictEqual(testNumbers.numberChecker(18), "The number is even!");
            assert.strictEqual(testNumbers.numberChecker(-4), "The number is even!");
        });

        it("should return that the number is odd", () => {
            assert.strictEqual(testNumbers.numberChecker(1), "The number is odd!");
            assert.strictEqual(testNumbers.numberChecker(17), "The number is odd!");
            assert.strictEqual(testNumbers.numberChecker(-5), "The number is odd!");
        });
    });

    describe("averageSumArray", () => {
        it("should return correct result when input is valid", () => {
            assert.strictEqual(testNumbers.averageSumArray([1, 2, 3, 4, 5, 6]), 21 / 6);
            assert.strictEqual(testNumbers.averageSumArray([7, 8, 9, 14, -5, -2.1, -5]), 25.9 / 7);
        });
    });
});
