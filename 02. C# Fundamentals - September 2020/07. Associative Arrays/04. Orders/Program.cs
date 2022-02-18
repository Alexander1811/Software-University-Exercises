using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> productQuantities = new Dictionary<string, int>();
            Dictionary<string, double> productPrices = new Dictionary<string, double>();

            string command;
            while ((command = Console.ReadLine()) != "buy")
            {
                string[] input = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string product = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                AddToCollections(productQuantities, productPrices, product, price, quantity);
            }

            PrintProducts(productQuantities, productPrices);

        }

        private static void PrintProducts(Dictionary<string, int> productQuantities, Dictionary<string, double> productPrices)
        {
            foreach (var kvp in productPrices)
            {
                string name = kvp.Key;
                double price = kvp.Value;
                long quantity = productQuantities[name];
                double totalPrice = price * quantity;

                Console.WriteLine($"{kvp.Key} -> {totalPrice:f2}");
            }
        }

        private static void AddToCollections(Dictionary<string, int> productQuantities, Dictionary<string, double> productPrices, string product, double price, int quantity)
        {
            if (!productQuantities.ContainsKey(product))
            {
                productQuantities[product] = 0;
                productPrices[product] = 0;
            }

            if (productQuantities.ContainsKey(product))
            {
                productQuantities[product] += quantity;
            }
            if (productPrices.ContainsKey(product))
            {
                productPrices[product] = price;
            }
        }
    }
}
