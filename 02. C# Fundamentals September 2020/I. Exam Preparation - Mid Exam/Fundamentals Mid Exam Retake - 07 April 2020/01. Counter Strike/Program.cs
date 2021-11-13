using System;

namespace P01_CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int count = 0;
            bool isWon = true;

            string input;
            while ((input = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(input);
                if (energy - distance < 0) //not enough energy
                {
                    Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {energy} energy");
                    isWon = false;
                    break;
                }
                else if (energy - distance >= 0) //won
                {                
                    energy -= distance;
                    count++;
                }

                if (count % 3 == 0) //add energy bonus
                {
                    energy += count;
                }
            }
            if (isWon)
            {
                Console.WriteLine($"Won battles: {count}. Energy left: {energy}");
            }
        }
    }
}