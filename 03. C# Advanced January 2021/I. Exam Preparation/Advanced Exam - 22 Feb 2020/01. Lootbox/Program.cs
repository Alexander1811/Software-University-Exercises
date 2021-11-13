using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            
            List<int> collection = new List<int>();

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int firstLoot = firstLootBox.Peek();
                int secondLoot = secondLootBox.Peek();
                int sum = firstLoot + secondLoot;

                if (sum % 2 == 0)
                {
                    collection.Add(sum);
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }
                else if (sum % 2 != 0)
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                }
            }

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondLootBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (collection.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collection.Sum()}");
            }
            else if (collection.Sum() < 100)
            {
                Console.WriteLine($"Your loot was poor... Value: {collection.Sum()}");
            }
        }
    }
}
