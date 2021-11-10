using System;

namespace P01_ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                this.ThrowIfSideIsInvalid(value, nameof(this.Length));

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                this.ThrowIfSideIsInvalid(value, nameof(this.Width));

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                this.ThrowIfSideIsInvalid(value, nameof(this.Height));

                this.height = value;
            }
        }

        public double CalculateVolume()
        {
            return this.Length * this.Width * this.Height;
        }

        public double CalculateLateralArea()
        {
            return 2 * (this.Width + this.Length) * this.Height;
        }

        public double CalculateArea()
        {
            return 2 * ((this.Width + this.Length) * this.Height + this.Length * this.Width);
        }

        private void ThrowIfSideIsInvalid(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }
    }
}
