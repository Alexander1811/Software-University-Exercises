using System;
using System.Text.RegularExpressions;

namespace P03_SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalSum = 0;

            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                string orderPattern = @"^%(?<customer>[A-Z]{1}[a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";

                Match expression = Regex.Match(input, orderPattern);
                double currentSum = 0;

                if (expression.Success)
                {
                    string customer = expression.Groups["customer"].Value;
                    string product = expression.Groups["product"].Value;
                    long count = long.Parse(expression.Groups["count"].Value);
                    double price = double.Parse(expression.Groups["price"].Value);

                    currentSum += price * count;
                    totalSum += currentSum;

                    Console.WriteLine($"{customer}: {product} - {currentSum:F2}");
                }
            }

            Console.WriteLine($"Total income: {totalSum:F2}");
        }
    }
}
