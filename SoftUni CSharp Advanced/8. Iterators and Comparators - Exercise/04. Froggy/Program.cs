using System;
using System.Linq;

namespace _04._Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] stones = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Lake lake = new Lake(stones);

            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
