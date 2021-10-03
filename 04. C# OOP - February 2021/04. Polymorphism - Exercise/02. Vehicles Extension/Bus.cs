﻿using System;

namespace _02._Vehicles_Extension
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
