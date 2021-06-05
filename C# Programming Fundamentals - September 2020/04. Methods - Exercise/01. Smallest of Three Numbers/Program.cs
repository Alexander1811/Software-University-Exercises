using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int smallest = FindSmallestOfThree(a, b, c);
            Console.WriteLine(smallest);
        }

        static int FindSmallestOfThree(int a, int b, int c)
        {
            int smallest = Math.Min(a, Math.Min(b, c));
            return smallest;
        }
    }
}
