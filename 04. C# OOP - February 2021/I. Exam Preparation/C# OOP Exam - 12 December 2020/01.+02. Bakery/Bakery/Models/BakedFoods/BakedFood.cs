namespace Bakery.Models.BakedFoods
{
    using Contracts;
    using Utilities;
    using Utilities.Messages;

    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;

        public BakedFood(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhitespace(value, ExceptionMessages.InvalidName);

                this.name = value;
            }
        }

        public int Portion
        {
            get => this.portion;
            private set
            {
                Validator.ThrowIfIntegerIsLessOrEqualToZero(value, ExceptionMessages.InvalidPortion);

                this.portion = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                Validator.ThrowIfDecimalIsLessOrEqualToZero(value, ExceptionMessages.InvalidPrice);

                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.Portion}g - {this.Price:f2}";
        }
    }
}
