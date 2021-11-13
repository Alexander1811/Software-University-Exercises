using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> citiesCitizens = new Dictionary<string, long>();
            Dictionary<string, long> citiesGold = new Dictionary<string, long>();

            string command;
            while ((command = Console.ReadLine()) != "Sail")
            {
                string[] information = command.Split("||").ToArray();
                string city = information[0];
                long citizens = long.Parse(information[1]);
                long gold = long.Parse(information[2]);

                if (!citiesCitizens.ContainsKey(city))
                {
                    citiesCitizens[city] = citizens;
                    citiesGold[city] = gold;
                }
                else
                {
                    if (citiesCitizens.ContainsKey(city))
                    {
                        citiesCitizens[city] += citizens;
                    }
                    if (citiesGold.ContainsKey(city))
                    {
                        citiesGold[city] += gold;
                    }
                }
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] action = command.Split("=>").ToArray();
                string type = action[0];
                string town = action[1];
                long people;
                long gold;

                if (type == "Plunder")
                {
                    people = long.Parse(action[2]);
                    gold = long.Parse(action[3]);

                    citiesCitizens[town] -= people;
                    citiesGold[town] -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    if (citiesCitizens[town] <= 0 || citiesGold[town] <= 0)
                    {
                        citiesCitizens.Remove(town);
                        citiesGold.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (type == "Prosper")
                {
                    gold = long.Parse(action[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        citiesGold[town] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {citiesGold[town]} gold.");
                    }
                }
            }

            Console.WriteLine($"Ahoy, Captain! There are {citiesCitizens.Count} wealthy settlements to go to:");
            citiesGold = citiesGold
                .OrderByDescending(b => b.Value)
                .ThenBy(a => a.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            foreach (KeyValuePair<string, long> keyValuePair in citiesGold)
            {
                string city = keyValuePair.Key;
                long gold = keyValuePair.Value;
                long people = citiesCitizens[city];
                Console.WriteLine($"{city} -> Population: {people} citizens, Gold: {gold} kg");
            }
        }
    }
}