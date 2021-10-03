namespace _02._Validation_Attributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        private readonly bool inclusive;

        public MyRangeAttribute(int minValue, int maxValue, bool inclusive = true)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.inclusive = inclusive;
        }

        public override bool IsValid(object obj)
        {
            int number = (int)obj;

            if (this.inclusive)
            {
                return number >= this.minValue && number <= this.maxValue;
            }
            else
            {
                return number > this.minValue && number < this.maxValue;
            }
        }
    }
}
