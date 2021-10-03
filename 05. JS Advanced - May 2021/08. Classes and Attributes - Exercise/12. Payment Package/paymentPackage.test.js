let { expect } = require("chai");

let PaymentPackage = require("./paymentPackage");

describe("PaymentPackage", () => {
    describe("name", () => {
        let package;
        beforeEach(() => {
            package = new PaymentPackage("Consultation", 100);
        });

        it("should get the name correctly when input is valid", () => {
            expect(package.name).to.equal("Consultation");
        });
        it("should set the name correctly when input is valid", () => {
            package.name = "Partnership";
            expect(package.name).to.equal("Partnership");
        });
        it("should throw error when input is not string", () => {
            expect(() => package.name = 2).to.throw("Name must be a non-empty string");
            expect(() => package.name = true).to.throw("Name must be a non-empty string");
            expect(() => package.name = undefined).to.throw("Name must be a non-empty string");
            expect(() => package.name = null).to.throw("Name must be a non-empty string");
        });
        it("should throw error when string is empty", () => {
            expect(() => package.name = "").to.throw("Name must be a non-empty string");
        });
    });

    describe("value", () => {
        let package;
        beforeEach(() => {
            package = new PaymentPackage("Consultation", 100);
        });

        it("should get the value correctly when input is valid", () => {
            expect(package.value).to.equal(100);
        });
        it("should set the value correctly when input is valid", () => {
            package.value = 135;
            expect(package.value).to.equal(135);
        });
        it("should throw error when input is not number", () => {
            expect(() => package.value = "2").to.throw("Value must be a non-negative number");
            expect(() => package.value = true).to.throw("Value must be a non-negative number");
            expect(() => package.value = undefined).to.throw("Value must be a non-negative number");
            expect(() => package.value = null).to.throw("Value must be a non-negative number");
        });
        it("should throw error when value is less than 0", () => {
            expect(() => package.value = -10).to.throw("Value must be a non-negative number");
        });
    });

    describe("VAT", () => {
        let package;
        beforeEach(() => {
            package = new PaymentPackage("Consultation", 100);
        });

        it("should get the default VAT correctly when input is valid", () => {
            expect(package.VAT).to.equal(20);
        });
        it("should set the VAT correctly when input is valid", () => {
            package.VAT = 120;
            expect(package.VAT).to.equal(120);
        });
        it("should throw error when input is not number", () => {
            expect(() => package.VAT = "2").to.throw("VAT must be a non-negative number");
            expect(() => package.VAT = true).to.throw("VAT must be a non-negative number");
            expect(() => package.VAT = undefined).to.throw("VAT must be a non-negative number");
            expect(() => package.VAT = null).to.throw("VAT must be a non-negative number");
        });
        it("should throw error when VAT is less than 0", () => {
            expect(() => package.VAT = -10).to.throw("VAT must be a non-negative number");
        });
    });

    describe("active", () => {
        let package;
        beforeEach(() => {
            package = new PaymentPackage("Consultation", 100);
        });

        it("should get the default active status correctly when input is valid", () => {
            expect(package.active).to.equal(true);
        });
        it("should set the active status correctly when input is valid", () => {
            package.active = false;
            expect(package.active).to.equal(false);
        });
        it("should throw error when input is not booleans", () => {
            expect(() => package.active = "2").to.throw("Active status must be a boolean");
            expect(() => package.active = 13).to.throw("Active status must be a boolean");
            expect(() => package.active = undefined).to.throw("Active status must be a boolean");
            expect(() => package.active = null).to.throw("Active status must be a boolean");
        });
        it("should throw error when active status is not boolean", () => {
            expect(() => package.active = -10).to.throw("Active status must be a boolean");
        });
    });

    describe("toString", () => {
        let package;
        beforeEach(() => {
            package = new PaymentPackage("Consultation", 100);
        });

        it("should work correctly when properties are changed", () => {
            expect(package.toString()).to.equal("Package: Consultation\n- Value (excl. VAT): 100\n- Value (VAT 20%): 120");
            package.name = "HR Services";

            expect(package.toString()).to.equal("Package: HR Services\n- Value (excl. VAT): 100\n- Value (VAT 20%): 120");
            package.value = 520;
            package.VAT = 45;

            expect(package.toString()).to.equal("Package: HR Services\n- Value (excl. VAT): 520\n- Value (VAT 45%): 754");

            package.active = false;
            expect(package.toString()).to.equal("Package: HR Services (inactive)\n- Value (excl. VAT): 520\n- Value (VAT 45%): 754");
        });
    });
})