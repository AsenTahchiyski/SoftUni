namespace _03.BinaryHeap
{
    using System;

    public class PriorityQueue<T> where T : IComparable
    {
        internal class Element<T> : IComparable
        {
            public Element(int priority, T value)
            {
                this.Priority = priority;
                this.Value = value;
            }
            
            public T Value { get; set; }

            public int Priority { get; set; }

            public int CompareTo(object obj)
            {
                return this.Priority.CompareTo(((Element<T>) obj).Priority);
            }
        }

        private readonly BinaryHeap<Element<T>> elements;

        public PriorityQueue()
        {
            this.elements = new BinaryHeap<Element<T>>();
        }

        public T Peek()
        {
            return this.elements.GetRoot().Value;
        }

        public T Pop()
        {
            var rootElement = this.elements.GetRoot();
            this.elements.Remove(rootElement);
            return rootElement.Value;
        }

        public void Insert(T value, int priority)
        {
            this.elements.Add(new Element<T>(priority, value));
        }
    }
}
