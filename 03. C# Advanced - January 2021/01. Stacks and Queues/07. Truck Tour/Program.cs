using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            Queue<int[]> pumpsData = new Queue<int[]>(); //to save time and memory do not strings, otherwise you will have to split them and join them

            for (int i = 0; i < pumpsCount; i++)
            {
                pumpsData.Enqueue(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            }

            for (int startingPump = 0; startingPump < pumpsCount; startingPump++)
            {
                int currentPetrol = 0;
                bool isFinished = true;

                for (int currentPump = 0; currentPump < pumpsCount; currentPump++)
                {
                    int[] pumpData = pumpsData.Dequeue();

                    currentPetrol += pumpData[0];
                    currentPetrol -= pumpData[1];

                    if (currentPetrol < 0)
                    {
                        isFinished = false;
                    }

                    pumpsData.Enqueue(pumpData);
                }

                if (isFinished)
                {
                    Console.WriteLine(startingPump);
                    break;
                }

                int[] nextPump = pumpsData.Dequeue();
                pumpsData.Enqueue(nextPump);
            }
        }
    }
}
