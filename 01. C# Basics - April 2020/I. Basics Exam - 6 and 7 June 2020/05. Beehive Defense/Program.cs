using System;

namespace P05_BeehiveDefense
{
    class Program
    {
        static void Main(string[] args)
        {
            int bees = int.Parse(Console.ReadLine());
            int bearHealth = int.Parse(Console.ReadLine());
            int bearAttack = int.Parse(Console.ReadLine());

            while (true)
            {
                bees -= bearAttack;

                int beesAttack = bees * 5;

                bearHealth -= beesAttack;

                if (bees < 100)
                {
                    if (bees <= 0)
                    {
                        bees = 0;
                    }
                    Console.WriteLine($"The bear stole the honey! Bees left {bees}.");
                    break;
                }
                if (bearHealth <= 0)
                {
                    Console.WriteLine($"Beehive won! Bees left {bees}.");
                    break;
                }
            }
        }
    }
}
