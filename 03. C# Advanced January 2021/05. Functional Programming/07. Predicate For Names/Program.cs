using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());

            List<string> names = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<List<string>, int, List<string>> getNames = (names, length) =>
            {
                List<string> newNames = new List<string>();
                foreach (string name in names)
                {
                    if (name.Length <= length)
                    {
                        newNames.Add(name);
                    }
                }

                return newNames;
            };

            Console.WriteLine(string.Join(Environment.NewLine, getNames(names, nameLength)));
        }
    }
}
