using System;

namespace _02._Enter_Numbers
{
    public class StartUp
    {
        private const int MinValue = 1;
        private const int MaxValue = 100;

        public static void Main(string[] args)
        {
            ReadNumber(MinValue, MaxValue);
        }

        private static void ReadNumber(int minValue, int maxValue)
        {
            int numbersCount = 0;
            do
            {
                try
                {
                    string currentInput = Console.ReadLine();
                    int currentNumber;

                    bool isParsed = int.TryParse(currentInput, out currentNumber);

                    if (isParsed == false)
                    {
                        numbersCount = 0;
                        throw new ArgumentException("Number should be of type integer" + Environment.NewLine + "Enter the numbers again!");
                    }

                    if (currentNumber <= minValue || currentNumber >= maxValue)
                    {
                        numbersCount = 0;
                        throw new ArgumentException($"Number should be in the range [{minValue}-{maxValue}]" + Environment.NewLine + "Enter the numbers again!");
                    }

                    numbersCount++;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            while (numbersCount < 10);

            Console.WriteLine("You successfully entered 10 integers");
        }
    }
}
