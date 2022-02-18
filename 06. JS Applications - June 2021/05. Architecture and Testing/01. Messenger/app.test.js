const { chromium } = require("playwright-chromium");
const { expect } = require("chai");

let browser, page;
let clientUrl = "http://127.0.0.1:5500/01.%20Messenger";

function fakeResponse(data) {
    return {
        status: 200,
        headers: {
            "Access-Control-Allow-Origin": "*",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    }
}

describe("Messenger tests", () => {
    //before(async () => { browser = await chromium.launch({ headless: false, slowMo: 500 }); });
    before(async () => { browser = await chromium.launch(); });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    describe("getMessages", () => {
        let testMessages = {
            1: {
                author: "Peter",
                content: "My message1",
            },
            2: {
                author: "George",
                content: "My message2",
            }
        };

        it("should call server with correct data", async () => {
            await page.route("**/jsonstore/messenger", route => route.fulfill(fakeResponse(testMessages)));

            await page.goto(clientUrl);

            let [response] = await Promise.all([
                page.waitForResponse("**/jsonstore/messenger"),
                page.click("#refresh")
            ]);

            let result = await response.json();

            expect(result).to.eql(testMessages);
        });

        it("should show data in textarea", async () => {
            await page.route("**/jsonstore/messenger", route => route.fulfill(fakeResponse(testMessages)));

            await page.goto(clientUrl);

            let [response] = await Promise.all([
                page.waitForResponse("**/jsonstore/messenger"),
                page.click("#refresh")
            ]);

            let textareaText = await page.$eval("#messages", (textarea) => textarea.value);

            let messagesText = Object.values(testMessages).map(x => `${x.author}: ${x.content}`).join('\n');

            expect(textareaText).to.eql(messagesText);
        });
    });

    describe("sendMessages", () => {
        let testMessageSend = {
            3: {
                author: "John",
                content: "My message3",
                _id: 3
            }
        };

        it("should call server with correct data", async () => {
            let requestData = undefined;
            let expected = {
                author: "John",
                content: "My message3"
            }

            await page.route("**/jsonstore/messenger", (route, request) => {
                if (request.method().toLowerCase() == "post") {
                    requestData = request.postData();
                    route.fulfill(fakeResponse(testMessageSend))
                }
            });

            await page.goto(clientUrl);

            await page.fill("#author", expected.author);
            await page.fill("#content", expected.content);

            let [response] = await Promise.all([
                page.waitForResponse("**/jsonstore/messenger"),
                page.click("#submit")
            ]);

            let result = JSON.parse(requestData);

            expect(result).to.eql(expected);
        });

        it("should clear form inputs after submission", async () => {
            let requestData = undefined;
            let expected = {
                author: "John",
                content: "My message3"
            }

            await page.route("**/jsonstore/messenger", (route, request) => {
                if (request.method().toLowerCase() == "post") {
                    requestData = request.postData();
                    route.fulfill(fakeResponse(testMessageSend))
                }
            });

            await page.goto(clientUrl);

            await page.fill("#author", expected.author);
            await page.fill("#content", expected.content);

            let [response] = await Promise.all([
                page.waitForResponse("**/jsonstore/messenger"),
                page.click("#submit")
            ]);

            let authorValue = await page.$eval("#author", el => el.value);
            let contentValue = await page.$eval("#content", el => el.value);

            expect(authorValue).to.eql("");
            expect(contentValue).to.eql("");
        });
    });
});

