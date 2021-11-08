using System;

namespace P02_Divison
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int searchedNum = 0;

            if (number % 10 == 0)
            {
                searchedNum = 10;
            }
            else if (number % 7 == 0)
            {
                searchedNum = 7;
            }
            else if (number % 6 == 0)
            {
                searchedNum = 6;
            }
            else if (number % 3 == 0)
            {
                searchedNum = 3;
            }
            else if (number % 2 == 0)
            {
                searchedNum = 2;
            }

            if (searchedNum != 0)
            {
                Console.WriteLine($"The number is divisible by {searchedNum}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
