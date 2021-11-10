namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Drivers.Contracts;

    public class DriverRepository : IRepository<IDriver>
    {
        private readonly Dictionary<string, IDriver> driverByName;

        public DriverRepository()
        {
            this.driverByName = new Dictionary<string, IDriver>();
        }

        public IReadOnlyCollection<IDriver> Models => this.driverByName.Values.ToList().AsReadOnly();

        public void Add(IDriver model)
        {
            this.driverByName.Add(model.Name, model);
        }

        public bool Remove(IDriver model)
        {
            return this.driverByName.Remove(model.Name);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.Models;
        }

        public IDriver GetByName(string name)
        {
            IDriver driver = this.Models.FirstOrDefault(d => d.Name == name);

            return driver;
        }
    }
}
