using System;

namespace _08._Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount = int.Parse(Console.ReadLine());
            int maxNum = int.MinValue;
            int minNum = int.MaxValue;

            for (int i = 0; i < amount; i++)
            {
                int curentNumber = int.Parse(Console.ReadLine());
                if (curentNumber > maxNum)
                {
                    maxNum = curentNumber;
                }
                if (curentNumber < minNum)
                {
                    minNum = curentNumber;
                }
            }

            Console.WriteLine($"Max number: {maxNum}");
            Console.WriteLine($"Min number: {minNum}");
        }
    }
}
