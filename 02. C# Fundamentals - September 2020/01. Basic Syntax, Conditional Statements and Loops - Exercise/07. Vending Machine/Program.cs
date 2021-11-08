using System;

namespace P07_VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            double totalBudget = 0;
            while (command != "Start")
            {
                command = Console.ReadLine();
                if (command == "Start")
                {
                    break;
                }

                double currentCoin = double.Parse(command);
                if (currentCoin == 0.1 || currentCoin == 0.2 || currentCoin == 0.5 || currentCoin == 1 || currentCoin == 2)
                {
                    totalBudget += currentCoin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentCoin}");
                }
            }
            while (command != "End")
            {
                command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string currentProduct = command;
                double currentPrice = 0;

                if (currentProduct == "Nuts" || currentProduct == "Water" || currentProduct == "Crisps" || currentProduct == "Soda" || currentProduct == "Coke")
                {
                    switch (currentProduct)
                    {
                        case "Nuts":
                            currentPrice = 2.0; break;
                        case "Water":
                            currentPrice = 0.7; break;
                        case "Crisps":
                            currentPrice = 1.5; break;
                        case "Soda":
                            currentPrice = 0.8; break;
                        case "Coke":
                            currentPrice = 1.0; break;
                        default:
                            break;
                    }
                   
                    if (totalBudget < currentPrice)
                    {
                        Console.WriteLine("Sorry, not enough money.");
                    }
                    else
                    {
                        Console.WriteLine($"Purchased {currentProduct.ToLower()}");
                        totalBudget -= currentPrice;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }
            Console.WriteLine($"Change: {totalBudget:F2}");
        }
    }
}
