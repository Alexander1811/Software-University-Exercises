namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag, IBag
    {
        private const int BagCapacity = 20;

        public Satchel() 
            : base(BagCapacity)
        {
        }
    }
}
