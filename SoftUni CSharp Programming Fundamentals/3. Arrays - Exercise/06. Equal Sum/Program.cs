using System;
using System.Linq;

namespace _06._Equal_Sum
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
            bool existsIndex = false;

            for (int i = 0; i < array.Length; i++)
            {
                int currentNum = array[i];
                int leftSum = 0;
                int rightSum = 0;
                for (int l = 0; l < i; l++)
                {
                    leftSum += array[l];
                }
                for (int r = i + 1; r < array.Length; r++)
                {
                    rightSum += array[r];
                }
                
                if (leftSum == rightSum)
                {
                    if (array.Length == 1)
                    {
                        Console.WriteLine(0);
                        existsIndex = true;
                        break;
                    }
                    else
                    {
                        existsIndex = true;
                        Console.WriteLine(i);
                    }
                }                
            }
            if (existsIndex == false)
            {
                Console.WriteLine("no");
            }
        }
    }
}
