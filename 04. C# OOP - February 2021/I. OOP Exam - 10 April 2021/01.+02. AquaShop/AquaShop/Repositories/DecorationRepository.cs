namespace AquaShop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Decorations.Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.models.ToList().AsReadOnly();

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }
        public bool Remove(IDecoration model)
        {
            if (!this.models.Contains(model))
            {
                return false;
            }

            return this.models.Remove(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.models.FirstOrDefault(d => d.GetType().Name == type);
        }
    }
}
