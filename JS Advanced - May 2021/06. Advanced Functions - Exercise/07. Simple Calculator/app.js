function calculator() {
    return {
        init(num1Selector, num2Selector, resultSelector) {
            this.selector1 = document.querySelector(num1Selector);
            this.selector2 = document.querySelector(num2Selector);
            this.resultSelector = document.querySelector(resultSelector);
        },
        add() {
            this.resultSelector.value = Number(this.selector1.value) + Number(this.selector2.value);
        },
        subtract() {
            this.resultSelector.value = Number(this.selector1.value) - Number(this.selector2.value);
        }
    }
}

const calculate = calculator();
calculate.init("#num1", "#num2", "#result");





