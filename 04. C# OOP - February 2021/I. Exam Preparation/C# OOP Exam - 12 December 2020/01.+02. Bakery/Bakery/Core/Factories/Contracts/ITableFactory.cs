namespace Bakery.Core.Factories.Contracts
{
    using Models.Tables.Contracts;

    public interface ITableFactory
    {
        ITable CreateTable(string type, int tableNumber, int capacity);
    }
}
