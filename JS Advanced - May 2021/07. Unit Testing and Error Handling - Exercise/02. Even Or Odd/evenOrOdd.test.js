let { expect } = require("chai");

let isOddOrEven = require("./evenOrOdd");

describe("isOddOrEven", () => {
    it("should return undefined when input is not string", () => {
        expect(isOddOrEven(1)).to.equal(undefined);
        expect(isOddOrEven(true)).to.equal(undefined);
        expect(isOddOrEven(undefined)).to.equal(undefined);
        expect(isOddOrEven(null)).to.equal(undefined);
    });

    it("should return even when string length is even", () => {
        expect(isOddOrEven("some")).to.equal("even");
        expect(isOddOrEven("no")).to.equal("even");
    });

    it("should return odd when string length is odd", () => {
        expect(isOddOrEven("hello")).to.equal("odd");
        expect(isOddOrEven("yes")).to.equal("odd");
    });
})