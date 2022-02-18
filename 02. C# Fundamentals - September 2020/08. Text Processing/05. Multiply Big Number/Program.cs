using System;
using System.Text;

namespace P05_MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int remainder = 0;

            char[] number = Console.ReadLine().ToCharArray();
            int multiplier = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int currentNum = number[i] - 48;

                int currentSum = currentNum * multiplier + remainder;

                int currentDigit = currentSum % 10 + 48;

                sb.Insert(0, (char)currentDigit);

                remainder = currentSum / 10;
            }

            if (remainder > 0)
            {
                sb.Insert(0, remainder);
            }

            if (multiplier == 0) 
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(sb);

            }

            //the third test still fails
        }
    }
}
