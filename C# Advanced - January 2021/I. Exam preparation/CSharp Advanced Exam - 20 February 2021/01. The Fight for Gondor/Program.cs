using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesCount = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Stack<int> orcs = new Stack<int>(new[] { 1 });

            for (int waves = 1; plates.Count > 0 && waves <= wavesCount; waves++)
            {
                orcs = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));

                if (waves % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }
                int currentPlate = plates.Peek();
                int currentOrc = orcs.Peek();

                while (orcs.Count > 0 && plates.Count > 0)
                {
                    currentOrc = orcs.Peek();
                    int result = currentPlate - currentOrc;

                    if (result > 0)
                    {
                        currentPlate -= currentOrc;
                        orcs.Pop();
                    }
                    else if (result < 0)
                    {
                        currentOrc -= currentPlate;

                        currentPlate = plates.Dequeue();
                    }
                    else
                    {
                        plates.Dequeue();
                        orcs.Pop();
                    }
                }

                if ((waves == wavesCount || plates.Count <= 0) && orcs.Count > 0)
                {
                    orcs.Pop();
                    orcs.Push(currentOrc);
                }
            }


            if (plates.Count <= 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            }
            else if (orcs.Count <= 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
            }
            if (orcs.Count > 0)
            {
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            if (plates.Count > 0)
            {
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}