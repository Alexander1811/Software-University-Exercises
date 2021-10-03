using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Commands
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(e => int.Parse(e)).ToList();
            if (numbers.Count < 1 || numbers.Count > 50)
            {
                return;
            }

            string command;
            int i = 0;
            while ((command = Console.ReadLine()) != "end" || i > 20)
            {
                string[] task = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = task[0];
                int start;
                int count;

                if (action == "reverse")
                {
                    start = int.Parse(task[2]);
                    count = int.Parse(task[4]);
                    Reverse(numbers, start, count);
                }
                else if (action == "sort")
                {
                    start = int.Parse(task[2]);
                    count = int.Parse(task[4]);

                    Sort(numbers, start, count);
                }
                else if (action == "remove")
                {
                    count = int.Parse(task[1]);
                    numbers.RemoveRange(0, count);
                }

                i++;
            }
            Console.WriteLine(String.Join(", ", numbers));

        }
        static public void Reverse(List<int> arr, int start, int count)
        {
            arr.Reverse(start, count);
        }
        static public void Sort(List<int> arr, int start, int count)
        {
            arr.Sort(start, count, null);
        }
    }
}
