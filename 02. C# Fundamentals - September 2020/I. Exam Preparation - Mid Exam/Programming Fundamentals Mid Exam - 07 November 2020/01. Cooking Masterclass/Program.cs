using System;

namespace _01._Cooking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            //The input data will always be valid. There is no need to check it explicitly. 

            float budget = float.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            float flourPrice = float.Parse(Console.ReadLine());
            float eggPrice = float.Parse(Console.ReadLine());
            float apronPrice = float.Parse(Console.ReadLine());
            int freePackages = 0;

            for (int i = 1; i <= students; i++)
            {
                if (i % 5 == 0)
                {
                    freePackages++;
                }
            }

            double apronTotal = apronPrice * Math.Ceiling(students * 1.2);
            double eggsTotal = eggPrice * 10 * students;
            double flourTotal = flourPrice * (students - freePackages);

            double sum = apronTotal + eggsTotal + flourTotal;

            if (sum <= budget)
            {
                Console.WriteLine($"Items purchased for {sum:f2}$.");
            }
            else
            {
                Console.WriteLine($"{sum - budget:f2}$ more needed.");
            }
        }
    }
}
