using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03._Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public MyStack()
        {
            this.elements = new List<T>();
        }

        public void Push(params T[] items)
        {
            foreach (T item in items)
            {
                this.elements.Add(item);
            }
        }

        public void Pop()
        {
            if (this.elements.Count <= 0)
            {
                throw new InvalidOperationException("No elements");
            }
            else
            {
                this.elements.RemoveAt(elements.Count - 1);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.elements.Count > 0)
            {
                for (int i = this.elements.Count - 1; i >= 0; i--)
                {
                    yield return elements[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
