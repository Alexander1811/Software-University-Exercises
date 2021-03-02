using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Comapring_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int equalCounter = 0;
            int differentCounter = 0;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(" ").ToArray();
                people.Add(new Person(command[0], int.Parse(command[1]), command[2]));
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            Person person = people[index];

            foreach (Person man in people)
            {
                if (man.CompareTo(person) == 0)
                {
                    equalCounter++;
                }
                else
                {
                    differentCounter++;
                }
            }

            if (equalCounter > 1)
            {
                Console.WriteLine($"{equalCounter} {differentCounter} {equalCounter + differentCounter}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
