using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num;
            int minNum = int.MaxValue;

            while (n != 0)
            {
                num = int.Parse(Console.ReadLine());
                if (num < minNum)
                {
                    minNum = num;
                }
                n--;
            }
            Console.WriteLine(minNum);
        }
    }
}
