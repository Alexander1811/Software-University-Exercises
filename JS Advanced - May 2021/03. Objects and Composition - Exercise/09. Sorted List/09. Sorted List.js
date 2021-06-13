function createSortedList() {
    let list = {};

    list.elements = [];
    
    list.size = this.elements.length;

    list.add = function (element) {
        this.elements.push(element);
        this.elements.sort((a, b) => a - b);
        this.size++;
        
    }
    
    list.remove = function (index) {
        if (index >= 0 && index < this.elements.length) {
            this.elements.splice(index, 1);
            this.elements.sort((a, b) => a - b);
            this.size--;
        }
    }
    
    list.get = function (index) {
        if (index >= 0 && index < this.elements.length) {
            return this.elements[index];
        }
    }

    return list;
}
