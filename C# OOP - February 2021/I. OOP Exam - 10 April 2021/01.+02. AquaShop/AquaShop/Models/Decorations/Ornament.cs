namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int DecorationComfort = 1;
        private const decimal DecorationPrice = 5M;

        public Ornament() 
            : base(DecorationComfort, DecorationPrice)
        {
        }
    }
}
