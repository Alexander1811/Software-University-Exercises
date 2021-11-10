namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Decorations.Contracts;
    using Fish.Contracts;
    using Utilities.Messages;

    public abstract class Aquarium : IAquarium
    {
        private readonly List<IDecoration> decorations;
        private readonly Dictionary<string, IFish> fish;
        private string name;

        public Aquarium(string name, int capacity)
        {
            this.decorations = new List<IDecoration>();
            this.fish = new Dictionary<string, IFish>();

            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish.Values;

        public int Comfort => this.Decorations.Sum(d => d.Comfort);

        public void AddFish(IFish fish)
        {
            if (this.Capacity <= this.Fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish.Name, fish);
        }

        public bool RemoveFish(IFish fish)
        {
            if (!this.Fish.Contains(fish))
            {
                return false;
            }

            return this.Fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (IFish fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            string fishNames;
            if (this.Fish.Count == 0)
            {
                fishNames = "none";
            }
            else
            {
                fishNames = string.Join(", ", this.fish.Keys);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {fishNames}");
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().Trim();
        }
    }
}
