namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int DecorationComfort = 5;
        private const decimal DecorationPrice = 10M;

        public Plant()
            : base(DecorationComfort, DecorationPrice)
        {
        }
    }
}