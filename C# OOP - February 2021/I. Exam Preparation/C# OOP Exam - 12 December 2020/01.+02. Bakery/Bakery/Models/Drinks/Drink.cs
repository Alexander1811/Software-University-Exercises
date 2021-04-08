using Bakery.Models.Drinks.Contracts;
using Bakery.Utilities;
using Bakery.Utilities.Messages;
using System;

namespace Bakery.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private string name;
        private int portion;
        private decimal price;
        private string brand;

        public Drink(string name, int portion, decimal price, string brand)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
            this.Brand = brand;
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

        public string Brand
        {
            get => this.brand;

            private set
            {
                Validator.ThrowIfStringIsNullOrWhitespace(value, ExceptionMessages.InvalidBrand);

                this.brand = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Brand} - {this.Portion}ml - {this.Price:f2}lv";
        }
    }
}
