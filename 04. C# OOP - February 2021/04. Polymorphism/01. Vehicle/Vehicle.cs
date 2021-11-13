namespace P01_Vehicles
{
    using System;
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double airConditionerModifier)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionerModifier = airConditionerModifier;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public double AirConditionerModifier { get; set; }

        public void Drive(double distance)
        {
            double fuelConsumed = distance * (this.FuelConsumption + this.AirConditionerModifier);
            if (fuelConsumed > this.FuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= fuelConsumed;
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
