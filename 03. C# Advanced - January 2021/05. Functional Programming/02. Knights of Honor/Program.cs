using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> newNames = names.Select(name => $"Sir {name}").ToList();

            Action<List<string>> printNames = n => Console.WriteLine(string.Join(Environment.NewLine, n));

            printNames(newNames);
        }
    }
}
