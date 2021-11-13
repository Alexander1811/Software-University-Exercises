using System;

namespace P06_StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int currentNum = num;
            int currentSummand = 1;
            int sum = 0;

            while (currentNum > 0)
            {
                int digit = currentNum % 10;
                currentNum /= 10;

                for (int i = 1; i <= digit; i++)
                {                    
                    currentSummand *= i;
                }
                sum += currentSummand;
                currentSummand = 1;
            }

            if (sum == num)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
