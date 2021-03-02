using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            FillWardrobe(n, clothes);

            string[] item = Console.ReadLine().Split(" ").ToArray();
            string colorWanted = item[0];
            string typeWanted = item[1];

            PrintWantedItem(clothes, colorWanted, typeWanted);
        }

        private static void PrintWantedItem(Dictionary<string, Dictionary<string, int>> clothes, string colorWanted, string typeWanted)
        {
            foreach (KeyValuePair<string, Dictionary<string, int>> color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (KeyValuePair<string, int> item in color.Value)
                {
                    string type = item.Key;
                    int count = item.Value;

                    Console.Write($"* {type} - {count}");

                    if (color.Key == colorWanted && typeWanted == type)
                    {
                        Console.WriteLine(" (found!)");
                    }
                    else
                    {
                        Console.WriteLine("");
                    }

                }
            }
        }

        private static void FillWardrobe(int n, Dictionary<string, Dictionary<string, int>> clothes)
        {
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ").ToArray();
                string color = input[0];
                char firstLetter = char.ToUpper(color[0]);
                string substring = color.Substring(1, color.Length - 1);
                color = firstLetter + substring;

                string[] itemsNames = input[1].Split(",").ToArray();

                Dictionary<string, int> itemsWithCount = new Dictionary<string, int>();

                if (clothes.ContainsKey(color))
                {
                    itemsWithCount = clothes[color];
                }
                else
                {
                    clothes[color] = itemsWithCount;
                }

                foreach (string itemName in itemsNames)
                {
                    if (itemsWithCount.ContainsKey(itemName))
                    {
                        itemsWithCount[itemName]++;
                    }
                    else
                    {
                        itemsWithCount[itemName] = 1;
                    }
                }
            }
        }
    }
}
