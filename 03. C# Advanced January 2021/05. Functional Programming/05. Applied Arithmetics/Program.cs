using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToList();

            Func<List<int>, List<int>> add = n =>
            {
                List<int> newNumbers = new List<int>();
                foreach (int currentNumber in numbers)
                {
                    newNumbers.Add(currentNumber + 1);
                }

                return newNumbers;
            };
            
            Func<List<int>, List<int>> multiply = n =>
            {
                List<int> newNumbers = new List<int>();
                foreach (int currentNumber in numbers)
                {
                    newNumbers.Add(currentNumber * 2);
                }

                return newNumbers;
            };
            
            Func<List<int>, List<int>> subtract = n =>
            {
                List<int> newNumbers = new List<int>();
                foreach (int currentNumber in numbers)
                {
                    newNumbers.Add(currentNumber - 1);
                }

                return newNumbers;
            };

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }
            }
        }
    }
}
