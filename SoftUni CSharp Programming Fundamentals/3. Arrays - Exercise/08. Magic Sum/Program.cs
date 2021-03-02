using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console
                            .ReadLine()
                            .Split()
                            .Select(e => int.Parse(e))
                            .ToArray();

            int num = int.Parse(Console.ReadLine());
            int currentSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    currentSum = array[i] + array[j];
                    if (currentSum == num)
                    {
                        Console.WriteLine(array[i] + " " + array[j]);
                    }
                }
            }
        }
    }
}
