using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_OpinionPoll
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }
            List<Person> membersAbove30 = family.GetMembersAbove30();
            Console.WriteLine(string.Join(Environment.NewLine, membersAbove30));
        }
    }
}
