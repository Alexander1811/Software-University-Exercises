﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, int> getMin = numbers =>
            {
                int minNum = int.MaxValue;

                foreach (int num in numbers)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }
                return minNum;
            };

            List<int> numbers = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(num => int.Parse(num))
                .ToList();

            Console.WriteLine(getMin(numbers));
        }
    }
}
