namespace _07.LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        public int Count { get; private set; }

        private QueueNode<T> head;
        private QueueNode<T> tail;

        public void Enqueue(T element)
        {
            var firstElement = new QueueNode<T>(element);
            
            if (this.Count == 0)
            {
                this.head = this.tail = firstElement;
            }
            else
            {
                this.head.PrevNode = firstElement;
                firstElement.NextNode = this.head;
                this.head = firstElement;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            
            var returnElement = this.tail;
            this.tail = this.tail != null ? this.tail.PrevNode : null;
            this.Count--;
            return returnElement.Value;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            int nodesCount = this.Count;

            for (int i = 0; i < nodesCount; i++)
            {
                array[i] = this.Dequeue();
            }

            for (int i = nodesCount - 1; i >= 0; i--)
            {
                this.Enqueue(array[i]);
            }

            return array;
        }

        private class QueueNode<T>
        {
            public T Value { get; private set; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }

            public QueueNode(T element)
            {
                this.Value = element;
                this.NextNode = null;
                this.PrevNode = null;
            }
        }
    }
}
