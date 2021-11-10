function solve(ticketsArray, sortingCritetion) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    
        compareTo(other, critetion) {
            if (typeof this[critetion] == "string") {
                return this[critetion].localeCompare(other[critetion]);
            }
            else {
                return this[critetion] - other[critetion];
            }
        }
    }

    let tickets = [];

    for (let i = 0; i < ticketsArray.length; i++) {
        let [destination, price, status] = ticketsArray[i].split('|');
        price = Number(price);
        ticket = new Ticket(destination, price, status);

        tickets.push(ticket);
    }

    tickets.sort((a, b) => a.compareTo(b, sortingCritetion));

    return tickets;
}