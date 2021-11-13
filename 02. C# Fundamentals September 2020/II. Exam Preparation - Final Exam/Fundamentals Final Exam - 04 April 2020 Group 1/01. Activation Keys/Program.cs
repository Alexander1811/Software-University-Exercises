using System;
using System.Linq;

namespace P01_ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] instructions = command.Split(">>>").ToArray();
                string instruction = instructions[0];

                if (instruction == "Contains")
                {
                    string substring = instructions[1];

                    if (key.Contains(substring))
                    {
                        Console.WriteLine($"{key} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (instruction == "Flip")
                {
                    string type = instructions[1];
                    int startIndex = int.Parse(instructions[2]);
                    int endIndex = int.Parse(instructions[3]);
                    int count = endIndex - startIndex;

                    string substring = key.Substring(startIndex, count);

                    if (type == "Upper")
                    {
                        substring = substring.ToUpper();
                    }
                    else if (type == "Lower")
                    {
                        substring = substring.ToLower();
                    }

                    key = key.Remove(startIndex, count);
                    key = key.Insert(startIndex, substring);

                    Console.WriteLine(key);
                }
                else if (instruction == "Slice")
                {
                    int startIndex = int.Parse(instructions[1]);
                    int endIndex = int.Parse(instructions[2]);
                    int count = endIndex - startIndex;                    

                    key = key.Remove(startIndex, count);

                    Console.WriteLine(key);
                }
            }

            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
