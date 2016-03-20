namespace ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IEnumerable<T>
    {
        private const int DefaultArrayLength = 16;

        private static T[] array = new T[DefaultArrayLength];
        private static int firstEmptyCellIndex = 0;

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return array[(firstEmptyCellIndex - 1) - index];
            }
        }
        
        public void Add(T item)
        {
            if (this.ShouldGrow())
            {
                this.Grow();
            }

            array[firstEmptyCellIndex] = item;
            firstEmptyCellIndex++;
        }

        public int Count()
        {
            return firstEmptyCellIndex;
        }

        public int Capacity()
        {
            return array.Length;
        }

        public void Remove(int index)
        {
            this.ValidateIndex(index);
            for (int i = firstEmptyCellIndex - 1 - index; i < firstEmptyCellIndex; i++)
            {
                array[i] = array[i + 1];
            }

            firstEmptyCellIndex--;
            array[firstEmptyCellIndex] = default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int index = firstEmptyCellIndex - 1;
            T currentNode = array[index];
            while (currentNode != null && index > 0)
            {
                yield return currentNode;
                index--;
                currentNode = array[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            T[] output = new T[firstEmptyCellIndex];
            for (int i = 0; i < firstEmptyCellIndex; i++)
            {
                output[i] = array[i];
            }

            return string.Join(" ", output.Reverse());
        }

        private void Grow()
        {
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }

        private bool ShouldGrow()
        {
            if (array.Length == firstEmptyCellIndex + 1)
            {
                return true;
            }

            return false;
        }

        private bool ValidateIndex(int index)
        {
            if (index < firstEmptyCellIndex && index >= 0)
            {
                return true;
            }
            else
            {
                throw new InvalidOperationException("No such element.");
            }
        }
    }
}
