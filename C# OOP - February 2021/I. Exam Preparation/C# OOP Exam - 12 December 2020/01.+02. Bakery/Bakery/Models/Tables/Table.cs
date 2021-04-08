using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities;
using Bakery.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;
        private int capacity;
        private decimal pricePerPerson;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                Validator.ThrowIfIntegerIsLessOrEqualToZero(value, ExceptionMessages.InvalidTableCapacity);

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                Validator.ThrowIfIntegerIsLessOrEqualToZero(value, ExceptionMessages.InvalidNumberOfPeople);

                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson
        {
            get => this.pricePerPerson;
            private set
            {
                Validator.ThrowIfDecimalIsLessOrEqualToZero(value, ExceptionMessages.InvalidPrice);

                this.pricePerPerson = value;
            }
        }

        public bool IsReserved => this.NumberOfPeople > 0;

        public decimal Price => (drinkOrders.Sum(order => order.Price) + foodOrders.Sum(order => order.Price)) + (numberOfPeople * pricePerPerson);

        public void Clear()
        {
            drinkOrders.Clear();
            foodOrders.Clear();
            numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {capacity}");
            sb.AppendLine($"Price per Person: {pricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
        }
    }
}
