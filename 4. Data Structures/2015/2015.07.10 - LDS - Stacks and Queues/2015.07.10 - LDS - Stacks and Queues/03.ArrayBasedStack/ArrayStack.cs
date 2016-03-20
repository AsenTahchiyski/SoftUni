namespace ArrayBasedStack
{
    using System;

    public class ArrayStack<T>
    {
        public int Count { get; private set; }
        private T[] array;
        private int headIndex = 0;
        private int tailIndex = 0; // first empty cell

        private const int DefaultCapacity = 16;

        public ArrayStack(int capacity = DefaultCapacity)
        {
            this.array = new T[capacity];
        }

        public void Push(T element)
        {
            if (MustResizeArray())
            {
                Resize();
            }
            this.array[this.tailIndex] = element;
            this.tailIndex = (this.tailIndex + 1) % this.array.Length;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            var result = this.array[tailIndex - 1];
            this.tailIndex = this.tailIndex - 2 >= 0 ? this.tailIndex - 1 : this.Count;
            this.Count--;
            return result;
        }

        public T[] ToArray()
        {
            var resultArray = new T[this.Count];
            this.CopyAllElementsTo(resultArray);
            return resultArray;
        }

        private void CopyAllElementsTo(T[] resultArray)
        {
            int sourceIndex = this.headIndex;
            int destinationIndex = 0;
            for (int i = 0; i < this.Count; i++)
            {
                resultArray[destinationIndex] = this.array[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.array.Length;
                destinationIndex++;
            }
        }

        private void Resize()
        {
            var newArray = new T[this.array.Length * 2];
            this.CopyAllElementsTo(newArray);
            this.array = newArray;
            this.headIndex = 0;
            this.tailIndex = this.Count;
        }

        private bool MustResizeArray()
        {
            if (this.Count >= this.array.Length)
            {
                return true;
            }

            return false;
        }
    }
}
