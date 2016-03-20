using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class ListNode<T>
    {
        public T Value { get; private set; }
        public ListNode<T> PreviousNode { get; set; }
        public ListNode<T> NextNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
    }

    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if(this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(element);
        }
        else
        {
            var newHead = new ListNode<T>(element);
            newHead.NextNode = this.head;
            this.head.PreviousNode = newHead;
            this.head = newHead;
        }

        this.Count++;
    }

    public void AddLast(T element)
    {
        if(this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(element);
        }
        else
        {
            var newTail = new ListNode<T>(element);
            this.tail.NextNode = newTail;
            newTail.NextNode = null;
            if(this.tail != null)
            {
                newTail.PreviousNode = this.tail;
            }
            else
            {
                newTail.PreviousNode = null;
            }

            this.tail = newTail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if(this.Count == 0)
        {
            throw new InvalidOperationException("List empty");
        }
        
        T oldHeadValue = this.head.Value;
        this.head = this.head.NextNode;
        if(this.head != null)
        {
            this.head.PreviousNode = null;
        }
        else
        {
            this.tail = null;
        }

        
        this.Count--;
        return oldHeadValue;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List empty");
        }

        T oldTailValue = this.tail.Value;
        this.tail = this.tail.PreviousNode;
        if (this.tail != null)
        {
            this.tail.NextNode = null;
        }
        else
        {
            this.head = null;
        }

        this.Count--;
        return oldTailValue;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this.head;
        while(currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.head;
        while(currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        if(this.Count == 0)
        {
            return new T[0];
        }
        else
        {
            var arr = new T[this.Count];
            var current = this.head;
            var index = 0;
            while (current != null)
            {
                arr[index] = current.Value;
                index++;
                current = current.NextNode;
            }

            return arr;
        }
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
