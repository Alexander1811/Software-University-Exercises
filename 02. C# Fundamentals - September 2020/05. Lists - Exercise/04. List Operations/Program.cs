using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(e => int.Parse(e))
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string action = commandArgs[0];

                switch (action)
                {
                    case "Add":
                        AddNumber(numbers, commandArgs);
                        break;
                    case "Insert":
                        InsertAtIndex(numbers, commandArgs);
                        break;
                    case "Remove":
                        RemoveAtIndex(numbers, commandArgs);
                        break;
                    case "Shift":
                        ShiftLeftOrRight(numbers, commandArgs);
                        break;
                }
            }

            PrintResult(numbers);
        }

        private static void PrintResult(List<int> list)
        {
            foreach (int number in list)
            {
                Console.Write(number + " ");
            }
        }

        private static void ShiftLeftOrRight(List<int> numbers, string[] commandArgs)
        {
            string direction = commandArgs[1];
            int count = int.Parse(commandArgs[2]);
            for (int i = 0; i < count; i++)
            {
                if (direction == "left")
                {
                    int firstNumber = numbers[0];
                    numbers.RemoveAt(0);
                    numbers.Insert(numbers.Count, firstNumber);
                }
                else if (direction == "right")
                {
                    int lastNumber = numbers[numbers.Count - 1];
                    numbers.RemoveAt(numbers.Count-1);
                    numbers.Insert(0, lastNumber);
                }
            }
        }

        private static void RemoveAtIndex(List<int> numbers, string[] commandArgs)
        {
            int index = int.Parse(commandArgs[1]);
            if (index < 0 || index >= numbers.Count)
            {
                Console.WriteLine("Invalid index");
            }
            else
            {
                numbers.RemoveAt(index);
            }
        }
        private static void InsertAtIndex(List<int> numbers, string[] commandArgs)
        {

            int index = int.Parse(commandArgs[2]);
            if (index < 0 || index >= numbers.Count)
            {
                Console.WriteLine("Invalid index");
            }
            else
            {
                int number = int.Parse(commandArgs[1]);
                numbers.Insert(index, number);
            }
        }
        private static void AddNumber(List<int> numbers, string[] commandArgs)
        {
            int number = int.Parse(commandArgs[1]);
            numbers.Add(number);
        }
    }
}