using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            Func<int[], int[]> sortNumbers = numbers =>
            {
                List<int> newNumbersList = new List<int>(numbers.Length);
                int[] newNumbers = new int[numbers.Length];
                int[] evenNumbers = numbers.Where(n => n % 2 == 0).ToArray();
                int[] oddNumbers = numbers.Where(n => n % 2 != 0).ToArray();

                Array.Sort(evenNumbers);

                newNumbersList.AddRange(evenNumbers);
                newNumbersList.AddRange(oddNumbers);

                for (int i = 0; i < newNumbersList.Count; i++)
                {
                    newNumbers[i] = newNumbersList[i];
                }

                return newNumbers;
            };

            Console.WriteLine(string.Join(" ", sortNumbers(numbers)));
        }
    }
}
