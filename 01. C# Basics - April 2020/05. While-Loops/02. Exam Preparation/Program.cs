using System;

namespace P02_ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int permittedFailures = int.Parse(Console.ReadLine());
            int failures = 0;
            double numberOfProblems = 0;
            double sumOfGrades = 0;
            string lastProblem = "";

            while (failures < permittedFailures)
            {
                string problemName = Console.ReadLine();

                if (problemName == "Enough") 
                {
                    break;
                }

                int grade = int.Parse(Console.ReadLine());

                if (grade <= 4)
                {
                    failures++;
                }

                sumOfGrades += grade;
                numberOfProblems++;
                lastProblem = problemName;
            }

            if (failures >= permittedFailures)
            {
                Console.WriteLine($"You need a break, {permittedFailures} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {sumOfGrades / numberOfProblems:f2}");
                Console.WriteLine($"Number of problems: {numberOfProblems}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
