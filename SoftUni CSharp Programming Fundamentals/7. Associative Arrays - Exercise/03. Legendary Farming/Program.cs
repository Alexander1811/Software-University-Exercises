using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            string[] keyMaterialNames = new string[] { "shards", "fragments", "motes" };

            keyMaterials["shards"] = 0; keyMaterials["fragments"] = 0; keyMaterials["motes"] = 0;

            bool isObtained = false;

            while (isObtained != true)
            {
                string input = Console.ReadLine().ToLower();
                string[] argument = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int i = 0; i < argument.Length; i += 2)
                {
                    int quantity = int.Parse(argument[i]);
                    string material = argument[i + 1];

                    if (keyMaterialNames.Contains(material))
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials.Any(m => m.Value >= 250))
                        {
                            GetLegendaryItem(keyMaterials, material);
                            isObtained = true;
                            break;
                        }
                    }
                    else
                    {
                        AddJunk(junkMaterials, quantity, material);
                    }
                }
            }

            PrintRemainingMaterials(keyMaterials, junkMaterials);
        }

        private static void GetLegendaryItem(Dictionary<string, int> keyMaterials, string material)
        {
            string legendaryItem = "";
            if (material == "shards")
            {
                legendaryItem = "Shadowmourne";
            }
            else if (material == "fragments")
            {
                legendaryItem = "Valanyr";
            }
            else if (material == "motes")
            {
                legendaryItem = "Dragonwrath";
            }
            keyMaterials[material] -= 250;
            Console.WriteLine($"{legendaryItem} obtained!");
        }

        private static void PrintRemainingMaterials(Dictionary<string, int> keyMaterials, Dictionary<string, int> junkMaterials)
        {
            keyMaterials = keyMaterials.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key).ToDictionary(a => a.Key, b => b.Value);
            junkMaterials = junkMaterials.OrderBy(kvp => kvp.Key).ToDictionary(a => a.Key, b => b.Value);
            foreach (var keyValuePair in keyMaterials)
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
            }
            foreach (var keyValuePair in junkMaterials)
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value}");
            }
        }

        private static void AddJunk(Dictionary<string, int> junkMaterials, int quantity, string material)
        {
            if (!junkMaterials.ContainsKey(material))
            {
                junkMaterials[material] = 0;
            }

            junkMaterials[material] += quantity;
        }
    }
}
