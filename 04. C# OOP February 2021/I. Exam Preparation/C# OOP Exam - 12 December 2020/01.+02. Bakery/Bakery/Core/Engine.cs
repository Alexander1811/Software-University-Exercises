namespace Bakery.Core
{
    using System;

    using Contracts;
    using IO;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }

        public void Run()
        {
            string input;
            while ((input = this.reader.ReadLine()) != "END")
            {
                string[] arguments = input.Split();

                string command = arguments[0];

                string result = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "AddFood":
                            string type = arguments[1];
                            string name = arguments[2];
                            decimal price = decimal.Parse(arguments[3]);

                            result = this.controller.AddFood(type, name, price);
                            break;

                        case "AddDrink":
                            string drinktype = arguments[1];
                            string drinkName = arguments[2];
                            int portion = int.Parse(arguments[3]);
                            string brand = arguments[4];

                            result = this.controller.AddDrink(drinktype, drinkName, portion, brand);
                            break;

                        case "AddTable":
                            string tableType = arguments[1];
                            int tableNumber = int.Parse(arguments[2]);
                            int capacity = int.Parse(arguments[3]);

                            result = this.controller.AddTable(tableType, tableNumber, capacity);
                            break;

                        case "ReserveTable":
                            int numberOfPeople = int.Parse(arguments[1]);

                            result = this.controller.ReserveTable(numberOfPeople);
                            break;

                        case "OrderFood":
                            int tableNum = int.Parse(arguments[1]);
                            string foodName = arguments[2];

                            result = this.controller.OrderFood(tableNum, foodName);
                            break;

                        case "OrderDrink":
                            int tableN = int.Parse(arguments[1]);
                            string drName = arguments[2];
                            string drinkBrand = arguments[3];

                            result = this.controller.OrderDrink(tableN, drName, drinkBrand);
                            break;

                        case "LeaveTable":
                            int leftTableNum = int.Parse(arguments[1]);

                            result = this.controller.LeaveTable(leftTableNum);
                            break;

                        case "GetFreeTablesInfo":
                            result = this.controller.GetFreeTablesInfo();
                            break;

                        case "GetTotalIncome":
                            result = this.controller.GetTotalIncome();
                            break;
                    }

                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                    when(ex is ArgumentException || ex is ArgumentNullException)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}