using System;
using System.Collections;
using System.Collections.Generic;

class OrderedSet<T> : IEnumerable<T> where T : IComparable<T> 
{
    public OrderedSet()
    {
        this.Root = null;
        this.Count = 0;
    }

    public Node<T> Root { get; set; }
    public int Count { get; set; }

    public void Add(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Cannot insert null value!");
        }

        if (!this.Contains(value))
        {
            this.Count++;
        }

        this.Root = Insert(value, null, this.Root);
    }

    private Node<T> Insert(T value, Node<T> parentNode, Node<T> node)
    {
        // if position is empty --> insert the <node>
        if (node == null)
        {
            node = new Node<T>(value);
            node.Parent = parentNode;
        }
        else
        {
            int compareTo = value.CompareTo(node.Value);
            if (compareTo < 0)
            {
                node.LeftChild = Insert(value, node, node.LeftChild);
            }
            else if (compareTo > 0)
            {
                node.RightChild = Insert(value, node, node.RightChild);
            }
        }

        return node;
    }

    public Node<T> Find(T value)
    {
        Node<T> currNode = this.Root;
        while (currNode != null)
        {
            int compareTo = value.CompareTo(currNode.Value);
            if (compareTo < 0)
            {
                currNode = currNode.LeftChild;
            }
            else if (compareTo > 0)
            {
                currNode = currNode.RightChild;
            }
            else
            {
                break;
            }
        }

        return currNode;
    }

    public bool Contains(T value)
    {
        var element = this.Find(value);
        return element != null;
    }

    public void Remove(T value)
    {
        Node<T> nodeToDelete = Find(value);
        if (nodeToDelete == null)
        {
            return;
        }

        Delete(nodeToDelete);
        this.Count--;
    }

    private void Delete(Node<T> nodeToDelete)
    {
        // If node has two children
        if (nodeToDelete.LeftChild != null && nodeToDelete.RightChild != null)
        {
            Node<T> replacement = nodeToDelete.RightChild;
            while (replacement.LeftChild != null)
            {
                replacement = replacement.LeftChild;
            }

            nodeToDelete.Value = replacement.Value;
            nodeToDelete = replacement;
        }

        // If the node has at most one child
        Node<T> theChild = nodeToDelete.LeftChild != null ? nodeToDelete.LeftChild : nodeToDelete.RightChild;

        // If the element to be deleted has one child
        if (theChild != null)
        {
            theChild.Parent = nodeToDelete.Parent;
            // Handle the case when the element is the root
            if (nodeToDelete.Parent.Parent == null)
            {
                this.Root = theChild;
            }
            else
            {
                // Replace the element with its subtree
                if (nodeToDelete.Parent.LeftChild == nodeToDelete)
                {
                    nodeToDelete.Parent.LeftChild = theChild;
                }
                else
                {
                    nodeToDelete.Parent.RightChild = theChild;
                }
            }
        }
        else
        {
            // Handle the case when the element is the root
            if (nodeToDelete.Parent == null)
            {
                this.Root = null;
            }
            else
            {
                // Removes the element - it is a leaf
                if (nodeToDelete.Parent.LeftChild == nodeToDelete)
                {
                    nodeToDelete.Parent.LeftChild = null;
                }
                else
                {
                    nodeToDelete.Parent.RightChild = null;
                }
            }
        }
    }

    public T Min()
    {
        if (this.Root == null)
        {
            throw new InvalidOperationException("Can not get Min() from empty OrderedSet!");
        }

        var currentNode = this.Root;
        T minValue = default(T);
        while (currentNode != null)
        {
            minValue = currentNode.Value;
            currentNode = currentNode.LeftChild;
        }

        return minValue;
    }

    public T Max()
    {
        if (this.Root == null)
        {
            throw new InvalidOperationException("Can not get Max() from empty OrderedSet!");
        }

        var currentNode = this.Root;
        T maxValue = default(T);
        while (currentNode != null)
        {
            maxValue = currentNode.Value;
            currentNode = currentNode.RightChild;
        }

        return maxValue;
    }

    public void Clear()
    {
        this.Root = null;
        this.Count = 0;
    }
   
    public void PrintInorder(Node<T> root)
    {
        if (root == null)
        {
            return;
        }

        PrintInorder(root.LeftChild);
        Console.Write(root.Value + " ");
        PrintInorder(root.RightChild);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.Root.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void EachInOrder(Action<T> action)
    {
        if (this.Root.LeftChild != null)
        {
            this.Root.LeftChild.EachInOrder(action);
        }

        action(this.Root.Value);

        if (this.Root.RightChild != null)
        {
            this.Root.RightChild.EachInOrder(action);
        }
    }
}