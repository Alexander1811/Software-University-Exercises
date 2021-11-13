using System.Collections.Generic;
using System.Text;
using P07_MilitaryElite.Contracts;
using P07_MilitaryElite.Enums;

namespace P07_MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => this.missions.AsReadOnly();

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");
            foreach (IMission mission in this.Missions)
            {
                sb.AppendLine($"  {mission}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
