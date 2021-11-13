using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < count; i++)
            {
                string[] command = Console.ReadLine().Split("-");

                string creator = command[0];
                string name = command[1];

                Team exisitngTeam = teams.Find(e => e.Name == name);
                Team exisitngTeamCreator = teams.Find(e => e.Creator == creator);

                if (exisitngTeam != null)
                {
                    Console.WriteLine($"Team {name} was already created!");
                    continue;
                }
                if (exisitngTeamCreator != null)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team currentTeam = new Team(creator, name);

                teams.Add(currentTeam);

                Console.WriteLine($"Team {name} has been created by {creator}!");
            }

            string input;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] command = input.Split("->");
                string member = command[0];
                string name = command[1];

                Team exisitngTeam = teams.Find(e => e.Name == name);
                Team exisitngTeamMember = teams.Find(e => e.Members.Contains(member) || e.Creator == member);

                if (exisitngTeam == null)
                {
                    Console.WriteLine($"Team {name} does not exist!");
                    continue;
                }
                if (exisitngTeamMember != null)
                {
                    Console.WriteLine($"Member {member} cannot join team {name}!");
                    continue;
                }

                exisitngTeam.Members.Add(member);
            }

            List<string> disbandedTeams = teams
                .Where(e => e.Members.Count == 0)
                .OrderBy(e => e.Name)
                .Select(e => e.Name)
                .ToList();

            teams.RemoveAll(e => e.Members.Count == 0);

            List<Team> sortedTeams = teams
                .OrderByDescending(e => e.Members.Count)
                .ThenBy(e => e.Name)
                .ToList();

            foreach (Team team in sortedTeams)
            {
                Console.WriteLine(team);
            }

            Console.WriteLine("Teams to disband:");
            foreach (string team in disbandedTeams)
            {
                Console.WriteLine(team);
            }
        }
    }

    class Team
    {
        public Team(string creator, string name)
        {
            Creator = creator; 
            Name = name;
            Members = new List<string>();
        }

        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name}");
            sb.AppendLine($"- {Creator}");
            foreach (string member in Members)
            {
                sb.AppendLine($"-- {member}");
            }

            return sb.ToString().Trim();
        }
    }
}