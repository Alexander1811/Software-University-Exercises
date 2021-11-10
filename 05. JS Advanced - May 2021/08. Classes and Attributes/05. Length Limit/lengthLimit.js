class Stringer {
    constructor(string, length) {
        this.innerString = string;
        this.innerLength = length;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        if (this.innerLength - length <= 0) {
            this.innerLength = 0;
        }
        else {
            this.innerLength -= length;
        }
    }

    toString() {
        let appendedString = "...";
        let difference = this.innerString.length - this.innerLength;

        if (this.innerLength == 0) {
            return appendedString;
        }

        if (difference > 0) {
            return this.innerString.substring(0, this.innerString.length - difference) + appendedString;
        }
        else {
            return this.innerString;
        }
    }
}