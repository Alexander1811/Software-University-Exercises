using System;

namespace _04._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int beginningNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine()); 
            int magicNumber = int.Parse(Console.ReadLine());
            int firstNumber = beginningNumber;
            int secondNumber = beginningNumber;
            int count = 0;  

            for (firstNumber = beginningNumber; firstNumber <= endNumber; firstNumber++)
            {
                for (secondNumber = beginningNumber; secondNumber <= endNumber; secondNumber++)
                {
                    count++;
                    if (firstNumber + secondNumber == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{count} ({firstNumber} + {secondNumber} = {magicNumber})");
                        return;
                    }
                }
            }
            if (firstNumber + secondNumber != magicNumber)
            {
                Console.WriteLine($"{count} combinations - neither equals {magicNumber}");
            }
        }
    }
}
