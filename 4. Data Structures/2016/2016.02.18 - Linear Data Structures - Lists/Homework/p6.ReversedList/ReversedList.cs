using System;
using System.Collections;
using System.Collections.Generic;

namespace p6.ReversedList
{
    public class ReversedList<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 16;

        private T[] array = new T[DefaultCapacity];
        private int nextFreeCell = 0;

        public void Add(T item)
        {
            Grow();
            this.array[this.nextFreeCell] = item;
            this.nextFreeCell++;
        }

        public void Remove(int index)
        {
            ValidateIndex(index);
            for (int i = this.nextFreeCell - (index + 1); i < this.nextFreeCell - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            this.nextFreeCell--;
        }

        public int Count
        {
            get
            {
                return this.nextFreeCell;
            }
        }

        public int Capacity
        {
            get
            {
                return this.array.Length;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElementIndex = this.nextFreeCell - 1;
            while(currentElementIndex >= 0)
            {
                yield return this.array[currentElementIndex];
                currentElementIndex--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T this[int index] {
            get
            {
                ValidateIndex(index);
                return this.array[(this.nextFreeCell - 1) - index];
            }
        }

        private void ValidateIndex(int index)
        {
            if(index < 0 || index > this.nextFreeCell)
            {
                throw new IndexOutOfRangeException("Invalid index.");
            }
        }

        private void Grow()
        {
            var currentLength = this.array.Length;
            if (currentLength <= this.nextFreeCell)
            {
                var doubleSized = new T[2 * currentLength];
                this.array.CopyTo(doubleSized, 0);
                this.array = doubleSized;
            }
        }
    }
}
