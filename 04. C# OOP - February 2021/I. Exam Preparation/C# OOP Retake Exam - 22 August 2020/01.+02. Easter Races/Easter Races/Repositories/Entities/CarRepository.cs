using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly Dictionary<string, ICar> carsbyModel;

        public CarRepository()
        {
            this.carsbyModel = new Dictionary<string, ICar>();
        }

        public IReadOnlyCollection<ICar> Models => this.carsbyModel.Values.ToList().AsReadOnly();

        public void Add(ICar model)
        {
            this.carsbyModel.Add(model.Model, model);
        }

        public bool Remove(ICar model)
        {
            return this.carsbyModel.Remove(model.Model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.Models;
        }

        public ICar GetByName(string name)
        {
            ICar car = this.Models.FirstOrDefault(c => c.Model == name);

            return car;
        }
    }
}
