using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" ").ToArray();
                Student current = new Student(input[0], input[1], input[2]);
                students.Add(current);
            }

            List<Student> sortedStudents = students.OrderByDescending(e => e.Grade).ToList();

            foreach (Student student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }
    }

    class Student
    {
        public Student(string firstName, string secondName, string grade)
        {
            FirstName = firstName;
            SecondName = secondName;
            Grade = grade;
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {SecondName}: {Grade}";
        }
    }
}
