using P07_MilitaryElite.Enums;

namespace P07_MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
