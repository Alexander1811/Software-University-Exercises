using System.Collections.Generic;

namespace _07._Military_Elite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }
}
