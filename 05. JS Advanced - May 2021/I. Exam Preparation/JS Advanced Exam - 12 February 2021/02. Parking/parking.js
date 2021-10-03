class Parking {
    constructor(capacity) {
        this.capacity = Number(capacity);
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {
        if (this.vehicles.length == this.capacity) {
            throw new Error("Not enough parking space.");;
        }
        else {
            let car = {
                carModel: carModel,
                carNumber: carNumber,
                paid: false
            }

            this.vehicles.push(car);

            return `The ${carModel}, with a registration number ${carNumber}, parked.`;
        }
    }

    removeCar(carNumber) {
        let car = this.vehicles.find(c => c.carNumber == carNumber);

        if (car == undefined) {
            throw new Error("The car, you're looking for, is not found.");
        }
        else if (car.paid == false) {
            throw new Error(`${car.carNumber} needs to pay before leaving the parking lot.`);
        }

        let index = this.vehicles.indexOf(car);
        this.vehicles.splice(index, 1);

        return `${car.carNumber} left the parking lot.`;
    }

    pay(carNumber) {
        let car = this.vehicles.find(c => c.carNumber == carNumber);

        if (car == undefined) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }
        else if (car.paid == true) {
            throw new Error(`${car.carNumber}'s driver has already payed his ticket.`);
        }

        car.paid = true;

        return `${car.carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(carNumber) {
        let result = [];

        if (carNumber == undefined) {
            result.push(`The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.`);
            this.vehicles.sort((a, b) => a.carModel - b.carModel);

            for (let i = 0; i < this.vehicles.length; i++) {
                let car = this.vehicles[i];
                result.push(`${car.carModel} == ${car.carNumber} - ${car.paid == true ? "Has payed" : "Not payed"}`);
            }
        }
        else {
            let car = this.vehicles.find(c => c.carNumber == carNumber);
            result.push(`${car.carModel} == ${car.carNumber} - ${car.paid == true ? "Has payed" : "Not payed"}`);
        }

        return result.join('\n');
    }
}