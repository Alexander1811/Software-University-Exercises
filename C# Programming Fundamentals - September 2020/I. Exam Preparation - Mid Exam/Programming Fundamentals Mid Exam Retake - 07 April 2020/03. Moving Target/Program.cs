using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = command[0];
                int index = int.Parse(command[1]);
                int amount = int.Parse(command[2]);

                if (action == "Shoot")
                {
                    int power = amount;
                    if (index >= 0 && index < targets.Count) //Be careful with indexes start and end
                    {
                        targets[index] -= power;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (action == "Add")
                {
                    int value = amount;
                    if (index >= 0 && index <= targets.Count -1)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (action == "Strike")
                {
                    int radius = amount;
                    if (index - radius < 0 || index + radius > targets.Count - 1)
                    {
                        Console.WriteLine("Strike missed!");
                        continue;
                    }
                    else
                    {
                        int rangeStart = index - radius;
                        int count = 1 + radius * 2;
                        targets.RemoveRange(rangeStart, count);
                    }
                }
            }
            Console.WriteLine(String.Join('|', targets));
        }
    }
}
