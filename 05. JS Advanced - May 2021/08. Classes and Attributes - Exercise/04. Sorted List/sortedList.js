class List {
    constructor() {
        this.elements = [];
        this.size = this.elements.length;
    }

    add(element) {
        this.elements.push(element);
        this.elements.sort((a, b) => a - b);
        this.size = this.elements.length;
    }

    remove(index) {
        if (index < 0 || index >= this.elements.length) {
            throw Error("Invalid index");
        }

        this.elements.splice(index, 1);
        this.size = this.elements.length;
    }

    get(index) {
        return this.elements[index];
    }
}