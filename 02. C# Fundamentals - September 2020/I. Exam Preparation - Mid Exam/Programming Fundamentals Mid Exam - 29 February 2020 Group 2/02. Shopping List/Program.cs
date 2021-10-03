using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] list = Console.ReadLine().Split('!').ToArray();
            List<string> grocery = new List<string>();
            foreach (string item in list)
            {
                grocery.Add(item);
            }

            string input;
            while ((input = Console.ReadLine()) != "Go Shopping!")
            {
                string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = command[0];
                string item = command[1];

                if (action == "Urgent")
                {
                    if (!grocery.Contains(item))
                    {
                        grocery.Remove(item);
                        grocery.Insert(0, item);
                    }
                }
                else if (action == "Unnecessary")
                {
                    if (grocery.Contains(item))
                    {
                        grocery.Remove(item);
                    }
                }
                else if (action == "Correct")
                {
                    string oldItem = item;
                    string newItem = command[2];
                    if (grocery.Contains(item))
                    {
                        int itemIndex = grocery.IndexOf(oldItem);
                        grocery.Remove(oldItem);
                        grocery.Insert(itemIndex, newItem);
                    }
                }
                else if (action == "Rearrange")
                {
                    if (grocery.Contains(item))
                    {
                        grocery.Remove(item);
                        grocery.Add(item);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", grocery));
        }
    }
}
