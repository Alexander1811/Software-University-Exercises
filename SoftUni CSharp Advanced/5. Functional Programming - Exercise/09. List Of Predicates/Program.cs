using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            HashSet<int> divisors = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).Where(n => n != 0).Where(n => n != 1).ToHashSet();

            Func<int, int, bool> predicate = (number, divisor) => number % divisor == 0;

            for (int i = 1; i <= n; i++)
            {
                if (divisors.All(divisor => predicate(i, divisor)))
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
