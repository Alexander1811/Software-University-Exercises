using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console
                .ReadLine()
                .Split()
                .Select(e => int.Parse(e))
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split(" ").ToArray();

                if (commandArgs[0] == "Insert")
                {
                    InsertAtIndex(numbers, commandArgs);
                }
                else if (commandArgs[0] == "Delete")
                {
                    DeleteAtIndex(numbers, commandArgs);
                }
            }

            PrintResult(numbers);
        }

        private static void PrintResult(List<int> numbers)
        {
            foreach (int item in numbers)
            {
                Console.Write(item + " ");
            }
        }

        private static void InsertAtIndex(List<int> numbers, string[] commandArgs)
        {
            int index = Convert.ToInt32(commandArgs[2]);
            int item = Convert.ToInt32(commandArgs[1]);
            numbers.Insert(index, item);
        }

        private static void DeleteAtIndex(List<int> numbers, string[] commandArgs)
        {
            int item = Convert.ToInt32(commandArgs[1]);
            while (numbers.Contains(item))
            {
                numbers.Remove(item);
            }            
        }
    }
}
