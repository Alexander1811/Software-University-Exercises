using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsList = new Dictionary<string, List<double>>();
            List<double> gradesList = new List<double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsList.ContainsKey(name))
                {
                    gradesList = new List<double>();
                    gradesList.Add(grade);
                    studentsList[name] = gradesList;
                }
                else
                {
                    studentsList[name].Add(grade);
                }
            }

            Dictionary<string, double> orderedStudentsList = ClearAndSortList(studentsList);

            PrintList(orderedStudentsList);
        }

        private static void PrintList(Dictionary<string, double> orderedStudentsList)
        {
            foreach (KeyValuePair<string, double> keyValuePair in orderedStudentsList)
            {
                string name = keyValuePair.Key;
                double averageGrade = keyValuePair.Value;

                Console.WriteLine($"{name} -> {averageGrade:f2}");
            }
        }

        private static Dictionary<string, double> ClearAndSortList(Dictionary<string, List<double>> studentsList)
        {
            Dictionary<string, double> orderedStudentsList = new Dictionary<string, double>();
            Dictionary<string, double> clearedStudentsList = new Dictionary<string, double>();

            foreach (KeyValuePair<string, List<double>> keyValuePair in studentsList) 
            {
                double average = keyValuePair.Value.Sum() / keyValuePair.Value.Count;
                if (average >= 4.5)
                {
                    clearedStudentsList[keyValuePair.Key] = average;
                }
            }

            orderedStudentsList = clearedStudentsList
                .OrderByDescending(m => m.Value)
                .ToDictionary(a => a.Key, b => b.Value);

            return orderedStudentsList;
        }
    }
}
