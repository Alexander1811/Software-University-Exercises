using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int MinNameLength = 5;

        private string name;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpaceOrLessThenMinLength(value, MinNameLength, string.Format(ExceptionMessages.InvalidName, value, MinNameLength));

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Car != null;

        public void AddCar(ICar car)
        {
            Validator.ThrowIfObjectIsNull(car, ExceptionMessages.CarInvalid);

            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
