using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Racer>();
        }
        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racer = data.FirstOrDefault(racer => racer.Name == name);
            if (racer == null)
            {
                return false;
            }

            data.Remove(racer);
            return true;
        }

        public Racer GetOldestRacer()
        {
            Racer racer = data.OrderByDescending(racer => racer.Age).FirstOrDefault();
            return racer;
        }

        public Racer GetFastestRacer()
        {
            Racer racer = data.OrderByDescending(racer => racer.Car.Speed).FirstOrDefault();
            return racer;
        }

        public Racer GetRacer(string name)
        {
            Racer racer = data.FirstOrDefault(racer => racer.Name == name);
            if (racer == null)
            {
                return null;
            }

            return racer;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Racers participating at {Name}:");
            foreach (Racer racer in data)
            {
                result.AppendLine(racer.ToString());
            }

            return result.ToString().TrimEnd();
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

    }
}
