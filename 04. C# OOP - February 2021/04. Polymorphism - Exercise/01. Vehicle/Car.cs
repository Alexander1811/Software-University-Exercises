namespace P01Vehicles
{
    public class Car : Vehicle
    {
        private const double CarAirConditionerModifier = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption, CarAirConditionerModifier)
        {
        }
    }
}
