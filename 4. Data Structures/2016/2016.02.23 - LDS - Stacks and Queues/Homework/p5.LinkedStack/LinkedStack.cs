using System;

namespace p5.LinkedStack
{
    public class LinkedStack<T>
    {
        private Node<T> firstNode;
        
        public int Count { get; private set; }

        public LinkedStack()
        {
            this.firstNode = null;
        }

        public void Push(T element)
        {
            if(this.firstNode == null)
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
            if(this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
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
