class Company {
    constructor() {
        this.departments = new Map();
    }

    static Employee = class Employee {
        constructor(username, salary, position) {
            this.username = username;
            this.salary = salary;
            this.position = position;
        }

        get username() {
            return this._username;
        }
        set username(value) {
            this._validateParameter(value);
            this._username = value;
        }

        get salary() {
            return this._salary;
        }
        set salary(value) {
            this._validateParameter(value);
            if (value < 0) {
                throw new Error("Invalid input!");
            }
            this._salary = value;
        }

        get position() {
            return this._position;
        }
        set position(value) {
            this._validateParameter(value);
            this._position = value;
        }

        _validateParameter(value) {
            if (value == undefined || value == null || value == "") {
                throw new Error("Invalid input!");
            }
        }

        compareTo(other) {
            let result = other.salary - this.salary;
            return result == 0 ? this.username.localeCompare(other.username) : result;
        }

        toString() {
            return `${this.username} ${this.salary} ${this.position}`;
        }
    }

    addEmployee(username, salary, position, department) {
        if (department == undefined || department == null || department == "") {
            throw new Error("Invalid input!");
        }

        if (!this.departments.has(department)) {
            this.departments.set(department, []);
        }

        let workers = this.departments.get(department);
        let employee = new Company.Employee(username, salary, position);
        workers.push(employee);

        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let sortedDepartments = [...this.departments]
            .sort(([aName, aWorkers], [bName, bWorkers]) => {
                let aAverageSalary = this._getAverageSalary(aName);
                let bAverageSalary = this._getAverageSalary(bName);
                return bAverageSalary - aAverageSalary;
            });

        let [bestDepartmentName, bestDepartmentWorkers] = sortedDepartments[0];
        bestDepartmentWorkers.sort((a, b) => a.compareTo(b));

        let bestDepartmentString = `Best Department is: ${bestDepartmentName}\n` +
            `Average salary: ${this._getAverageSalary(bestDepartmentName).toFixed(2)}\n`;

        let bestWorkersString = bestDepartmentWorkers.map(w => w.toString()).join('\n');

        return `${bestDepartmentString}${bestWorkersString}`;
    }

    _getAverageSalary(departmentName) {
        let departmentWorkers = this.departments.get(departmentName);
        let averageSalary = departmentWorkers.reduce((acc, w) => acc + w.salary, 0) / departmentWorkers.length;
        return averageSalary;
    }
}