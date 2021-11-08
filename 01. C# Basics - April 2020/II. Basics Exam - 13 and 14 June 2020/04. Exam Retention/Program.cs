using System;

namespace P04_ExamRetention
{
    class Program
    {
        static void Main(string[] args)
        {
            double students = int.Parse(Console.ReadLine());
            int seasons = int.Parse(Console.ReadLine());
            int currentSeasons = 0;

            while (currentSeasons < seasons)
            {
                currentSeasons++;

                students = Math.Ceiling(students * 90 / 100); 
                students = Math.Ceiling(students * 90 / 100); 

                students = Math.Ceiling(students * 0.8);
                if (currentSeasons % 3 == 0)
                {
                    students = Math.Ceiling(students * 1.15);
                }
                else
                {
                    students = Math.Ceiling(students * 1.05);
                }
            }
            Console.WriteLine($"Students: {students}");
        }
    }
}
