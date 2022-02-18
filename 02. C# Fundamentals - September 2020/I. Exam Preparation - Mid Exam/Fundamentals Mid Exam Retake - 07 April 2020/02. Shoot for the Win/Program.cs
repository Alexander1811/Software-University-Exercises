using System;
using System.Linq;

namespace P02_ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                int currentIndex = int.Parse(input);

                if (currentIndex >= targets.Length)
                {
                    continue;
                }

                if (targets[currentIndex] != -1)
                {
                    int difference = targets[currentIndex];                
                    int currentValue = targets[currentIndex];

                    targets[currentIndex] = -1;
                    for (int otherIndex = 0; otherIndex < targets.Length; otherIndex++)
                    {
                        int otherValue = targets[otherIndex];
                        if (targets[otherIndex] > currentValue)
                        {
                            targets[otherIndex] -= difference;
                            if (targets[otherIndex] < -1)
                            {
                                targets[otherIndex] = -1;
                            }
                        }
                        else if (targets[otherIndex] <= currentValue)
                        {
                            if (targets[otherIndex] != -1)
                            {
                                targets[otherIndex] += difference;
                            }
                        }
                    }
                }
            }

            int shots = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] == -1)
                {
                    shots++;
                }
            }

            Console.WriteLine($"Shot targets: {shots} -> ");
            for (int i = 0; i < targets.Length; i++)
            {
                {
                    Console.Write($"{targets[i]} ");
                }
            }
        }
    }
}
