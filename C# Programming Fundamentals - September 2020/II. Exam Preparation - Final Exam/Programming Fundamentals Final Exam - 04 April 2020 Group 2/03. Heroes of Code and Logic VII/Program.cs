using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> heroesHP = new Dictionary<string, int>();
            Dictionary<string, int> heroesMP = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] heroDescription = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string heroName = heroDescription[0];
                int HP = int.Parse(heroDescription[1]);
                int MP = int.Parse(heroDescription[2]);
                if (HP > 100 || MP > 200)
                {
                    continue;
                }

                if (!heroesHP.ContainsKey(heroName))
                {
                    heroesHP[heroName] = HP;
                }
                if (!heroesMP.ContainsKey(heroName))
                {
                    heroesMP[heroName] = MP;
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" - ").ToArray();
                string action = command[0];
                string heroName = command[1];

                if (action == "CastSpell")
                {
                    int MPNeeded = int.Parse(command[2]);
                    string spellName = command[3];
                    if (heroesMP[heroName] >= MPNeeded)
                    {
                        heroesMP[heroName] -= MPNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroesMP[heroName]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(command[2]);
                    string attacker = command[3];

                    heroesHP[heroName] -= damage;
                    if (heroesHP[heroName] > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroesHP[heroName]} HP left!");
                    }
                    else
                    {
                        heroesHP[heroName] = 0;
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroesHP.Remove(heroName);
                    }
                }
                else if (action == "Recharge")
                {
                    int amount = int.Parse(command[2]);

                    if (heroesMP[heroName] + amount > 200)
                    {
                        Console.WriteLine($"{heroName} recharged for {200 - heroesMP[heroName]} MP!");
                        heroesMP[heroName] = 200;
                    }
                    else
                    {
                        heroesMP[heroName] += amount;
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }
                }
                else if (action == "Heal")
                {
                    int amount = int.Parse(command[2]);

                    if (heroesHP[heroName] + amount > 100)
                    {
                        Console.WriteLine($"{heroName} healed for {100 - heroesHP[heroName]} HP!"); 
                        heroesHP[heroName] = 100;
                    }
                    else
                    {
                        heroesHP[heroName] += amount;
                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                    }
                }
            }

            heroesHP = heroesHP.OrderByDescending(b => b.Value).ThenBy(a => a.Key).ToDictionary(a => a.Key, b => b.Value);
            foreach (KeyValuePair<string, int> keyValuePair in heroesHP)
            {
                string heroName = keyValuePair.Key;
                int HP = keyValuePair.Value;
                int MP = heroesMP[heroName];

                Console.WriteLine($"{heroName}");
                Console.WriteLine($"  HP: {HP}");
                Console.WriteLine($"  MP: {MP}");
            }
        }
    }
}