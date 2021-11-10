using System;

namespace P02_VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double airConditionerModifier)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionerModifier = airConditionerModifier;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }

        protected double AirConditionerModifier { get; set; }

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
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
