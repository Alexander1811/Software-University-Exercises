using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P06_VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(" ").ToArray();
                string type = input[0].ToLower();
                string model = input[1];
                string color = input[2].ToLower();
                int horsepower = int.Parse(input[3]);

                Vehicle currentVehicle = new Vehicle(type, model, color, horsepower);

                catalogue.Add(currentVehicle);
            }

            string secondCommand;
            while ((secondCommand = Console.ReadLine()) != "Close the Catalogue")
            {
                string modelType = secondCommand;

                Vehicle printVehicle = catalogue.First(e => e.Model == modelType);

                Console.WriteLine(printVehicle);
            }

            List<Vehicle> cars = catalogue.Where(e => e.Type == "car").ToList();
            List<Vehicle> trucks = catalogue.Where(e => e.Type == "truck").ToList();

            double sumCarsHorsepower = cars.Sum(e => e.Horsepower);
            double sumTrucksHorsepower = trucks.Sum(e => e.Horsepower);

            double averageCarsHorsepower = 0.00;
            double averageTrucksHorsepower = 0.00;

            if (cars.Count > 0)
            {
                averageCarsHorsepower = sumCarsHorsepower / cars.Count;
            }
            if (trucks.Count > 0)
            {
                averageTrucksHorsepower = sumTrucksHorsepower / trucks.Count;
            }

            Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsepower:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsepower:F2}.");
        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsepower)
        {

            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }

        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; } 

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {(Type == "car" ? "Car" : "Truck")}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {Horsepower}");

            return sb.ToString().TrimEnd();
        }
    }
}
