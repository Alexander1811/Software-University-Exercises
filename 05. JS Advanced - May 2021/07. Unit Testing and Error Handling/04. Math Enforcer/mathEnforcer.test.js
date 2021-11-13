let { expect } = require("chai");

let mathEnforcer = require("./mathEnforcer");

describe("mathEnforcer", () => {
    describe("addFive", () => {
        it("should return correct number when input is valid", () => {
            expect(mathEnforcer.addFive(4)).to.equal(9);
            expect(mathEnforcer.addFive(-4)).to.equal(1);
            expect(mathEnforcer.addFive(1.999)).to.equal(1.999 + 5);
        });

        it("should return undefined when input is not valid", () => {
            expect(mathEnforcer.addFive("5")).to.equal(undefined);
            expect(mathEnforcer.addFive([5])).to.equal(undefined);
            expect(mathEnforcer.addFive(true)).to.equal(undefined);
            expect(mathEnforcer.addFive(undefined)).to.equal(undefined);
            expect(mathEnforcer.addFive(null)).to.equal(undefined);
        });
    });

    describe("subtractTen", () => {
        it("should return correct number when input is valid", () => {
            expect(mathEnforcer.subtractTen(4)).to.equal(-6);
            expect(mathEnforcer.subtractTen(-2)).to.equal(-12);
            expect(mathEnforcer.subtractTen(10.001)).to.equal(10.001 - 10);
        });

        it("should return undefined when input is not valid", () => {
            expect(mathEnforcer.subtractTen("5")).to.equal(undefined);
            expect(mathEnforcer.subtractTen([5])).to.equal(undefined);
            expect(mathEnforcer.subtractTen(true)).to.equal(undefined);
            expect(mathEnforcer.subtractTen(undefined)).to.equal(undefined);
            expect(mathEnforcer.subtractTen(null)).to.equal(undefined);
        });
    });

    describe("sum", () => {
        it("should return correct sum when both numbers are valid", () => {
            expect(mathEnforcer.sum(2, -8)).to.equal(-6);
            expect(mathEnforcer.sum(0, 0)).to.equal(0);
            expect(mathEnforcer.sum(-5, -5)).to.equal(-10);
            expect(mathEnforcer.sum(10.0001, 1.009)).to.equal(10.0001 + 1.009);
        });

        it("should return undefined when one or both numbers are not valid", () => {
            expect(mathEnforcer.sum("6", 3)).to.equal(undefined);
            expect(mathEnforcer.sum([])).to.equal(undefined);
            expect(mathEnforcer.sum([6, 6])).to.equal(undefined);
            expect(mathEnforcer.sum(0, null)).to.equal(undefined);
            expect(mathEnforcer.sum(["", "4"])).to.equal(undefined);
            expect(mathEnforcer.sum(true, 0)).to.equal(undefined);
        });
    });
});