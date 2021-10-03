using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> carsMileage = new Dictionary<string, int>();
            Dictionary<string, int> carsFuel = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] information = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string car = information[0];
                int mileage = int.Parse(information[1]);
                int fuel = int.Parse(information[2]);

                if (!carsMileage.ContainsKey(car))
                {
                    carsMileage[car] = mileage;
                }
                if (!carsFuel.ContainsKey(car))
                {
                    carsFuel[car] = fuel;
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] command = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = command[0];
                string car = command[1];

                if (action == "Drive")
                {
                    int distance = int.Parse(command[2]);
                    int fuelNeeded = int.Parse(command[3]);

                    if (carsFuel[car] >= fuelNeeded)
                    {
                        carsMileage[car] += distance;
                        carsFuel[car] -= fuelNeeded;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");
                        if (carsMileage[car] >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {car}!");
                            carsMileage.Remove(car);
                            carsFuel.Remove(car);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                }
                else if (action == "Refuel")
                {
                    int fuelRefilled = int.Parse(command[2]);

                    if (carsFuel[car] + fuelRefilled < 75)
                    {
                        carsFuel[car] += fuelRefilled;
                        Console.WriteLine($"{car} refueled with {fuelRefilled} liters");
                    }
                    else if (carsFuel[car] + fuelRefilled >= 75)
                    {
                        Console.WriteLine($"{car} refueled with {75 - carsFuel[car]} liters"); 
                        carsFuel[car] = 75;
                    }
                }
                else if (action == "Revert")
                {
                    int kilometersDecreased = int.Parse(command[2]);

                    if (carsMileage[car] - kilometersDecreased < 10000)
                    {
                        carsMileage[car] = 10000;
                    }
                    else if (carsMileage[car] - kilometersDecreased >= 10000)
                    {                        
                        Console.WriteLine($"{car} mileage decreased by {kilometersDecreased} kilometers");
                        carsMileage[car] -= kilometersDecreased;
                    }
                }
            }

            carsMileage = carsMileage.OrderByDescending(b => b.Value).ThenBy(a => a.Key).ToDictionary(a => a.Key, b => b.Value);
            foreach (KeyValuePair<string, int> keyValuePair in carsMileage)
            {
                string car = keyValuePair.Key;
                int mileage = keyValuePair.Value;
                int fuel = carsFuel[car];

                Console.WriteLine($"{car} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt.");
            }
        }
    }
}
