namespace Bakery.Models.Tables.Contracts
{
    using BakedFoods.Contracts;
    using Drinks.Contracts;

    public interface ITable
    {
        int TableNumber { get; }

        int Capacity { get; }

        int NumberOfPeople { get; }

        decimal PricePerPerson { get; }

        bool IsReserved { get; }

        decimal Price { get; }

        void Reserve(int numberOfPeople);

        void OrderFood(IBakedFood food);

        void OrderDrink(IDrink drink);

        decimal GetBill();

        void Clear();

        string GetFreeTableInfo();
    }
}
