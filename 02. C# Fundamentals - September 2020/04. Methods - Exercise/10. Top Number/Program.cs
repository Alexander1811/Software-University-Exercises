using System;

namespace P10_TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                if (IsDivisbleByEight(i) && HoldsAtLeastOneOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        
        static bool IsDivisbleByEight(int number)
        {
            int sum = 0;
            int length = Convert.ToString(number).Length;
            for (int i = 0; i < length; i++)
            {
                int digit = number % 10;
                number /= 10;
                sum += digit;
            }

            if (sum % 8 == 0)
            {
                return true;
            }

            return false;
        }

        static bool HoldsAtLeastOneOddDigit(int number)
        {
            int length = Convert.ToString(number).Length;
            for (int i = 0; i < length; i++)
            {
                int digit = number % 10;
                number /= 10;
                if (digit % 2 != 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
