using System.Text;

namespace P03_Guild
{
    public class Player
    {
        public Player(string name, string classType)
        {
            this.Name = name;
            this.Class = classType;
        }

        public string Name { get; private set; }

        public string Class { get; private set; }

        public string Rank { get; set; } = "Trial";

        public string Description { get; set; } = "n/a";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Player {this.Name}: {this.Class}");
            sb.AppendLine($"Rank: {this.Rank}");
            sb.AppendLine($"Description: {this.Description}");

            return sb.ToString().Trim(); 
        }
    }
}
