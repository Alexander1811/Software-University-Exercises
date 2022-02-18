using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console
                .ReadLine()
                .Split(" ")
                .Select(e => int.Parse(e))
                .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split(" ").ToArray();

                if (commandArgs[0] == "Add")
                {
                    AddWagon(wagons, commandArgs);
                }
                else
                {
                    AddPassengers(wagons, maxCapacity, commandArgs);
                }
            }

            PrintResult(wagons);
        }

        private static void AddPassengers(List<int> wagons, int maxCapacity, string[] commandArgs)
        {
            int passengers = Convert.ToInt32(commandArgs[0]);
            for (int i = 0; i < wagons.Count; i++)
            {
                if (wagons[i] + passengers <= maxCapacity)
                {
                    wagons[i] += passengers;
                    break;
                }
            }
        }

        private static void AddWagon(List<int> wagons, string[] commandArgs)
        {
            int passengersLastWagon = Convert.ToInt32(commandArgs[1]);
            wagons.Add(passengersLastWagon);
        }

        public static void PrintResult(List<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}

