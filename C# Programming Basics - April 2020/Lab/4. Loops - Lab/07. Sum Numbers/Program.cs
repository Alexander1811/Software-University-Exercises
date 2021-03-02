using System;

namespace _07._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < amount; i++)
            {
                int curentNumber = int.Parse(Console.ReadLine());
                sum += curentNumber;
            }
            Console.WriteLine(sum);
        }
    }
}
