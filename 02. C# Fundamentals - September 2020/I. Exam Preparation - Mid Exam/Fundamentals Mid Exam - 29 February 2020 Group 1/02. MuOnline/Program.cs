using System;
using System.Linq;

namespace P02_MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int health = 100;
            int bitcoins = 0;
            bool isKilled = false;
            int bestRoom = 0;

            for (int room = 0; room < input.Length; room++)
            {
                string[] command = input[room]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = command[0];
                int amount = int.Parse(command[1]);

                if (action == "potion")
                {
                    if (health + amount <= 100)
                    {
                        health += amount;
                        Console.WriteLine($"You healed for {amount} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else if (health + amount > 100)
                    {
                        Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                        Console.WriteLine($"Current health: 100 hp.");
                    }
                }
                else if (action == "chest")
                {
                    bitcoins += amount;
                    Console.WriteLine($"You found {amount} bitcoins.");
                }
                else
                {
                    string monster = action;
                    int attack = amount;

                    health -= attack;

                    if (health - attack > 0)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        isKilled = true;
                        bestRoom = room + 1;
                        break;
                    }
                }
            }

            if (isKilled)
            {
                Console.WriteLine($"Best room: {bestRoom}");
            }
            else
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
