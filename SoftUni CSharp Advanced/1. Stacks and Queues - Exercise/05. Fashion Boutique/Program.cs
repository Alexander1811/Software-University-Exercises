using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInBox = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            int currentRackCapacity = rackCapacity;
            int racks = 1;

            Stack<int> clothes = new Stack<int>(clothesInBox);

            while (clothes.Peek() == 0) // remove intial zeros
            {
                clothes.Pop();
                if (!clothes.Any())
                {
                    racks = 0;
                    break;
                }
            }

            while (clothes.Count > 0)
            {
                if (clothes.Peek() == 0) //remove zeros in the middle
                {
                    clothes.Pop();
                    continue;
                }

                if (currentRackCapacity - clothes.Peek() > 0) //enough space and space left
                {
                    currentRackCapacity -= clothes.Pop();
                }
                else if (currentRackCapacity - clothes.Peek() == 0) //just enough space
                {
                    currentRackCapacity -= clothes.Pop();
                    currentRackCapacity = rackCapacity;
                    if (clothes.Any())
                    {
                        racks++;
                    }
                    continue;
                }
                else if (currentRackCapacity - clothes.Peek() < 0) //not enough
                {
                    currentRackCapacity = rackCapacity;
                    racks++;
                    continue;
                }
            }

            Console.WriteLine(racks);
        }
    }
}
