using System;
using System.Linq;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //You are given two lines – the first one can be a really big number(0 to 1050).The second one will be a single digit number(0 to 9). You must display the product of these numbers.
            //Note: do not use the BigInteger class.
            //Examples
            //Input                                 Output
            //23
            //2	                                    46

            //9999
            //9	                                    89991

            //923847238931983192462832102
            //4	                                    3695388955727932769851328408

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

            if (multiplier == 0) //fourth test zero answer; first, second and fifth are normal
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(sb);

            }

            //the third test still falling
        }
    }
}
