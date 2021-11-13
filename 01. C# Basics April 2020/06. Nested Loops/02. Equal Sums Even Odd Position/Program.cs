using System;

namespace P02_EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            if (firstNum >= 100000 && secondNum <= 300000 && firstNum < secondNum)
            {
                for (int i = firstNum; i <= secondNum; i++)
                {
                    string currentStr = Convert.ToString(i);
                    int oddSum = 0;
                    int evenSum = 0;
                    for (int j = 0; j < currentStr.Length; j++)
                    {
                        int currentDigit = int.Parse(Convert.ToString(currentStr[j]));
                        if (j % 2 == 0)
                        {
                            evenSum += currentDigit;
                        }
                        else if (j % 2 != 0)
                        {
                            oddSum += currentDigit;
                        }
                    }
                    if (oddSum == evenSum)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}
