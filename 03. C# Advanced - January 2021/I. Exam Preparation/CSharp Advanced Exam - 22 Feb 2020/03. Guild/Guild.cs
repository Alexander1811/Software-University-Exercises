using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private Dictionary<string, Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new Dictionary<string, Player>();
        }

        public int Count => this.roster.Count;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(player.Name, player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = this.roster.Values.FirstOrDefault(player => player.Name == name);

            if (player == null)
            {
               return false;
            }            
            
            return this.roster.Remove(player.Name);
        }

        public void PromotePlayer(string name)
        {
            Player player = this.roster.Values.FirstOrDefault(player => player.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = this.roster.Values.FirstOrDefault(player => player.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classType)
        {
            Player[] players = this.roster.Values.Where(player => player.Class == classType).ToArray();

            foreach (Player player in players)
            {
                this.roster.Remove(player.Name);
            }            

            return players;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Players in the guild: {this.Name}");

            foreach (Player player in this.roster.Values)
            {
                result.Append(player);
            }

            return result.ToString().Trim();
        }        
    }
}
