namespace TheRace.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    public class RaceEntryTests
    {
        private const string ExistingDriver = "Driver {0} is already added.";
        private const string DriverInvalid = "Driver cannot be null.";
        private const string DriverAdded = "Driver {0} added in race.";
        private const string RaceInvalid = "The race cannot start with less than {0} participants.";
        private const int MinParticipantsCount = 2;

        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void Ctor_InitilializeEmptyDriverList()
        {
            Assert.That(this.raceEntry.Counter, Is.EqualTo(0));
        }

        [Test]
        public void AddDriver_ThrowsException_WhenDriverIsNull()
        {
            UnitDriver driver = null;

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(driver), DriverInvalid);
        }

        [Test]
        public void AddDriver_ThrowsException_WhenDriverAlreadyExists()
        {
            UnitDriver driver = new UnitDriver("Ivan", new UnitCar("Porsche", 200, 200));

            this.raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(driver), string.Format(ExistingDriver, driver.Name));
        }

        [Test]
        public void AddDriver_AddsDriver()
        {
            UnitDriver driver = new UnitDriver("Ivan", new UnitCar("Porsche", 200, 200));

            string result = this.raceEntry.AddDriver(driver);

            Assert.That(this.raceEntry.Counter, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo(string.Format(DriverAdded, driver.Name)));
        }

        [Test]
        public void CalculateAverageHorsePower_ThrowsException_WhenDriverCountIsLessThanMinParticipantsCount()
        {
            UnitDriver driver = new UnitDriver("Ivan", new UnitCar("Porsche", 200, 200));

            this.raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower(), string.Format(RaceInvalid, MinParticipantsCount));
        }

        [Test]
        public void CalculateAverageHorsePower_ReturnsCorrectAnswer()
        {
            UnitDriver driver1 = new UnitDriver("Ivan", new UnitCar("Porsche", 200, 200));
            UnitDriver driver2 = new UnitDriver("Pesho", new UnitCar("Mustang", 100, 300));
            UnitDriver driver3 = new UnitDriver("Gosho", new UnitCar("Ferrari", 150, 250));

            this.raceEntry.AddDriver(driver1);
            this.raceEntry.AddDriver(driver2);
            this.raceEntry.AddDriver(driver3);

            List<UnitDriver> drivers = new List<UnitDriver>
            {
                driver1,
                driver2,
                driver3
            };

            double averageHorsePower = drivers.Select(x => x.Car.HorsePower).Average();

            Assert.That(averageHorsePower, Is.EqualTo(this.raceEntry.CalculateAverageHorsePower()));
        }
    }
}