namespace P03_GenericSwapMethodString
{
    public class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            string name = this.value.GetType().FullName;
            T value = this.value;
            return $"{name}: {value}";
        }
    }
}