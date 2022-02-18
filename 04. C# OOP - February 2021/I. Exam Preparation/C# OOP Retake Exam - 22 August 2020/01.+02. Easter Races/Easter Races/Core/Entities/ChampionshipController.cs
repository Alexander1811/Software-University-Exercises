namespace EasterRaces.Core.Entities
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Cars.Contracts;
    using Models.Cars.Entities;
    using Models.Drivers.Contracts;
    using Models.Drivers.Entities;
    using Models.Races.Contracts;
    using Models.Races.Entities;
    using Repositories.Contracts;
    using Repositories.Entities;
    using Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private const int MinParticipantsCount = 3;

        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<ICar> carRepository;
        private readonly IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);

            if (this.driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            this.driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            type += "Car";

            ICar car = null;

            switch (type)
            {
                case nameof(MuscleCar):
                    car = new MuscleCar(model, horsePower);
                    break;
                case nameof(SportsCar):
                    car = new SportsCar(model, horsePower);
                    break;
                default:
                    car = null;
                    break;
            }

            if (this.carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            this.carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, type, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);

            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.driverRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            ICar car = this.carRepository.GetByName(carModel);

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IDriver driver = this.driverRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < MinParticipantsCount)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MinParticipantsCount));
            }

            IDriver[] winners = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToArray();
            IDriver firstDriver = winners[0];
            IDriver secondDriver = winners[1];
            IDriver thirdDriver = winners[2];

            this.driverRepository.GetByName(firstDriver.Name).WinRace();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, firstDriver.Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, secondDriver.Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, thirdDriver.Name, race.Name));

            this.raceRepository.Remove(race);

            return sb.ToString().Trim();
        }
    }
}
