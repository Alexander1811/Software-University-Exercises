using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "Craft!")
            {
                string[] command = input
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = command[0];
                string item = command[1];

                switch (action)
                {

                    case "Collect":
                        if (inventory.Contains(item))
                        {
                            continue;
                        } 
                        else
                        {
                            inventory.Add(item);
                        }
                        break;
                    case "Drop":
                        if (inventory.Contains(item))
                        {
                            inventory.Remove(item);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "Combine Items":
                        string[] items = item.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                        string oldItem = items[0];
                        string newItem = items[1];

                        if (inventory.Contains(oldItem))
                        {
                            int oldItemIndex = inventory.FindIndex(e => e == oldItem);
                            inventory.Insert(oldItemIndex + 1, newItem);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "Renew":
                        if (inventory.Contains(item))
                        {
                            int itemOldIndex = inventory.FindIndex(e => e == item);
                            inventory.Add(item);
                            inventory.RemoveAt(itemOldIndex);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(String.Join(", ", inventory));
        }
    }
}
