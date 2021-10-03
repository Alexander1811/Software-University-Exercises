using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Raw_Data
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = carArgs[0];

                int engineSpeed = int.Parse(carArgs[1]);
                int enginePower = int.Parse(carArgs[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(carArgs[3]);
                string cargoType = carArgs[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double tire1Pressure = double.Parse(carArgs[5]);
                int tire1Age = int.Parse(carArgs[6]);
                Tire tire1 = new Tire(tire1Pressure, tire1Age);

                double tire2Pressure = double.Parse(carArgs[5]);
                int tire2Age = int.Parse(carArgs[6]);
                Tire tire2 = new Tire(tire1Pressure, tire1Age);

                double tire3Pressure = double.Parse(carArgs[5]);
                int tire3Age = int.Parse(carArgs[6]);
                Tire tire3 = new Tire(tire1Pressure, tire1Age);

                double tire4Pressure = double.Parse(carArgs[5]);
                int tire4Age = int.Parse(carArgs[6]);
                Tire tire4 = new Tire(tire1Pressure, tire1Age);

                List<Tire> tires = new List<Tire>()
                {
                    tire1,
                    tire2,
                    tire3,
                    tire4,
                };

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars.Where(cargo => cargo.Cargo.Type == "fragile").Where(tires => tires.Tires.Any(tire => tire.Pressure < 1))));
            }
            else if (command == "flamable")
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars.Where(cargo => cargo.Cargo.Type == "flamable").Where(engine => engine.Engine.Power > 250)));
            }
        }
    }
}
