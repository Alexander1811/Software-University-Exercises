namespace P05_Restaurant
{
    public class Cake : Dessert
    {
        private const decimal DefaultPrice = 5M;
        private const double DefaultGrams = 250;
        private const double DefaultCalories = 1000;
     
        public Cake(string name) 
            : base(name, DefaultPrice, DefaultGrams, DefaultCalories)
        {
        }
    }
}
