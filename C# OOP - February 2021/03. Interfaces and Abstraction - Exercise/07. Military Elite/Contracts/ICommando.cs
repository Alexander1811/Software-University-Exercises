using System.Collections.Generic;

namespace _07._Military_Elite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }

        void AddMission(IMission mission);
    }
}
