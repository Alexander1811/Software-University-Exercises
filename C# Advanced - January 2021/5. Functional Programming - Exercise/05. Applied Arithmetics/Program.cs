using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToList();

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
                if (command == "add")
                {
                    numbers = add(numbers);
                }
                else if (command == "multiply")
                {
                    numbers = multiply(numbers);
                }
                else if (command == "subtract")
                {
                    numbers = subtract(numbers);
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
            }
        }
    }
}
