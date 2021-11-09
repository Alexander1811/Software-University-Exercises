using System;
using System.Collections.Generic;

namespace P05_GenericCountMethodString
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

            string element = Console.ReadLine();

            Console.WriteLine(CountGreater(boxes, element));
        }

        static int CountGreater<T>(List<Box<T>> boxes, T element)
            where T : IComparable<T>
        {
            int counter = 0;

            foreach (Box<T> item in boxes)
            {
                if (item.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
