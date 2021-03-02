
using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                if (isDivisbleByEight(i) && holdsAtLeastOneOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }

            static bool isDivisbleByEight(int number)
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
            static bool holdsAtLeastOneOddDigit(int number)
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
}
