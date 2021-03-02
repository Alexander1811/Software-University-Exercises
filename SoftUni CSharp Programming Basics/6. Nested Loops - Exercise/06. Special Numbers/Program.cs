using System;

namespace _06._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (int number = 1111; number < 10000; number++)
            {
                string numberString = Convert.ToString(number);
                int magicalCounter = 0;

                for (int digit = 0; digit < numberString.Length; digit++)
                {
                    int numberDigit = int.Parse(Convert.ToString(numberString[digit]));
                    
                    if (numberDigit != 0)
                    {
                        if (N % numberDigit == 0)
                        {
                            magicalCounter++;
                        }
                    }

                    if (magicalCounter >= numberString.Length)
                    {
                        Console.Write(number + " ");
                    }
                }                              
            }
        }
    }
}
