namespace Bakery.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Factories;
    using Models.BakedFoods.Contracts;
    using Models.Drinks.Contracts;
    using Models.Tables.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly IList<IBakedFood> bakedFoods;
        private readonly IList<IDrink> drinks;
        private readonly IList<ITable> tables;
        private readonly BakedFoodFactory foodFactory;
        private readonly DrinkFactory drinkFactory;
        private readonly TableFactory tableFactory;
        private decimal totalIncome;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.foodFactory = new BakedFoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = this.foodFactory.CreateFood(type, name, price);

            this.bakedFoods.Add(food);

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = this.drinkFactory.CreateDrink(type, name, portion, brand);

            this.drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = this.tableFactory.CreateTable(type, tableNumber, capacity);

            this.tables.Add(table);

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable freeTable = this.tables.FirstOrDefault(table => !table.IsReserved && table.Capacity >= numberOfPeople);

            if (freeTable == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            freeTable.Reserve(numberOfPeople);

            return string.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IDrink drink = drinks.FirstOrDefault(f => f.Name == drinkName);

            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return string.Format(OutputMessages.DrinkOrderSuccessful, table.TableNumber, drink.Name, drink.Brand);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);

            return string.Format(OutputMessages.FoodOrderSuccessful, table.TableNumber, food.Name);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable targetTable = FindTableByTableNumber(tableNumber);

            if (targetTable == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            decimal bill = targetTable.GetBill();

            this.totalIncome += bill;

            targetTable.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:F2}");

            return sb.ToString().Trim();
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> freeTables = tables.Where(table => !table.IsReserved).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (ITable freeTable in freeTables)
            {
                sb.AppendLine(freeTable.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, totalIncome);
        }

        private ITable FindTableByTableNumber(int tableNumber)
        {
            return this.tables.FirstOrDefault(table => table.TableNumber == tableNumber);
        }
    }
}
