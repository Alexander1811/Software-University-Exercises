using System;

namespace _02._Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int firstNum = 1; firstNum <= 10; firstNum++)
            {
                for (int secondNum = 1; secondNum <= 10; secondNum++)
                {
                    Console.WriteLine($"{firstNum} * {secondNum} = {firstNum * secondNum}");
                }
            }
        }
    }
}
