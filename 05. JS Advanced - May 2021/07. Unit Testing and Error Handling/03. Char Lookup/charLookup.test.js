let { expect } = require("chai");

let lookupChar = require("./charLookup");

describe("lookupChar", () => {
    it("should return undefined when string is not valid", () => {
        expect(lookupChar(2, 2)).to.equal(undefined);
        expect(lookupChar(true, 2)).to.equal(undefined);
        expect(lookupChar(undefined, 2)).to.equal(undefined);
        expect(lookupChar(null, 2)).to.equal(undefined);        
    });

    it("should return undefined when index is not valid", () => {
        expect(lookupChar("string", 2.10)).to.equal(undefined);    
        expect(lookupChar("string", "string")).to.equal(undefined);    
        expect(lookupChar("string", true)).to.equal(undefined);    
        expect(lookupChar("string", undefined)).to.equal(undefined);    
        expect(lookupChar("string", null)).to.equal(undefined);    
    });

    it("should return incorrect index message when index is not in range", () => {
        expect(lookupChar("string", 6)).to.equal("Incorrect index");    
        expect(lookupChar("string", -1)).to.equal("Incorrect index");    
    });

    it("should return correct character when both parameters are valid", () => {
        expect(lookupChar("string", 0)).to.equal("s");    
        expect(lookupChar("string", 1)).to.equal("t");    
        expect(lookupChar("string", 4)).to.equal("n");    
        expect(lookupChar("integer", 4)).to.equal("g");    
    });
})