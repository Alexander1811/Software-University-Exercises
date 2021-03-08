using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Generic_Swap_Method_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<int>> boxes = new List<Box<int>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                boxes.Add(new Box<int>(int.Parse(Console.ReadLine())));
            }

            int[] indices = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Swap(boxes, indices[0], indices[1]);

            foreach (Box<int> box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        static void Swap<T>(List<Box<T>> list, int index1, int index2)
        {
            Box<T> temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
