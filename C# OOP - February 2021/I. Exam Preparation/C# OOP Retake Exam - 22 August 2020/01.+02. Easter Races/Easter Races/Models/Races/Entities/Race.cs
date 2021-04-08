using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MinNameLength = 5;
        private const int MinLapsCount = 1;

        private string name;
        private int laps;
        private readonly List<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
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

        public int Laps
        {
            get => this.laps;
            private set
            {
                Validator.ThrowIfIntegerIsLessThanMinValue(value, MinLapsCount, string.Format(ExceptionMessages.InvalidNumberOfLaps, MinLapsCount));

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();
       
        public void AddDriver(IDriver driver)
        {
            Validator.ThrowIfObjectIsNull(driver, ExceptionMessages.DriverInvalid);

            if (driver.CanParticipate == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (this.Drivers.Contains(driver))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.drivers.Add(driver);
        }
    }
}
