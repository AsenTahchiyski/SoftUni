namespace GenericList
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    [VersionAttribute(0, 2)]
    public class GenericList<T> where T : IComparable
    {
        private T[] array;
        private int currentIndex;
        private const int DefaultSize = 16;

        public GenericList()
        {
            this.array = new T[DefaultSize];
        }

        public void Add(T element)
        {
            if (currentIndex >= this.array.Length)
            {
                Resize();
            }
            this.array[currentIndex] = element;
            currentIndex++;
        }

        public void Remove(int index)
        {
            if (index >= currentIndex)
                throw new ArgumentOutOfRangeException("Invalid element index.");
            this.array[index] = default(T);
            for (int i = index; i < currentIndex; i++)
            {
                if (index == array.Length - 1)
                {
                    array[i] = default(T);
                }
                else
                {
                    array[i] = array[i + 1];
                }
            }
            currentIndex--;
        }

        public override string ToString()
        {
            return string.Join(", ", this.array.Take(currentIndex));
        }

        public T this[int index]
        {
            get
            {
                if (index <= currentIndex)
                {
                    return array[index];
                }
                else
                {
                    throw new InvalidOperationException("No such element.");
                }
            }
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < currentIndex; i++)
            {
                if (element.Equals(array[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(T element, int index)
        {
            if (index >= currentIndex)
                throw new ArgumentOutOfRangeException("Invalid element index.");
            T oldElement = this.array[index];
            this.array[index] = element;
            for (int i = index + 1; i < currentIndex; i++)
            {
                if (i >= this.array.Length)
                    Resize();
                T temp = this.array[i];
                this.array[i] = oldElement;
                oldElement = temp;
            }
            Add(oldElement);
        }

        public void Clear()
        {
            this.array = new T[DefaultSize];
            currentIndex = 0;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < currentIndex; i++)
            {
                if (this.array[i].CompareTo(element) == 0)
                    return true;
            }
            return false;
        }

        public T Min()
        {
            T minElement = this.array[0];
            for (int i = 0; i < currentIndex; i++)
            {
                if (minElement.CompareTo(this.array[i]) == -1)
                {
                    minElement = this.array[i];
                }
            }
            return minElement;
        }

        public T Max()
        {
            T maxElement = this.array[0];
            for (int i = 0; i < currentIndex; i++)
            {
                if (maxElement.CompareTo(this.array[i]) == 1)
                {
                    maxElement = this.array[i];
                }
            }
            return maxElement;
        }

        private void Resize()
        {
            T[] newArray = new T[this.array.Length * 2];
            for (int i = 0; i < this.array.Length; i++)
            {
                newArray[i] = this.array[i];
            }
            this.array = newArray;
        }

        public void ShowVersion()
        {
            Type type = typeof(GenericList<T>);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (var ver in allAttributes)
            {
                if (ver is VersionAttribute)
                {
                    VersionAttribute temp = ver as VersionAttribute;
                    Console.WriteLine(">>> GenericList v.{0}.{1} <<<\n", temp.Major, temp.Minor);
                }
            }
        }
    }
}
