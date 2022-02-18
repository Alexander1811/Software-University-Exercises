using System.Collections.Generic;

namespace P07_MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : ISoldier
    {
        IReadOnlyCollection<IPrivate> Privates { get; }

        void AddPrivate(IPrivate @private);
    }
}
