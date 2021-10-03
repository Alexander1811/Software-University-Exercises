using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Generic_Box_of_Integer
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