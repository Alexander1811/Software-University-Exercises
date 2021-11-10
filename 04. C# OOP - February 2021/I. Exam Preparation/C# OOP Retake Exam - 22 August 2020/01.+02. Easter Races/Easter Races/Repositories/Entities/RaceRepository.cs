namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Races.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly Dictionary<string, IRace> racesByName;

        public RaceRepository()
        {
            this.racesByName = new Dictionary<string, IRace>();
        }

        public IReadOnlyCollection<IRace> Models => this.racesByName.Values.ToList().AsReadOnly();

        public void Add(IRace model)
        {
            this.racesByName.Add(model.Name, model);
        }

        public bool Remove(IRace model)
        {
            return this.racesByName.Remove(model.Name);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.Models;
        }

        public IRace GetByName(string name)
        {
            IRace race = this.Models.FirstOrDefault(r => r.Name == name);

            return race;
        }
    }
}
