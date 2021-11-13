using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = command[0];
                int power = int.Parse(command[1]);

                if (command.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }
                else if (command.Length == 3)
                {
                    if (command[2].All(char.IsDigit))
                    {
                        int displacement = int.Parse(command[2]);
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        string efficiency = command[2];
                        engines.Add(new Engine(model, power, efficiency));
                    }
                }
                else if (command.Length == 4)
                {
                    int displacement = int.Parse(command[2]);
                    string efficiency = command[3];

                    engines.Add(new Engine(model, power, displacement, efficiency));
                }
            }

            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = command[0];
                Engine engine = engines.First(e => e.Model == command[1]);

                if (command.Length == 2)
                {
                    cars.Add(new Car(model, engine));
                }
                else if (command.Length == 3)
                {
                    if (command[2].All(char.IsDigit))
                    {
                        int weight = int.Parse(command[2]);

                        cars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        string color = command[2];

                        cars.Add(new Car(model, engine, color));
                    }
                }
                else if (command.Length == 4)
                {
                    int weight = int.Parse(command[2]);
                    string color = command[3];

                    cars.Add(new Car(model, engine, weight, color));
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
