using System;

namespace _09._Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double grade;
            double sum = 0;
            int year = 0;
            int numberOfFailures = 0;

            while (year != 12)
            {
                grade = double.Parse(Console.ReadLine());
                if (grade < 4)
                {
                    numberOfFailures++;
                    if (numberOfFailures > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {year} grade");
                        break;
                    }
                }
                sum += grade;
                year++;
            }
            if (numberOfFailures < 2)
            {
                double average = sum / 12;
                Console.WriteLine($"{name} graduated. Average grade: {average:F2}");
            }
        }
    }
}
