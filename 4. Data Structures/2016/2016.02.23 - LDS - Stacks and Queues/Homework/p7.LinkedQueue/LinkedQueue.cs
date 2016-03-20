using System;

namespace p7.LinkedQueue
{
    public class LinkedQueue<T>
    {
        private Node<T> firstNode;
        private Node<T> lastNode;

        public int Count { get; private set; }

        public LinkedQueue()
        {
            this.firstNode = this.lastNode = null;
        }

        public void Enqueue(T element)
        {
            if (this.firstNode == null)
            {
                this.firstNode = this.lastNode = new Node<T>(element);
            }
            else
            {
                var newNode = new Node<T>(element, null);
                this.lastNode.NextNode = newNode;
                this.lastNode = newNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var result = this.firstNode;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;
            return result.Value;
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];
            var currentElement = this.firstNode;
            var counter = 0;
            while (currentElement != null)
            {
                result[counter] = currentElement.Value;
                counter++;
                currentElement = currentElement.NextNode;
            }

            return result;
        }

        private class Node<T>
        {
            public T Value { get; private set; }
            public Node<T> NextNode { get; set; }
            public Node(T value, Node<T> next = null)
            {
                this.Value = value;
                this.NextNode = next;
            }
        }
    }
}
