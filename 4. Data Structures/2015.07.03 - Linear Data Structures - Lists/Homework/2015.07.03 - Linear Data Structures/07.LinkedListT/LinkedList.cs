namespace LinkedList
{
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        public void Add(T item)
        {
            ListNode<T> currentElement = new ListNode<T>(item);
            currentElement.NextNode = null;

            if (this.head == null)
            {
                this.head = this.tail = currentElement;
            }

            else
            {
                this.tail.NextNode = currentElement;
                this.tail = currentElement;
            }
            this.Count++;
        }

        public void Remove(int index)
        {
            int nodeCounter = 0;
            ListNode<T> previousNode = null;
            ListNode<T> currentNode = this.head;
            while (currentNode != null)
            {
                if (nodeCounter == index)
                {
                    if (previousNode == null)
                    {
                        this.head = currentNode.NextNode;
                    }

                    else
                    {
                        previousNode.NextNode = currentNode.NextNode;
                    }
                }
                else
                {
                    previousNode = currentNode;
                }

                currentNode = currentNode.NextNode;
                nodeCounter++;
            }

            this.Count--;
        }

        public int FirstIndexOf(T item)
        {
            ListNode<T> currentNode = this.head;
            int nodeCounter = 0;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    return nodeCounter;
                }

                nodeCounter++;
                currentNode = currentNode.NextNode;
            }

            return -1;
        }

        public int LastIndexOf(T item)
        {
            ListNode<T> currentNode = this.head;
            int nodeCounter = 0;
            int lastFoundItemIndex = -1;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    lastFoundItemIndex = nodeCounter;
                }

                nodeCounter++;
                currentNode = currentNode.NextNode;
            }

            return lastFoundItemIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
}
