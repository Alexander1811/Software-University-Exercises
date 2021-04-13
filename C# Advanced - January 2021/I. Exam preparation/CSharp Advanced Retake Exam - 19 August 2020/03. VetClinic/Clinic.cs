using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private Dictionary<string, Pet> data;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;

            this.data = new Dictionary<string, Pet>();
        }

        public int Capacity { get; private set; }

        public int Count => this.data.Count;

        public void Add(Pet pet)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(pet.Name, pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = this.data.Values.FirstOrDefault(p => p.Name == name);

            if (pet==null)
            {
                return false;
            }

            return this.data.Remove(pet.Name);
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.data.Values.FirstOrDefault(p => p.Name == name && p.Owner == owner);

            return pet;
        }

        public Pet GetOldestPet()
        {
            List<Pet> sortedPets = this.data.Values.OrderByDescending(p => p.Age).ToList();

            Pet pet = sortedPets.FirstOrDefault();

            return pet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");
            foreach (Pet pet in this.data.Values)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().Trim();
        }
    }
}
