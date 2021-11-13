using System;

namespace P01_NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int currentNumber = 1;

            for (int rows = 1; rows <= number; rows++)
            {
                for (int columns = 1; columns <= rows; columns++)
                {
                    Console.Write(currentNumber + " ");
                    currentNumber++; 
                    if (currentNumber > number)
                    {
                        break;
                    }                    
                }
                if (currentNumber > number)
                {
                    break;
                }
                Console.WriteLine();
               
            }
        }
    }
}
