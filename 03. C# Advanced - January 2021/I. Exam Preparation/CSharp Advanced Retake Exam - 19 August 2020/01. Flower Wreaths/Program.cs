using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MinFlowersCount = 15;
            const int MinWreathsCount = 5;

            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            int wreathsCount = 0;
            int flowersLeft = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int rose = roses.Peek();
                int lily = lilies.Peek();

                int sum = rose + lily;
                while (sum > MinFlowersCount)
                {
                    lily -= 2;

                    sum = rose + lily;
                }
                if (sum == MinFlowersCount)
                {
                    wreathsCount++;
                }
                else if (sum < MinFlowersCount)
                {
                    sum = rose + lily;

                    flowersLeft += sum;
                }

                lilies.Pop();
                roses.Dequeue();
            }

            if (flowersLeft > 0)
            {
                wreathsCount += flowersLeft / MinFlowersCount;// + lilies.Sum() + roses.Sum();
            }

            if (wreathsCount >= MinWreathsCount)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {MinWreathsCount - wreathsCount} wreaths more!");
            }
        }
    }
}
