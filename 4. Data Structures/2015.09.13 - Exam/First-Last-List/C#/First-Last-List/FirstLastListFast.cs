using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastListFast<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    //private List<T> elements = new List<T>();
    private readonly Deque<T> elements = new Deque<T>();
    private readonly OrderedBag<T> elementsOrdered = new OrderedBag<T>();

    public void Add(T newElement)
    {
        this.elements.Add(newElement);
        this.elementsOrdered.Add(newElement);
    }

    public int Count
    {
        get { return this.elements.Count; }
    }

    public IEnumerable<T> First(int count)
    {
        this.ValidateCount(count);
        return this.elements.Range(0, count);
    }

    public IEnumerable<T> Last(int count)
    {
        this.ValidateCount(count);
        List<T> result = new List<T>();
        int totalElements = this.elements.Count;
        for (int i = 0; i < count; i++)
        {
            result.Add(this.elements[totalElements - i - 1]);
        }

        return result;
    }

    public IEnumerable<T> Min(int count)
    {
        this.ValidateCount(count);
        List<T> result = new List<T>();
        for (int i = 0; i < count; i++)
        {
            result.Add(this.elementsOrdered[i]);
        }

        return result;
    }

    public IEnumerable<T> Max(int count)
    {
        this.ValidateCount(count);
        OrderedBag<T> result = new OrderedBag<T>();
        for (int i = 0; i < count; i++)
        {
            result.Add(this.elementsOrdered[this.elements.Count - 1 - i]);
        }

        return result.Reversed();
    }

    public int RemoveAll(T element)
    {
        int initialCount = this.elements.Count;
        this.elements.RemoveAll(e => e.CompareTo(element) == 0);
        return initialCount - this.elements.Count;
    }

    public void Clear()
    {
        this.elements.Clear();
        this.elementsOrdered.Clear();
    }

    private void ValidateCount(int count)
    {
        if (this.elements.Count < count)
        {
            throw new ArgumentOutOfRangeException("Not enough elements in collection.");
        }
    }
}
