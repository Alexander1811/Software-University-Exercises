using System;

namespace P02_VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double TruckAirConditionerModifier = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, TruckAirConditionerModifier)
        {
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters * 0.95;
        }
    }
}
