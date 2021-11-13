using System;
using System.Collections.Generic;
using System.Linq;
using P04_BorderControl.Contracts;
using P04_BorderControl.Models;

namespace P04_BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command.Length == 3)
                {
                    string name = command[0];
                    int age = int.Parse(command[1]);
                    string id = command[2];

                    Citizen citizen = new Citizen(name, age, id);

                    identifiables.Add(citizen);
                }
                else if (command.Length == 2)
                {
                    string model = command[0];
                    string id = command[1];

                    Robot robot = new Robot(model, id);

                    identifiables.Add(robot);

                }
            }

            string filterId = Console.ReadLine();

            List<IIdentifiable> filteredIdentifiables = identifiables.Where(identifiable => identifiable.Id.EndsWith(filterId)).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, filteredIdentifiables.Select(identifiable => identifiable.Id)));
        }
    }
}
