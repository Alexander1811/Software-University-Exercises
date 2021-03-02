using Microsoft.VisualBasic;
using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double grade;
            double sum = 0;
            int year = 0;

            while (year != 12)
            {
                grade = double.Parse(Console.ReadLine());
                if (grade < 4)
                {
                    grade = double.Parse(Console.ReadLine());
                }
                sum += grade;
                year++;
            }
            double average = sum / 12;
            Console.WriteLine($"{name} graduated. Average grade: {average:F2}");
        }
    }
}
