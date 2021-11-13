using System;

namespace P04_TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            double people = double.Parse(Console.ReadLine()); ;
            string name = "";
            double sumTotalRating = 0;
            
            double ratingsCount = 0;

            while (name != "Finish")
            {
                name = Console.ReadLine();
                if (name == "Finish")
                {
                    break;
                }

                double sumCurrentRating = 0;
                for (int i = 0; i < people; i++)
                {
                    double rating = double.Parse(Console.ReadLine());
                    sumCurrentRating += rating;
                }
                sumTotalRating += sumCurrentRating;
                ratingsCount++;
                Console.WriteLine($"{name} - {sumCurrentRating/people:f2}.");
            }
            Console.WriteLine($"Student's final assessment is {sumTotalRating/ratingsCount/people:f2}.");
        }
    }
}
