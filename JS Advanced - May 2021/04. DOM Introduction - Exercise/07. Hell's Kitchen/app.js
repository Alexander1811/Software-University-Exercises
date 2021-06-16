function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let textAreaElement = document.querySelector("#inputs textarea");

      let text = textAreaElement.value;
      let inputArray = JSON.parse(text);

      let restaurants = {};

      for (let i = 0; i < inputArray.length; i++) {
         let [restaurantName, workersString] = inputArray[i].split(" - ");

         let inputWorkers = workersString.split(", ").map(w => {
            let [name, salary] = w.split(' ');
            return { name, salary: Number(salary) }
         });

         if (!restaurants[restaurantName]) {
            restaurants[restaurantName] = {
               workers: [],
               name: restaurantName,
               getAverageSalary: function () {
                  return this.workers.reduce((acc, el) => acc + el.salary, 0) / this.workers.length;
               }
            }
         }

         restaurants[restaurantName].workers = restaurants[restaurantName].workers.concat(inputWorkers);
      }

      let sortedRestaurants = Object.values(restaurants).sort((a, b) => b.getAverageSalary() - a.getAverageSalary());
      let bestRestaurant = sortedRestaurants[0];

      let sortedWorkers = bestRestaurant.workers.sort((a, b) => b.salary - a.salary);

      let name = bestRestaurant.name;
      let averageSalary = bestRestaurant.getAverageSalary().toFixed(2);
      let bestSalary = sortedWorkers[0].salary.toFixed(2);

      let bestRestaurantString = `Name: ${name} Average Salary: ${averageSalary} Best Salary: ${bestSalary}`;
      let workersString = sortedWorkers.map(w => `Name: ${w.name} With Salary: ${w.salary}`).join(' ');

      let bestRestaurantElement = document.querySelector("#bestRestaurant p");
      let workersElement = document.querySelector("#workers p");

      bestRestaurantElement.textContent = bestRestaurantString;
      workersElement.textContent = workersString;
   }
}