using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] bounds = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            int start = bounds[0];
            int end = bounds[1];
            string type = Console.ReadLine();

            Func<int, int, List<int>> getRange = (start, end) =>
            {
                List<int> sequence = new List<int>();

                for (int i = start; i <= end; i++)
                {
                    sequence.Add(i);
                }

                return sequence;
            };

            List<int> numbers = getRange(start, end);

            if (type == "even")
            {
                Console.WriteLine(string.Join(" ", MyWhere(numbers, n => n % 2 == 0)));
            }
            else if (type == "odd")
            {
                Console.WriteLine(string.Join(" ", MyWhere(numbers, n => n % 2 != 0)));
            }
        }

        static List<int> MyWhere(List<int> numbers, Predicate<int> predicate)
        {
            List<int> sortedNumbers = new List<int>();

            foreach (int currentNumber in numbers)
            {
                if (predicate(currentNumber))
                {
                    sortedNumbers.Add(currentNumber);
                }
            }

            return sortedNumbers;
        }
    }
}
