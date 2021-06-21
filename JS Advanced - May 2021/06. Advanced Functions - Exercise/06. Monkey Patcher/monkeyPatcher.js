function solve(command) {
    const commands = {
        "upvote": () => this.upvotes++,
        "downvote": () => this.downvotes++,
        "score": () => {
            let upvotesReported = this.upvotes;
            let downvotesReported = this.downvotes;
            let sum = this.upvotes + this.downvotes;
            let balance = this.upvotes - this.downvotes;

            let rating = "";

            if (sum > 50) {
                let obfuscator = 0.25;

                let valueAdded = this.upvotes > this.downvotes ? Math.ceil(this.upvotes * obfuscator) : Math.ceil(this.downvotes * obfuscator);

                upvotesReported += valueAdded;
                downvotesReported += valueAdded;
            }

            if (sum < 10) {
                rating = "new";
            }
            else if (this.upvotes > sum * 0.66) {
                rating = "hot";
            }
            else if (balance >= 0 && (this.upvotes > 100 || this.downvotes > 100)) {
                rating = "controversial";
            }
            else if (balance < 0) {
                rating = "unpopular";
            }
            else {
                rating = "new";
            }

            return [upvotesReported, downvotesReported, balance, rating];
        }
    }

    return commands[command]();
}