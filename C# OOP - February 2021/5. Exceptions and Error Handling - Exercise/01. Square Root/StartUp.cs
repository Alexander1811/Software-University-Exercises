using System;

namespace _01._Square_Root
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                double result = CalculateSquareRoot(input);

                Console.WriteLine($"{result:F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
        public static double CalculateSquareRoot(string input)
        {
            int number;
            bool isParsed = int.TryParse(input, out number);

            if (isParsed == false)
            {
                throw new ArgumentException("Number should be of type integer");
            }

            if (number < 0)
            {
                throw new ArgumentException("Number should be positive");
            }

            double result = Math.Sqrt(number);

            return result;
        }
    }
}
