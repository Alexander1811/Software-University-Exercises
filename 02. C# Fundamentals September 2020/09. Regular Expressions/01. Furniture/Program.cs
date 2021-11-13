using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P01_Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> furniture = new List<string>();

            string purchasePattern = @"^>>(?<name>[A-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";
            decimal totalPrice = 0m;

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match expression = Regex.Match(input, purchasePattern);

                if (expression.Success)
                {
                    string name = expression.Groups["name"].Value;
                    decimal price = decimal.Parse(expression.Groups["price"].Value);
                    long quantity = long.Parse(expression.Groups["quantity"].Value);

                    if (quantity != 0)
                    {
                        furniture.Add(name);
                        totalPrice += price * quantity;
                    }
                }
            }

            Console.WriteLine($"Bought furniture:");
            if (furniture.Count > 0)
            {
                Console.WriteLine($"{string.Join(Environment.NewLine, furniture)}");
            }

            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
