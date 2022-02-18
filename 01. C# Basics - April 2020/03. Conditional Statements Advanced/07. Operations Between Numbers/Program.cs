using System;

namespace P07_OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine()); 

            double result = 0;
            bool isEven = false;            

            if (operation == '+')
            {
                result = N1 + N2;
                isEven = result % 2 == 0;
                switch (isEven)
                {
                    case true:
                        Console.WriteLine($"{N1} {operation} {N2} = {result} - even");
                        break;
                    case false:
                        Console.WriteLine($"{N1} {operation} {N2} = {result} - odd");
                        break;
                }
            }
            if (operation == '-')
            {
                result = N1 - N2;
                isEven = result % 2 == 0;
                switch (isEven)
                {
                    case true:
                        Console.WriteLine($"{N1} {operation} {N2} = {result} - even");
                        break;
                    case false:
                        Console.WriteLine($"{N1} {operation} {N2} = {result} - odd");
                        break;
                }
            }
            if (operation == '*')
            {
                result = N1 * N2;
                isEven = result % 2 == 0;
                switch (isEven)
                {
                    case true:
                        Console.WriteLine($"{N1} {operation} {N2} = {result} - even");
                        break;
                    case false:
                        Console.WriteLine($"{N1} {operation} {N2} = {result} - odd");
                        break;
                }
            }
            if (operation == '/')
            {
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                else if (N2!=0)
                {
                    result = N1 / N2;
                    Console.WriteLine($"{N1} / {N2} = {result:F2}");
                }
            }
            if (operation == '%')
            {
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                else if (N2 != 0)
                {
                    result = N1 % N2;
                    Console.WriteLine($"{N1} % {N2} = {result}");
                }
                
            }
        }
    }
}
