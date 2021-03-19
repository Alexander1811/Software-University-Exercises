using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            int lectures = int.Parse(Console.ReadLine());
            int initialAdditionalBonus = int.Parse(Console.ReadLine());

            double[] studentsAttendancesTotal = new double[students];
            double[] studentBonuses = new double[students];

            for (int i = 0; i < students; i++)
            {
                double studentAttendances = double.Parse(Console.ReadLine());
                double studentBonus = Math.Ceiling(studentAttendances / lectures * (5 + initialAdditionalBonus));

                studentsAttendancesTotal[i] = studentAttendances;
                studentBonuses[i] = studentBonus;
            }

            double maximalBonus = studentBonuses.Max();
            double maximalLecturesAttended = studentsAttendancesTotal.Max();

            Console.WriteLine($"Max Bonus: {maximalBonus}.");
            Console.WriteLine($"The student has attended {maximalLecturesAttended} lectures.");
        }
    }
}
