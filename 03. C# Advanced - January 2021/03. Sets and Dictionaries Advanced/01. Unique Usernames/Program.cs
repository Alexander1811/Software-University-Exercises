using System;
using System.Collections.Generic;

namespace P01_UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> hashSet = new HashSet<string>();

            FillHashSet(n, hashSet);

            Console.WriteLine(string.Join(Environment.NewLine, hashSet));
        }

        private static void FillHashSet(int n, HashSet<string> hashSet)
        {
            for (int i = 0; i < n; i++)
            {
                hashSet.Add(Console.ReadLine());
            }
        }
    }
}
