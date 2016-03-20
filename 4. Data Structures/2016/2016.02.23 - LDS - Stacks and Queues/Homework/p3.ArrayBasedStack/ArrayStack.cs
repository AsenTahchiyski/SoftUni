using System;

namespace p3.ArrayBasedStack
{
    public class ArrayStack<T>
    {
        private T[] elements;
        private const int InitialCapacity = 16;

        public int Count { get; private set; }
        public int Capacity { get { return this.elements.Length; } }

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            var result = this.elements[this.Count - 1];
            this.elements[this.Count - 1] = default(T);
            this.Count--;
            return result;
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                result[this.Count - 1 - i] = this.elements[i];
            }

            return result;
        }

        private void Grow()
        {
            var newArray = new T[this.elements.Length * 2];
            this.elements.CopyTo(newArray, 0);
            this.elements = newArray;
        }
    }
}
