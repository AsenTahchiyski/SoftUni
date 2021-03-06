﻿using System;

public class CircularQueue<T>
{
    private const int InitialCapacity = 16;
    private T[] elements;
    private int start = 0;
    private int end = 0;

    public int Count { get; private set; }

    public CircularQueue(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
    }

    //public CircularQueue(int capacity)
    //{
    //    this.elements = new T[capacity];
    //}

    public void Enqueue(T element)
    {
        if (this.Count >= this.elements.Length)
        {
            Grow();
        }

        this.elements[this.end] = element;
        this.end = (this.end + 1) % this.elements.Length;
        this.Count++;
    }

    public T Dequeue()
    {
        if(this.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var result = this.elements[this.start];
        this.start = (this.start + 1) % this.elements.Length;
        this.Count--;
        return result;
    }

    public T[] ToArray()
    {
        var result = new T[this.Count];
        this.CopyAllElementsTo(result);
        return result;
    }

    private void Grow()
    {
        var newElements = new T[this.elements.Length * 2];
        this.CopyAllElementsTo(newElements);
        this.elements = newElements;
        this.start = 0;
        this.end = this.Count;
    }

    private void CopyAllElementsTo(T[] newElements)
    {
        int sourceIndex = this.start;
        int destinationIndex = 0;
        for (int i = 0; i < this.Count; i++)
        {
            newElements[destinationIndex] = this.elements[sourceIndex];
            sourceIndex = (sourceIndex + 1) % this.elements.Length;
            destinationIndex++;
        }
    }
}


class Example
{
    static void Main()
    {
        var queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        var first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
