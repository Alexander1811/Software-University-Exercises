let { assert, expect } = require("chai");

let pizzUni = require("./pizza");

describe("pizzUni", () => {
    describe("makeAnOrder", () => {
        it("should throw error when pizza is not ordered", () => {
            let obj = {
                orderedPizza: undefined,
                orderedDrink: undefined
            };

            assert.throw(() => pizzUni.makeAnOrder(obj), "You must order at least 1 Pizza to finish the order.")
        });

        it("should return correct output if only pizza is ordered", () => {
            let obj = {
                orderedPizza: "Neapolitan",
                orderedDrink: undefined
            };

            assert.deepEqual(pizzUni.makeAnOrder(obj), `You just ordered ${obj.orderedPizza}`)
        });

        it("should return correct output if only pizza is ordered", () => {
            let obj = {
                orderedPizza: "Neapolitan",
                orderedDrink: "Pepsi"
            };

            assert.deepEqual(pizzUni.makeAnOrder(obj), `You just ordered ${obj.orderedPizza} and ${obj.orderedDrink}.`)
        });
    });

    describe("getRemainingWork", () => {
        it("should return array of all not ready pizzas when there are such", () => {
            let statusArr = [{ pizzaName: "Sicilian", status: "ready" },
            { pizzaName: "Italian", status: "preparing" },
            { pizzaName: "Quattro Formaggi", status: "preparing" }];

            assert.deepEqual(pizzUni.getRemainingWork(statusArr), "The following pizzas are still preparing: Italian, Quattro Formaggi.");
        });
        it("should return that all orders are complete when all pizzas are ready", () => {
            let statusArr = [{ pizzaName: "Sicilian", status: "ready" },
            { pizzaName: "Italian", status: "ready" },
            { pizzaName: "Quattro Formaggi", status: "ready" }];

            assert.deepEqual(pizzUni.getRemainingWork(statusArr), "All orders are complete!");
        });
        it("should return that all orders are complete when there are no pizzas", () => {
            let statusArr = [];

            assert.deepEqual(pizzUni.getRemainingWork(statusArr), "All orders are complete!");
        });
    });

    describe("orderType", () => {
        it("should return correct sum with discount when order is carry out", () => {
            assert.deepEqual(pizzUni.orderType(100, "Carry Out"), 100 * 0.9);
            assert.deepEqual(pizzUni.orderType(254.5, "Carry Out"), 254.5 * 0.9);
        });
        it("should return correct sum when order is delivery", () => {
            assert.deepEqual(pizzUni.orderType(100, "Delivery"), 100);
            assert.deepEqual(pizzUni.orderType(254.5, "Delivery"), 254.5);
        });
    });
});
