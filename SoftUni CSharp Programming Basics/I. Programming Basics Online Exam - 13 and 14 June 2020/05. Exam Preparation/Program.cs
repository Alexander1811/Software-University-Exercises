using System;

namespace _05._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int problems = int.Parse(Console.ReadLine());
            int energyTrainer = int.Parse(Console.ReadLine());
            int totalSolvedProblems = 0;
            int totalQuestionsAsked = 0;
            int currentQuestions;

            while (true)
            {                
                energyTrainer += 2 * problems;
                students -= problems;
                totalSolvedProblems += problems;
                currentQuestions = students * 2;
                energyTrainer -= 3 * (currentQuestions);
                totalQuestionsAsked += currentQuestions;

                students += (students / 10);
                if (students < 10)
                {
                    Console.WriteLine("The students are too few!");
                    Console.WriteLine($"Problems solved: {totalSolvedProblems}"); 
                    break;
                }
                if (energyTrainer <= 0)
                {
                    Console.WriteLine("The trainer is too tired!");
                    Console.WriteLine($"Questions asked: {totalQuestionsAsked}");
                    break;
                }
            }
        }
    }
}
