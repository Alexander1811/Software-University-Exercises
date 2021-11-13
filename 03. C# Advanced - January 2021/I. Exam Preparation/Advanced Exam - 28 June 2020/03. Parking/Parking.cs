using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public int Capacity { get; set; }

        public string Type { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car car = data.FirstOrDefault(car => car.Model == model && car.Manufacturer == manufacturer);
            if (car == null)
            {
                return false;
            }

            data.Remove(car);
            return true;
        }

        public Car GetLatestCar() 
        {
            Car car = data.OrderByDescending(car => car.Year).FirstOrDefault();
            return car;
        }

        public Car GetCar(string manufacturer, string model) 
        {
            Car car = data.FirstOrDefault(car => car.Model == model && car.Manufacturer == manufacturer);
            if (car == null)
            {
                return null;
            }

            return car;
        }

        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The cars are parked in {Type}:");

            foreach (Car car in data)
            {
                result.AppendLine(car.ToString());
            }

            return result.ToString();
        }
    }
}
