using System;
using System.Collections;
using System.Collections.Generic;

public class Node<T> : IEnumerable<T>, IComparable<Node<T>> where T : IComparable<T>
{
    public Node(T value)
    {
        this.Value = value;
        this.Parent = null;
        this.LeftChild = null;
        this.RightChild = null;
    }

    public T Value { get; set; }
    public Node<T> Parent { get; set; }
    public Node<T> LeftChild { get; set; }
    public Node<T> RightChild { get; set; }

    public override string ToString()
    {
        return this.Value.ToString();
    }

    public override int GetHashCode()
    {
        return this.Value.GetHashCode();
    }

    public int CompareTo(Node<T> other)
    {
        return this.Value.CompareTo(other.Value);
    }

    public override bool Equals(object obj)
    {
        Node<T> other = (Node<T>)obj;
        return this.CompareTo(other) == 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (this.LeftChild != null)
        {
            foreach (var child in this.LeftChild)
                yield return child;
        }

        yield return this.Value;

        if (this.RightChild != null)
        {
            foreach (var child in this.RightChild)
                yield return child;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void EachInOrder(Action<T> action)
    {
        if (this.LeftChild != null)
        {
            this.LeftChild.EachInOrder(action);
        }

        action(this.Value);

        if (this.RightChild != null)
        {
            this.RightChild.EachInOrder(action);
        }
    }
}

