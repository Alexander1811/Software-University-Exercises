using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] input = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = input[0];

                if (input.Length == 3)
                {
                    AddToList(list, name);
                }
                else if (input.Length == 4)
                {
                    RemoveFromList(list, name);
                }                
            }

            PrintResult(list);
        }

        private static void PrintResult(List<string> list)
        {
            foreach (string name in list)
            {
                Console.WriteLine(name);
            }
        }

        private static void AddToList(List<string> list, string name)
        {
            if (list.Contains(name))
            {
                Console.WriteLine($"{name} is already in the list!");
            }
            else
            {
                list.Add(name);
            }
        }

        private static void RemoveFromList(List<string> list, string name)
        {
            if (list.Contains(name))
            {
                list.Remove(name);
            }
            else
            {
                Console.WriteLine($"{name} is not in the list!");
            }
        }
    }
}

