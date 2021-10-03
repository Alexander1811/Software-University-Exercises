using System;
using System.Linq;

namespace _03._War_Ships
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pirateship = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries).Select(e => int.Parse(e)).ToArray();
            int[] warship = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries).Select(e => int.Parse(e)).ToArray();
            int maximum = int.Parse(Console.ReadLine());
            bool isSunk = false;

            string input;
            while ((input = Console.ReadLine()) != "Retire")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = command[0];

                if (action == "Fire")
                {
                    int index = int.Parse(command[1]);
                    int damage = int.Parse(command[2]);
                    

                    if (index < 0 || index > command.Length - 1)
                    {
                        continue;
                    }
                    else
                    {
                        int health = warship[index] - damage;
                        warship[index] -= damage;
                        if (health <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            break;
                        }
                    }
                }
                else if (action == "Defend")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    int damage = int.Parse(command[3]);

                    if (startIndex < 0 || endIndex > command.Length - 1)
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateship[i] -= damage;
                            if (pirateship[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                break;
                            }
                        }
                    }
                }
                else if (action == "Repair")
                {
                    int index = int.Parse(command[1]);
                    int repair = int.Parse(command[2]);
                    int health = pirateship[index];


                    if (index < 0 || index > command.Length - 1)
                    {
                        continue;
                    }
                    else
                    {
                        if (health + repair > 20)
                        {
                            health = 20;
                        }
                        else if (health + repair <= 20)
                        {
                            health += repair;
                        }
                    }
                }
                else if (action == "Status")
                {
                    int count = 0;
                    foreach (int section in pirateship)
                    {
                        if (section < 0.2 * maximum)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine($"{count} sections need repair.");
                }

                
            }

            int pirateshipSum = 0;
            foreach (int section in pirateship)
            {
                pirateshipSum += section;
            }
            int warshipSum = 0;
            foreach (int section in warship)
            {
                warshipSum += section;
            }
            if (pirateshipSum != warshipSum)
            {
                Console.WriteLine($"Pirate ship status: {pirateshipSum}");
                Console.WriteLine($"Warship status: {warshipSum}");
            }
        }
    }
}