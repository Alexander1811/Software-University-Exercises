using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int MinModelNameLength = 4;
        private readonly int MinHorsePower;
        private readonly int MaxHorsePower;

        private string model;
        private int horsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.MinHorsePower = minHorsePower;
            this.MaxHorsePower = maxHorsePower;

            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpaceOrLessThenMinLength(value, MinModelNameLength, string.Format(ExceptionMessages.InvalidModel, value, MinModelNameLength));

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                Validator.ThrowIfIntegerIsInRange(value, MinHorsePower, MaxHorsePower, string.Format(ExceptionMessages.InvalidHorsePower, value));

                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
