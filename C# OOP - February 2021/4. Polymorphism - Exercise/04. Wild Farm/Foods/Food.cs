namespace _04._Wild_Farm.Foods
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int  Quantity { get; private set; }
    }
}
