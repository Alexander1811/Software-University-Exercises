using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> coursesList = new Dictionary<string, List<string>>();
            List<string> studentsList = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split(" : ").ToArray();

                string courseName = command[0];
                string studentName = command[1];

                if (!coursesList.ContainsKey(courseName))
                {
                    studentsList = new List<string>();
                    studentsList.Add(studentName);
                    coursesList[courseName] = studentsList;
                }
                else if (coursesList.ContainsKey(courseName))
                {
                    coursesList[courseName].Add(studentName);
                }
            }

            Dictionary<string, List<string>> orderedCoursesList = SortList(coursesList);

            PrintList(orderedCoursesList);
        }

        private static void PrintList(Dictionary<string, List<string>> orderedCoursesList)
        {
            foreach (KeyValuePair<string, List<string>> keyValuePair in orderedCoursesList)
            {
                string courseName = keyValuePair.Key;
                int registeredStudents = keyValuePair.Value.Count;

                Console.WriteLine($"{courseName}: {registeredStudents}");

                foreach (string studentName in keyValuePair.Value)
                {
                    Console.WriteLine($"-- {studentName}");
                }
            }
        }

        private static Dictionary<string, List<string>> SortList(Dictionary<string, List<string>> coursesList)
        {
            Dictionary<string, List<string>> orderedCoursesList = coursesList.OrderByDescending(m => m.Value.Count).ToDictionary(a => a.Key, b => b.Value); //sort each key
            foreach (KeyValuePair<string, List<string>> keyValuePair in orderedCoursesList) //sort names in each value
            {
                List<string> orderedStudentsList = keyValuePair.Value;
                orderedStudentsList.Sort();
            }

            return orderedCoursesList;
        }
    }
}
