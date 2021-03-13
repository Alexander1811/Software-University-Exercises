using _07._Military_Elite.Enums;

namespace _07._Military_Elite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
