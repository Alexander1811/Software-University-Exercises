class Restaurant {
    constructor(budget) {
        this.budgetMoney = Number(budget);
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        let result = [];
        for (let entry of products) {
            entry = entry.split(' ');

            let productTotalPrice = Number(entry.pop());
            let productQuantity = Number(entry.pop());
            let productName = entry.join(' ');

            if (productTotalPrice <= this.budgetMoney) {
                if (this.stockProducts[productName]) {
                    this.stockProducts[productName] += productQuantity;
                }
                else {
                    this.stockProducts[productName] = productQuantity;
                } 
                
                this.budgetMoney -= productTotalPrice;

                result.push(`Successfully loaded ${productQuantity} ${productName}`);
            }
            else {
                result.push(`There was not enough money to load ${productQuantity} ${productName}`);
            }
        }

        this.history = [...this.history, ...result];
        return this.history.join('\n');
    }

    addToMenu(meal, neededProducts, price) {
        if (!this.menu[meal]) {
            this.menu[meal] = { neededProducts: [], price: price };

            for (let i = 0; i < neededProducts.length; i++) {
                let [productName, productQuantity] = neededProducts[i].split(' ');

                this.menu[meal].neededProducts.push({ productName: productName, productQuantity: productQuantity });
            }


            let mealsCount = Object.keys(this.menu).length;
            if (mealsCount == 1) {
                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
            }
            else if (mealsCount > 1) {
                return `Great idea! Now with the ${meal} we have ${mealsCount} meals in the menu, other ideas?`;
            }
        }
        else {
            return `The ${meal} is already in the our menu, try something different.`;
        }
    }

    showTheMenu() {
        let result = [];

        let mealsCount = Object.keys(this.menu).length;

        if (mealsCount > 0) {
            for (const meal in this.menu) {
                result.push(`${meal} - $ ${this.menu[meal].price}`);
            }
        }
        else if (mealsCount == 0) {
            result.push(`Our menu is not ready yet, please come later...`);
        }

        return result.join('\n');
    }

    makeTheOrder(meal) {
        let orderedMeal = this.menu[meal];

        if (orderedMeal == undefined) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }
        else {
            let neededProducts = orderedMeal.neededProducts;

            for (let i = 0; i < neededProducts.length; i++) {
                let productName = neededProducts[i].productName;
                let productQuantity = neededProducts[i].productQuantity;

                if (!this.stockProducts[productName] || this.stockProducts[productName] < productQuantity) {
                    return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
                }
            }

            for (let i = 0; i < neededProducts.length; i++) {
                let productName = neededProducts[i].productName;
                let productQuantity = neededProducts[i].productQuantity;

                this.stockProducts[productName] -= productQuantity;
            }
            this.budgetMoney += orderedMeal.price;

            return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${orderedMeal.price}.`;
        }
    }
}
