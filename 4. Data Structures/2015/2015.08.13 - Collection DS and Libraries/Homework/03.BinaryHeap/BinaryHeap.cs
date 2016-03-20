namespace _03.BinaryHeap
{
    using System;
    using System.Linq;

    public class BinaryHeap<T> where T : IComparable
    {
        private const int InitialCapacity = 16;

        private T[] array;

        public int Count { get; private set; }

        public int Capacity
        {
            get { return this.array.Length; }
        }

        public BinaryHeap(int capacity = InitialCapacity)
        {
            array = new T[capacity];
        }

        public void Add(T itemToAdd)
        {
            if (this.array.Length < this.Count)
            {
                Grow();
            }

            if (this.Count == 0)
            {
                this.array[0] = itemToAdd;
            }
            else
            {
                this.array[Count] = itemToAdd;
            }

            RearrangeAfterAddition(this.Count);
            this.Count++;
        }

        public void Remove(T itemToRemove)
        {
            if (!this.array.Contains(itemToRemove))
            {
                throw new InvalidOperationException("Item to remove is not present.");
            }

            var itemIndex = Array.IndexOf(this.array, itemToRemove);
            var newArray = new T[this.Count - 1];
            Array.Copy(this.array, newArray, itemIndex - 1);
            Array.Copy(this.array, itemIndex + 1, newArray, itemIndex, this.Count - itemIndex);
            this.Count--;
        }

        public void Clear()
        {
            this.array = new T[InitialCapacity];
        }

        public T GetRoot()
        {
            return this.array[0];
        }

        private void RearrangeAfterAddition(int index)
        {
            var itemJustAdded = this.array[index];
            var currentRoot = this.array[(index - 1) / 2];
            int currentRootIndex = (int)Math.Floor((double)((index - 1)/2));

            while (this.array[index].CompareTo(this.array[(index - 1) / 2]) > 0) // > 0 -> maxHeap; < 0 -> minHeap
            {
                var temp = currentRoot;
                this.array[currentRootIndex] = itemJustAdded;
                this.array[index] = temp;

                if (currentRootIndex == 0)
                {
                    return;
                }

                RearrangeAfterAddition(currentRootIndex);
            }
        }

        private void Grow()
        {
            var newArray = new T[this.array.Length * 2];
            this.array.CopyTo(newArray, 0);
            this.array = newArray;
        }
    }
}
