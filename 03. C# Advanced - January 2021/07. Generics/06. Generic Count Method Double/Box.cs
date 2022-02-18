using System;

namespace P06_GenericCountMethodDouble
{
    public class Box<T> : IComparable<T>
        where T : IComparable<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public int CompareTo(T other)
        {
            return this.value.CompareTo(other);
        }

        public override string ToString()
        {
            string name = this.value.GetType().FullName;
            T value = this.value;
            return $"{name}: {value}";
        }
    }
}