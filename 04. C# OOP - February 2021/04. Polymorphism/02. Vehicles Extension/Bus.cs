using System;

namespace P02_VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double BusAirConditionerModifier = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, BusAirConditionerModifier)
        {
        }

        public void DriveEmpty(double distance)
        {
            double fuelConsumed = distance * this.FuelConsumption;
            
            if (fuelConsumed > this.FuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= fuelConsumed;
        }
    }
}
