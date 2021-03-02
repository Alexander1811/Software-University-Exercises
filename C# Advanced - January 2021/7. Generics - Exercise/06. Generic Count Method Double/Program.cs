using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<double>> boxes = new List<Box<double>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                boxes.Add(new Box<double>(double.Parse(Console.ReadLine())));
            }

            double element = double.Parse(Console.ReadLine());

            Console.WriteLine(CountGreater(boxes, element));
        }

        static double CountGreater<T>(List<Box<T>> boxes, T element)
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
