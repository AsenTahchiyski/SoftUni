using System;
using System.Collections;
using System.Collections.Generic;

namespace p7.LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public LinkedList()
        {
            this.head = this.tail = null;
        }

        public void Add(T item)
        {
            var newNode = new Node<T>(item);
            newNode.NextNode = null;

            if (this.head == null)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                var oldTail = this.tail;
                this.tail = newNode;
                oldTail.NextNode = this.tail;
            }

            this.count++;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Remove(int index)
        {
            if(index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Wrong index.");
            }

            var elementToRemove = this.head;
            Node<T> previousElement = null;
            for (int i = 0; i < index; i++)
            {
                previousElement = elementToRemove;
                elementToRemove = elementToRemove.NextNode;
            }

            previousElement.NextNode = elementToRemove.NextNode;
            elementToRemove.NextNode = null;
            this.count--;
        }

        public int FirstIndexOf(T item)
        {
            int index = 0;
            var currentNode = this.head;
            while(currentNode != null)
            {
                if(currentNode.Value.Equals(item))
                {
                    return index;
                }

                index++;
                currentNode = currentNode.NextNode;
            }

            return -1;
        }

        public int LastIndexOf(T item)
        {
            int index = 0;
            int lastIndex = -1;
            var currentNode = this.head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    lastIndex = index;
                }

                index++;
                currentNode = currentNode.NextNode;
            }

            return lastIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElement = this.head;
            while(currentElement != null)
            {
                yield return currentElement.Value;
                currentElement = currentElement.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class Node<T>
        {
            public T Value { get; private set; }
            public Node<T> NextNode { get; set; }

            public Node(T nodeValue) 
            {
                this.Value = nodeValue;
            }
        }
    }
}
