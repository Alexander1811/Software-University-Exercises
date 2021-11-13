using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            FillDictionary(n, numbers);

            Dictionary<int, int> number = numbers
                .Where(kvp => kvp.Value % 2 == 0)
                .ToDictionary(a => a.Key, b => b.Value);

            Console.WriteLine(string.Join("", number.Keys));
        }

        private static void FillDictionary(int n, Dictionary<int, int> numbers)
        {
            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (numbers.ContainsKey(currentNumber))
                {
                    numbers[currentNumber]++;
                }
                else
                {
                    numbers[currentNumber] = 1;
                }
            }
        }
    }
}
