using System;
using System.Collections.Generic;
using System.Linq;
using P07_MilitaryElite.Contracts;
using P07_MilitaryElite.Models;
using P07_MilitaryElite.Enums;

namespace P07_MilitaryElite
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, ISoldier> soldiersById = new Dictionary<string, ISoldier>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" ").ToArray();

                string type = command[0];
                string id = command[1];
                string firstName = command[2];
                string lastName = command[3];

                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(command[4]);

                    IPrivate @private = new Private(id, firstName, lastName, salary);

                    soldiersById[id] = @private;
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(command[4]);

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < command.Length; i++)
                    {
                        string privateId = command[i];

                        Private @private = (Private)soldiersById[privateId];

                        if (!soldiersById.ContainsKey(privateId))
                        {
                            continue;
                        }

                        lieutenantGeneral.AddPrivate(@private);
                    }


                    soldiersById[id] = lieutenantGeneral;
                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(command[4]);

                    bool isCorpsValid = Enum.TryParse(command[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < command.Length; i += 2)
                    {
                        string partName = command[i];
                        int hoursWorked = int.Parse(command[i + 1]);

                        IRepair repair = new Repair(partName, hoursWorked);

                        engineer.AddRepair(repair);
                    }

                    soldiersById[id] = engineer;
                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(command[4]);

                    bool isCorpsValid = Enum.TryParse(command[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < command.Length; i += 2)
                    {
                        string codeName = command[i];

                        bool isMissionStateValid = Enum.TryParse(command[i + 1], out MissionState missionState);

                        if (!isMissionStateValid)
                        {
                            continue;
                        }

                        IMission mission = new Mission(codeName, missionState);

                        commando.AddMission(mission);
                    }

                    soldiersById[id] = commando;
                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(command[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiersById[id] = spy;
                }
            }

            foreach (ISoldier soldier in soldiersById.Values)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
