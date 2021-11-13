namespace Bakery.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Models.Tables;
    using Models.Tables.Contracts;

    public class TableFactory : ITableFactory
    {
        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            //Type tableType = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            //ITable table = (ITable)Activator.CreateInstance(tableType, tableNumber, capacity);

            ITable table;

            switch (type)
            {
                case nameof(InsideTable):
                    table = new InsideTable(tableNumber, capacity);
                    break;
                case nameof(OutsideTable):
                    table = new OutsideTable(tableNumber, capacity);
                    break;
                default:
                    table = null;
                    break;
            }

            return table;
        }
    }
}
