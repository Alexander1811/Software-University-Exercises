using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] list = Console.ReadLine().Split(" ").ToArray();
            List<string> gifts = new List<string>();
            foreach (string item in list)
            {
                gifts.Add(item);
            }


            string input;
            while ((input = Console.ReadLine()) != "No Money")
            {
                string[] command = input.Split(" ").ToArray();
                string action = command[0];
                string gift = command[1];

                if (action == "OutOfStock")
                {
                    while (gifts.Contains(gift))
                    {
                        int index = gifts.IndexOf(gift);
                        string item = "None";
                        gifts.Remove(gift);
                        gifts.Insert(index, item);
                    }
                }
                if (action == "Required")
                {
                    int index = int.Parse(command[2]);
                    if (index >= 0 && index <= gifts.Count - 1)
                    {
                        string oldItem = gifts[index];
                        int itemIndex = gifts.IndexOf(oldItem);
                        string newItem = gift;

                        gifts.Remove(oldItem);
                        gifts.Insert(itemIndex, newItem);
                    }
                }
                if (action == "JustInCase")
                {
                    gifts.RemoveAt(gifts.Count - 1);
                    gifts.Add(gift);
                }
            }

            while (gifts.Contains("None"))
            {
                int index = gifts.IndexOf("None");
                gifts.RemoveAt(index);
            }

            Console.WriteLine(string.Join(" ", gifts));
        }
    }
}

