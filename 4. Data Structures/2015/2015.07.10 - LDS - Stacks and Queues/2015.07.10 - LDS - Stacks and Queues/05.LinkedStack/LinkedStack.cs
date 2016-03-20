namespace _05.LinkedStack
{
    using System;

    public class LinkedStack<T>
    {
        private Node<T> firstNode;

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == 0)
            {
                this.firstNode = new Node<T>(element);
            }
            else
            {
                var newNode = new Node<T>(element, this.firstNode);
                this.firstNode = newNode;
            }

            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            var returnElement = this.firstNode;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;
            return returnElement.Value;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            int nodesCount = this.Count;

            for (int i = 0; i < nodesCount; i++)
            {
                array[i] = this.Pop();
            }

            for (int i = nodesCount - 1; i >= 0; i--)
            {
                this.Push(array[i]);
            }

            return array;
        }

        private class Node<T>
        {
            public T Value { get; private set; }

            public Node<T> NextNode { get; set; }

            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }
        }

    }
}
