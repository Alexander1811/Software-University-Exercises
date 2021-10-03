using System;
using _06._Valid_Person.Exceptions;

namespace _06._Valid_Person
{

    public class Person
    {
        private const int MinAge = 0;
        private const int MaxAge = 120;

        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "The first name cannot be null or empty.");
                }

                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                    {
                        throw new InvalidPersonNameException();
                    }
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "The last name cannot be null or empty.");
                }

                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                    {
                        throw new InvalidPersonNameException();
                    }
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("value", $"Age should be in the range [{MinAge} ... {MaxAge}].");
                }

                this.age = value;
            }
        }
    }
}
