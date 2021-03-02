using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num;
            int maxNum = int.MinValue;

            while (n != 0)
            {
                num = int.Parse(Console.ReadLine());
                if (num > maxNum)
                {
                    maxNum = num;
                }
                n--;
            }
            Console.WriteLine(maxNum);
        }
    }
}
