using System.Collections.Generic;

namespace _07._Military_Elite.Contracts
{
    public interface ILieutenantGeneral : ISoldier
    {
        IReadOnlyCollection<IPrivate> Privates { get; }

        void AddPrivate(IPrivate @private);
    }
}
