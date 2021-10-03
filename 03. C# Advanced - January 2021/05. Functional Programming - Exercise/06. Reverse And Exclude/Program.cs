using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToList();

            int n = int.Parse(Console.ReadLine());

            Func<List<int>, int, List<int>> sortNumbers = (numbers, num) =>
            {
                List<int> newNumbers = new List<int>();
                foreach (int currentNumber in numbers)
                {
                    if (currentNumber % num != 0)
                    {
                        newNumbers.Add(currentNumber);
                    }
                }

                return newNumbers;
            };

            Func<List<int>, List<int>> reverseNumbers = numbers =>
            {
                List<int> newNumbers = new List<int>();
                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    newNumbers.Add(numbers[i]);
                }

                return newNumbers;
            };

            Console.WriteLine(string.Join(" ", reverseNumbers(sortNumbers(numbers, n))));
        }
    }
}
