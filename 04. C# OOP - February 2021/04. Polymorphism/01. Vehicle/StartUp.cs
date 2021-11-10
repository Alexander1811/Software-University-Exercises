namespace P01_Vehicles
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split(" ").ToArray();

                string command = parts[0];
                string vehicleType = parts[1];
                double parameter = double.Parse(parts[2]);

                try
                {
                    if (vehicleType == nameof(Car))
                    {
                        ProcessCommand(command, car, parameter);
                    }
                    else if (vehicleType == nameof(Truck))
                    {
                        ProcessCommand(command, truck, parameter);
                    }
                }
                catch (Exception ex)
                    when (ex is ArgumentException || ex is InvalidOperationException)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ProcessCommand(string command, Vehicle vehicle, double parameter)
        {
            if (command == "Drive")
            {
                vehicle.Drive(parameter);

                Console.WriteLine($"{vehicle.GetType().Name} travelled {parameter} km");
            }
            else if (command == "Refuel")
            {
                vehicle.Refuel(parameter);
            }
        }

        private static Vehicle CreateVehicle()
        {
            Vehicle vehicle = null;

            string[] parts = Console.ReadLine().Split(" ").ToArray();

            string vehicleType = parts[0];
            double fuelQuantity = double.Parse(parts[1]);
            double fuelConsumption = double.Parse(parts[2]);

            if (vehicleType == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (vehicleType == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }

            return vehicle;
        }
    }
}
