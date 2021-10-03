using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string type, int capacity)
        {
            this.Name = type;
            this.Capacity = capacity;
            this.data = new List<Employee>();
        }
        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = data.FirstOrDefault(employee => employee.Name == name);
            if (employee == null)
            {
                return false;
            }

            data.Remove(employee);
            return true;
        }

        public Employee GetOldestEmployee()
        {
            Employee employee = data.OrderByDescending(employee => employee.Age).FirstOrDefault();
            return employee;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = data.FirstOrDefault(employee => employee.Name == name);
            if (employee == null)
            {
                return null;
            }

            return employee;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Employees working at Bakery {Name}:");

            foreach (Employee employee in data)
            {
                result.AppendLine(employee.ToString());
            }

            return result.ToString().TrimEnd();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }
    }
}
