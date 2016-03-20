using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastListSlow<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private List<T> elements = new List<T>();

    public void Add(T newElement)
    {
        this.elements.Add(newElement);
    }

    public int Count
    {
        get { return elements.Count; }
    }

    public IEnumerable<T> First(int count)
    {
        ValidateCountValid(count);

        List<T> result = new List<T>();
        for (int i = 0; i < count; i++)
        {
            result.Add(this.elements[i]);
        }

        return result;
    }

    public IEnumerable<T> Last(int count)
    {
        ValidateCountValid(count);
        List<T> result = new List<T>();
        for (int i = 0; i < count; i++)
        {
            result.Add(this.elements[this.elements.Count - 1 - i]);
        }

        return result;
    }

    public IEnumerable<T> Min(int count)
    {
        ValidateCountValid(count);
        List<T> result = new List<T>();
        List<T> listCopy = this.elements.ToList();
        int elementsFound = 0;
        while (elementsFound < count)
        {
            int minElementIndex = listCopy.IndexOf(listCopy.Min());
            T minElement = listCopy.Min();
            if (minElementIndex == -1)
            {
                minElementIndex = 0;
                minElement = listCopy[minElementIndex];
            }

            result.Add(minElement);
            listCopy.RemoveAt(minElementIndex);
            elementsFound++;
        }

        return result;
    }

    public IEnumerable<T> Max(int count)
    {
        ValidateCountValid(count);
        //List<T> result = new List<T>();
        OrderedBag<T> result = new OrderedBag<T>();
        List<T> listCopy = this.elements.ToList();
        int elementsFound = 0;
        while (elementsFound < count)
        {
            int maxElementIndex = listCopy.IndexOf(listCopy.Max());
            T maxElement = listCopy.Max();
            if (maxElementIndex == -1)
            {
                maxElementIndex = 0;
                maxElement = listCopy[maxElementIndex];
            }

            result.Add(maxElement);
            listCopy.RemoveAt(maxElementIndex);
            elementsFound++;
        }

        return result;
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
    }

    private void ValidateCountValid(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException("There are no that much elements in the collection.");
        }
    }
}
