using System;

namespace P03_SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumPrime = 0;
            int sumNonPrime = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "stop")
                {
                    break;
                }
                int num = int.Parse(command);
                bool isPrime = true;

                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                for (int i = 2; i < num; i++)
                {
                    if (num % i == 0)
                    {
                        sumNonPrime += num;
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime == true)
                {
                    sumPrime += num;
                }
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
        }
    }
}
