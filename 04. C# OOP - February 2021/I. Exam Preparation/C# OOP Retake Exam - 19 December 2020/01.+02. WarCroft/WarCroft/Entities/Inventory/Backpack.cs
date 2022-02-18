namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag, IBag
    {
        private const int BagCapacity = 100;

        public Backpack()
            : base(BagCapacity)
        {
        }
    }
}
