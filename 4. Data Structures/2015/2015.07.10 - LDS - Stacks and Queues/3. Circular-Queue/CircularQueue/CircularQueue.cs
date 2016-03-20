// softuni@yanchev.me
using System;

public class CircularQueue<T>
{
    public int Count { get; private set; }
    private T[] array;
    private int headIndex = 0;
    private int tailIndex = 0; // first empty cell

    private const int DefaultCapacity = 16;

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.array = new T[capacity];
    }

    public void Enqueue(T element)
    {
        if (MustResizeArray())
        {
            Resize();
        }
        this.array[this.tailIndex] = element;
        this.tailIndex = (this.tailIndex + 1) % this.array.Length;
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }
        var result = this.array[headIndex];
        this.headIndex = (this.headIndex + 1) % this.array.Length;
        this.Count--;
        return result;
    }

    public T[] ToArray()
    {
        var resultArray = new T[this.Count];
        this.CopyAllElementsTo(resultArray);
        return resultArray;
    }

    private void CopyAllElementsTo(T[] resultArray)
    {
        int sourceIndex = this.headIndex;
        int destinationIndex = 0;
        for (int i = 0; i < this.Count; i++)
        {
            resultArray[destinationIndex] = this.array[sourceIndex];
            sourceIndex = (sourceIndex + 1)%this.array.Length;
            destinationIndex++;
        }
    }

    private void Resize()
    {
        var newArray = new T[this.array.Length*2];
        this.CopyAllElementsTo(newArray);
        this.array = newArray;
        this.headIndex = 0;
        this.tailIndex = this.Count;
    }

    private bool MustResizeArray()
    {
        if (this.Count >= this.array.Length)
        {
            return true;
        }

        return false;
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
