using System;
using System.Linq;

namespace _05._Top_Integers
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
            string result = "";

            for (int i = 0; i < array.Length; i++)
            {
                int currentNum = array[i];
                bool isTopInteger = true;

                for (int j = i+1; j < array.Length; j++)
                {
                    int followingNum = array[j];
                    if (currentNum <= followingNum)
                    {
                        isTopInteger = false;
                        break;
                    }
                }
                if (isTopInteger)
                {
                    result += currentNum + " ";
                }
            }
            Console.WriteLine(result);
        }
    }
}
