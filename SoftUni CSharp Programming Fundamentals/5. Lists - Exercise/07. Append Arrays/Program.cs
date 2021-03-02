using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfArrays = Console
                .ReadLine()
                .Split('|')
                .Reverse()
                .ToList();
            List<int> numbers = new List<int>();


            foreach (string arrayOfNumbers in listOfArrays)
            {
                numbers.AddRange(arrayOfNumbers
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => int.Parse(e))
                    .ToArray());                
            }

            foreach ( int number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}
