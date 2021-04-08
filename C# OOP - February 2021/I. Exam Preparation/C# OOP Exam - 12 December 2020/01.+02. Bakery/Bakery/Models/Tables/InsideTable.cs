using Bakery.Models.Tables.Contracts;

namespace Bakery.Models.Tables
{
    public class InsideTable : Table, ITable
    {
        private const decimal InitialPricePerPerson = 2.50M;

        public InsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }
    }
}
