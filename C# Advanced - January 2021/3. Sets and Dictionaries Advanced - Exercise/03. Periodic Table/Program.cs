using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> sortedSet = new SortedSet<string>();

            FillSortedSet(n, sortedSet);

            Console.WriteLine(string.Join(" ", sortedSet));
        }

        private static void FillSortedSet(int n, SortedSet<string> sortedSet)
        {
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (string item in input)
                {
                    sortedSet.Add(item);
                }
            }
        }
    }
}
