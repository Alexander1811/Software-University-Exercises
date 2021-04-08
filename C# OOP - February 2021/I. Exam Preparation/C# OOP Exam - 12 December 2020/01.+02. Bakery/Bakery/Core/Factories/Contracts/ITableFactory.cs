using Bakery.Models.Tables.Contracts;

namespace Bakery.Core.Factories.Contracts
{
    public interface ITableFactory
    {
        ITable CreateTable(string type, int tableNumber, int capacity);
    }
}
