using System;

namespace P01_ExamSubmissions
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int problems = int.Parse(Console.ReadLine());

            double submissions = students * Math.Ceiling(problems * 2.8);
            submissions += students * (problems / 3);

            double fiveKiloByteUnits = Math.Ceiling(submissions / 10);

            Console.WriteLine($"{5 * fiveKiloByteUnits} KB needed");
            Console.WriteLine($"{submissions} submissions");

        }
    }
}
