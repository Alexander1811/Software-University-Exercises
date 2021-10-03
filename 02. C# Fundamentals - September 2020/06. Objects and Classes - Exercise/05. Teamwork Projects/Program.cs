using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split("-");

                string creator = input[0];
                string name = input[1];

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

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] input = command.Split("->");
                string member = input[0];
                string name = input[1];

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

// using System;
//using System.Collections.Generic;
//using System.Linq;
////using System.Text;

//public class Team
//{
//    public Team(string name, string creatorName)
//    {
//        TeamName = name;

//        CreatorName = creatorName;

//        Members = new List<string>();

//    }

//    public string TeamName { get; set; }

//    public string CreatorName { get; set; }

//    public List<string> Members { get; set; }
//}

//public class Program
//{
//    public static void Main()
//    {
//        int teamCount = int.Parse(Console.ReadLine());

//        List<Team> allTeam = new List<Team>();

//        for (int i = 0; i < teamCount; i++)
//        {
//            string[] inputForTeam = Console.ReadLine()
//                .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

//            string currentCreator = inputForTeam[0];
//            string currentTeamNeme = inputForTeam[1];

//            // проверка дали тиймът вече не съществува. 
//            // Съобщение, ако вече съществува
//            bool isTeamNameExist = allTeam
//                .Select(x => x.TeamName).Contains(currentTeamNeme);

//            bool isCreatorExist = allTeam
//                .Any(x => x.CreatorName == currentCreator);

//            // проверка дали Инициаторът на Тийма вече не е създал тийм. 
//            // Съобщение, ако вече е създал

//            // if-ови конструкции
//            if (isTeamNameExist == false && isCreatorExist == false)
//            {
//                Team currentTeam = new Team(currentTeamNeme, currentCreator);

//                allTeam.Add(currentTeam);

//                Console.WriteLine("Team {0} has been created by {1}!", currentTeamNeme, currentCreator);
//            }
//            else if (isTeamNameExist)
//            {
//                Console.WriteLine("Team {0} was already created!", currentTeamNeme);
//            }
//            else if (isCreatorExist)
//            {
//                Console.WriteLine("{0} cannot create another team!", currentCreator);
//            }
//        } // end for-circle

//        while (true)
//        {
//            string fensForTeam = Console.ReadLine();

//            if (fensForTeam == "end of assignment")
//            {
//                break;
//            }

//            string[] inputAssignment = fensForTeam
//                .Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

//            string fen = inputAssignment[0];

//            string ofFensTeam = inputAssignment[1];

//            // Първа проверка за това, че Тиймът съществува. 
//            // Единствената положителна проверка в алгоритъма на задачата.
//            bool isTeamExist = allTeam.Any(x => x.TeamName == ofFensTeam);

//            // Втора проверка за това дали записващия се не инициатор 
//            // Продължение на втората проверка -дали записващия се 
//            // не се е записал вече в друг тийм.
//            bool isCreatorCheating = allTeam.Any(x => x.CreatorName == fen);
//            bool isAlreadyFen = allTeam.Any(x => x.Members.Contains(fen));

//            if (isTeamExist && isCreatorCheating == false && isAlreadyFen == false)
//            {
//                int indexOfTeam = allTeam
//                    .FindIndex(x => x.TeamName == ofFensTeam);

//                allTeam[indexOfTeam].Members.Add(fen);
//            }
//            else if (isTeamExist == false)
//            {
//                Console.WriteLine("Team {0} does not exist!", ofFensTeam);
//            }
//            else if (isAlreadyFen || isCreatorCheating)
//            {
//                Console.WriteLine("Member {0} cannot join team {1}!", fen, ofFensTeam);
//            }
//        } // END WHILE CIRCLE

//        // Изписване на резултатите
//        // тиймовете с поне един член    се подреждат по азбучен ред 
//        // и се изписват по дадения в задачата ред.

//        List<Team> teamWithMember = allTeam
//            .Where(x => x.Members.Count > 0)
//            .OrderByDescending(x => x.Members.Count)
//            .ThenBy(x => x.TeamName)
//            .ToList();

//        List<Team> notValidTeam = allTeam
//            .Where(x => x.Members.Count == 0)
//            .OrderBy(x => x.TeamName)
//            .ToList();

//        foreach (var team in teamWithMember)
//        {
//            Console.WriteLine(team.TeamName);
//            Console.WriteLine("- " + team.CreatorName);
//            team.Members.Sort();
//            Console.WriteLine(string.Join(Environment.NewLine, team.Members.Select(x => "-- " + x)));
//        }

//        Console.WriteLine("Teams to disband:");

//        foreach (var team in notValidTeam)
//        {
//            Console.WriteLine(team.TeamName);
//        }
//    }
//}

