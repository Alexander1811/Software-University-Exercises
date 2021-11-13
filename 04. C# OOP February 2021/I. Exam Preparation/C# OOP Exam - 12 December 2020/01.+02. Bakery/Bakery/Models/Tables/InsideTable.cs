namespace Bakery.Models.Tables
{
    using Contracts;

    public class InsideTable : Table, ITable
    {
        private const decimal InitialPricePerPerson = 2.50M;

        public InsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }
    }
}
