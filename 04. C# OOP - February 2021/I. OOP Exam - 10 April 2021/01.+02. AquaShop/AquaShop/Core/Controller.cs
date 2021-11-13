namespace AquaShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Aquariums;
    using Models.Aquariums.Contracts;
    using Models.Decorations;
    using Models.Decorations.Contracts;
    using Models.Fish;
    using Models.Fish.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly DecorationRepository decorations;
        private readonly Dictionary<string, IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new Dictionary<string, IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquariumName, aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Key == aquariumName).Value;

            if (aquarium.GetType().Name == nameof(FreshwaterAquarium) && fishType == nameof(FreshwaterFish) ||
                aquarium.GetType().Name == nameof(SaltwaterAquarium) && fishType == nameof(SaltwaterFish))
            {
                aquarium.AddFish(fish);

                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else
            {
                return OutputMessages.UnsuitableWater;
            }
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Key == aquariumName).Value;

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Key == aquariumName).Value;

            decimal value = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Key == aquariumName).Value;

            IDecoration decoration = this.decorations.Models.FirstOrDefault(d => d.GetType().Name == decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IAquarium aquarium in this.aquariums.Values)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
