namespace EasterRaces.Models.Cars.Entities
{
    using Contracts;

    public class SportsCar : Car, ICar
    {
        private const double SportsCarCubicCentimeters = 3000;
        private const int SportsCarMinHorsePower = 250;
        private const int SportsCarMaxHorsePower = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, SportsCarCubicCentimeters, SportsCarMinHorsePower, SportsCarMaxHorsePower)
        {
        }
    }
}
