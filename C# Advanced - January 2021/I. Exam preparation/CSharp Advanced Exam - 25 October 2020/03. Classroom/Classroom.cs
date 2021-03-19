using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }
        public string RegisterStudent(Student student)
        {
            if (students.Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(student => firstName == student.FirstName && lastName == student.LastName);
            if (student == null)
            {
                return "Student not found";
            }

            return $"Dismissed student {student.FirstName} {student.LastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> studyingStudents = students.Where(student => subject == student.Subject).ToList();
            if (!studyingStudents.Any())
            {
                return "No students enrolled for the subject";
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine($"Subject: {subject}");
            result.AppendLine("Students:");
            foreach (Student student in studyingStudents)
            {
                result.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return result.ToString();
        }

        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(student => firstName == student.FirstName && lastName == student.LastName);
            if (student == null)
            {
                return null;
            }

            return student;
        }

        public int Capacity { get; set; }
        public int Count { get { return students.Count; } }
    }
}
