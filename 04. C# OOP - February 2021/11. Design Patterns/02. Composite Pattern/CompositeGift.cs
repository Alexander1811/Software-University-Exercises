namespace P02_CompositePattern
{
    using System;
    using System.Collections.Generic;

    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;

        public CompositeGift(string name, int price) : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            this.gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            int total = 0;

            Console.WriteLine($"{this.name} contains the following products with prices:");

            foreach (GiftBase gift in this.gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }
    }
}