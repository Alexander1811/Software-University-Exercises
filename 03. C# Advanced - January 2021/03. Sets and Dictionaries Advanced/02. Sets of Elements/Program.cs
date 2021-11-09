using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = numbers[0];
            int m = numbers[1];

            HashSet<int> hashSet1 = new HashSet<int>();
            HashSet<int> hashSet2 = new HashSet<int>();

            FillHashSets(n, m, hashSet1, hashSet2);

            HashSet<int> hashSetRepeats = new HashSet<int>();

            FillHashSetRepeats(hashSet1, hashSet2, hashSetRepeats);

            Console.WriteLine(string.Join(" ", hashSetRepeats));

        }

        private static void FillHashSetRepeats(HashSet<int> hashSet1, HashSet<int> hashSet2, HashSet<int> hashSetRepeats)
        {
            if (hashSet1.Count > hashSet2.Count)
            {
                foreach (int item in hashSet1)
                {
                    if (hashSet2.Contains(item))
                    {
                        hashSetRepeats.Add(item);
                    }
                }
            }
            else
            {
                foreach (int item in hashSet1)
                {
                    if (hashSet2.Contains(item))
                    {
                        hashSetRepeats.Add(item);
                    }
                }
            }
        }

        private static void FillHashSets(int n, int m, HashSet<int> hashSet1, HashSet<int> hashSet2)
        {
            for (int i = 0; i < n; i++)
            {
                hashSet1.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < m; i++)
            {
                hashSet2.Add(int.Parse(Console.ReadLine()));
            }
        }
    }
}
