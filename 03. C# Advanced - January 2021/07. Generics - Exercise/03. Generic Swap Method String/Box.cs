﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Generic_Swap_Method_String
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