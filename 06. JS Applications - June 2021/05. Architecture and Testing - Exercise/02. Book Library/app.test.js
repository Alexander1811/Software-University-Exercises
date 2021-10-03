const { chromium } = require("playwright-chromium");
const { expect } = require("chai");

let browser, page;
let clientUrl = "http://127.0.0.1:5500/02.%20Book%20Library";

describe("Book library tests", () => {
    //before(async () => { browser = await chromium.launch({ headless: false, slowMo: 500 }); });
    before(async () => { browser = await chromium.launch(); });
    after(async () => { await browser.close(); });
    beforeEach(async () => {
        page = await browser.newPage();
        await page.goto(clientUrl);
    });
    afterEach(async () => { await page.close(); });

    describe("getAllBooks", () => {
        it("should load correct data", async () => {
            let firstBookResponse = {
                title: "Harry Potter and the Philosopher\'s Stone",
                author: "J.K.Rowling"
            };
            let secondBookResponse = {
                title: "C# Fundamentals",
                author: "Svetlin Nakov"
            };

            await page.click("text=LOAD ALL BOOKS");
            await page.waitForSelector("tbody tr td");

            let firstTitle = await page.$eval("tbody tr:first-child :first-child", (el) => el.textContent.trim());
            let secondTitle = await page.$eval("tbody tr:nth-child(2) :first-child", (el) => el.textContent.trim());
            let firstAuthor = await page.$eval("tbody tr:first-child :nth-child(2)", (el) => el.textContent.trim());
            let secondAuthor = await page.$eval("tbody tr:nth-child(2) :nth-child(2)", (el) => el.textContent.trim());

            expect(firstTitle).to.eql(firstBookResponse.title);
            expect(secondTitle).to.eql(secondBookResponse.title);
            expect(firstAuthor).to.eql(firstBookResponse.author);
            expect(secondAuthor).to.eql(secondBookResponse.author);
        });
    });

    describe("createBook", () => {
        it("should fill table with correct data", async () => {
            let newBook = {
                title: "Lord of the Rings",
                author: "J.R.R.Tolkien"
            }
            let titleInput = "[placeholder=\"Title...\"]";
            let authorInput = "[placeholder=\"Author...\"]";

            await page.click(titleInput);
            await page.fill(titleInput, newBook.title);
            await page.click(authorInput);
            await page.fill(authorInput, newBook.author);
            await page.click("text=Submit");
            await page.click("text=LOAD ALL BOOKS");
            await page.waitForSelector("tbody tr td");

            let createdTitle = await page.$eval("tbody tr:last-child :first-child", (el) => el.textContent.trim());
            let createdAuthor = await page.$eval("tbody tr:last-child :nth-child(2)", (el) => el.textContent.trim());

            expect(createdTitle).to.eql(newBook.title);
            expect(createdAuthor).to.eql(newBook.author);
        });
    });

    describe("updateBook", () => {
        it("should call server with correct data", async () => {
            await page.click("text=LOAD ALL BOOKS");
            await page.click("tbody tr:last-child .editBtn");

            let newBook = {
                title: "Game of Thrones",
                author: "G.R.R.Martin"
            }
            let authorEditedInput = "text=Edit FORM TITLE AUTHOR Save >> [placeholder=\"Author...\"]";
            let titleEditedInput = "text=Edit FORM TITLE AUTHOR Save >> [placeholder=\"Title...\"]";
            await page.click(titleEditedInput);
            await page.fill(titleEditedInput, newBook.title);
            await page.click(authorEditedInput);
            await page.fill(authorEditedInput, newBook.author);
            await page.click("text=Save");
            await page.click("text=LOAD ALL BOOKS");
            await page.waitForSelector("tbody tr td");
            
            let firstBook = await page.$eval("tbody tr:last-child :first-child", (el) => el.textContent.trim());
            let firstAuthor = await page.$eval("tbody tr:last-child :nth-child(2)", (el) => el.textContent.trim());
            expect(firstBook).to.eql(newBook.title);
            expect(firstAuthor).to.eql(newBook.author);
        });
    });

    describe("deleteBook", () => {
        it("should delete book", async () => {
            let secondBook = {
                title: "C# Fundamentals",
                author: "Svetlin Nakov"
            };

            await page.click('text=LOAD ALL BOOKS');
            page.on('dialog', (dialog) => dialog.accept());
            await page.click('tbody tr:last-child .deleteBtn');
            await page.click('#loadBooks');

            await page.waitForSelector('tbody tr td');

            let secondTitle = await page.$eval("tbody tr:last-child :first-child", (el) => el.textContent.trim());
            let secondAuthor = await page.$eval("tbody tr:last-child :nth-child(2)", (el) => el.textContent.trim());

            expect(secondTitle).to.eql(secondBook.title);
            expect(secondAuthor).to.eql(secondBook.author);
        });
    });
});

