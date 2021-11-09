using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(" ");
                string name = input[0];
                string id = input[1];
                int age = int.Parse(input[2]);

                Person currentPerson = new Person(name, id, age);

                people.Add(currentPerson);
            }

            List<Person> sortedPeople = people.OrderBy(e => e.Age).ToList();

            foreach (Person person in sortedPeople)
            {
                Console.WriteLine(person);
            }
        }
    }

    class Person
    {
        public Person(string name, string id, int age)
        {

            Name = name;
            ID = id;
            Age = age;
        }

        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
