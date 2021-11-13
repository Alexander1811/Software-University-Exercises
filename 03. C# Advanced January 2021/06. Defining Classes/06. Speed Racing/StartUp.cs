using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = carArgs[0];
                double fuelAmount = double.Parse(carArgs[1]);
                double fuelConsumptionFor1km = double.Parse(carArgs[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars.Add(car);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var command = input.Split();

                string model = command[1];
                int distance = int.Parse(command[2]);

                Car car = cars.First(c => c.Model == model);

                if (!car.Drive(distance))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
