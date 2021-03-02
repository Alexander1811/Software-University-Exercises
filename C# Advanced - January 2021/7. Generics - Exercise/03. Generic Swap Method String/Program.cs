using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                boxes.Add(new Box<string>(Console.ReadLine()));
            }

            int[] indices = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Swap(boxes, indices[0], indices[1]);

            foreach (Box<string> box in boxes)
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
