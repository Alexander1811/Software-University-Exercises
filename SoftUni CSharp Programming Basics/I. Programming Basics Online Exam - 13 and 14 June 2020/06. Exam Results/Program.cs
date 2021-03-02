using System;

namespace _06._Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            string name;
            double pointsPerStudent;
            double grade;

            double points = 0;

            while (command != "Midnight")
            {
                bool isCheating = false;

                command = Console.ReadLine();
                if (command == "Midnight")
                {
                    break;
                }

                name = command;
                pointsPerStudent = 0;
                for (int problems = 0; problems < 6; problems++)
                {
                    points = double.Parse(Console.ReadLine());
                    if (points < 0)
                    {
                        Console.WriteLine($"{name} was cheating!");
                        isCheating = true;
                        break;
                    }
                    else
                    {
                        pointsPerStudent += points;
                    }
                }

                double finalPoints = Math.Floor(pointsPerStudent / 600 * 100);
                grade = finalPoints * 0.06;

                if (!isCheating)
                {
                    if (grade >= 5)
                    {
                        Console.WriteLine("===================");
                        Console.WriteLine($"|   CERTIFICATE   |");
                        Console.WriteLine($"|    {grade:f2}/6.00    |");
                        Console.WriteLine("===================");
                        Console.WriteLine($"Issued to {name}");
                    }
                    else if (grade < 5)
                    {
                        if (grade < 3)
                        {
                            Console.WriteLine($"{name} - 2.00");
                        }
                        else
                        {
                            Console.WriteLine($"{name} - {grade:f2}");
                        }
                    }
                }
            }
        }
    }
}