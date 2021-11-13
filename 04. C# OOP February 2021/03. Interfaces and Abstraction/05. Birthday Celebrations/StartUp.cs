using System;
using System.Collections.Generic;
using System.Linq;
using P05_BirthdayCelebrations.Contracts;
using P05_BirthdayCelebrations.Models;

namespace P05_BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string type = command[0];

                if (type == nameof(Citizen))
                {
                    string name = command[1];
                    int age = int.Parse(command[2]);
                    string id = command[3];
                    string birthdate = command[4];

                    Citizen citizen = new Citizen(name, age, id, birthdate);

                    birthables.Add(citizen);
                }
                else if (type == nameof(Robot))
                {
                    string model = command[1];
                    string id = command[2];

                    Robot robot = new Robot(model, id);
                }
                else if (type == nameof(Pet))
                {
                    string name = command[1];
                    string birthdate = command[2];

                    Pet pet = new Pet(name, birthdate);

                    birthables.Add(pet);
                }
            }

            string filterYear = Console.ReadLine();

            List<IBirthable> filteredIdentifiables = birthables.Where(identifiable => identifiable.Birthdate.EndsWith(filterYear)).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, filteredIdentifiables.Select(identifiable => identifiable.Birthdate)));
        }
    }
}
