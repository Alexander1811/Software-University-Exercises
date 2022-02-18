using System;

namespace P05_Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double coinsInput = double.Parse(Console.ReadLine());
            double change = Math.Floor(coinsInput * 100);
            double count = 0;

            while (change != 0)
            {
                if (change >= 200)
                {
                    double num = Math.Floor(change / 100);
                    double twolevas = Math.Floor(num / 2);
                    double leftCoins = num % 2;

                    count += twolevas;

                    change %= 100;
                    change += leftCoins * 100;
                }
                if (change >= 100)
                {
                    change -= 100;
                    count++;

                }
                else if (change >= 50)
                {
                    change -= 50;
                    count++;

                }
                else if (change >= 20)
                {
                    change -= 20;
                    count++;

                }
                else if (change >= 10)
                {
                    change -= 10;
                    count++;

                }
                else if (change >= 5)
                {
                    change -= 5;
                    count++;

                }
                else if (change >= 2)
                {
                    change -= 2;
                    count++;

                }
                else if (change >= 1)
                {
                    change -= 1;
                    count++;

                }
            }

            Console.WriteLine(count);
        }
    }
}
