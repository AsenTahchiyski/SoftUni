using System;

namespace AvlTreeLab
{
    public class Node<T>
    {
        private Node<T> leftChild;
        private Node<T> rightChild;

        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> LeftChild
        {
            get
            {
                return this.leftChild;
            }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.leftChild = value;
            }
        }

        public Node<T> RightChild {
            get
            {
                return this.rightChild;
            }
            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.rightChild = value;
            }
        }

        public Node<T> Parent { get; set; }

        public int BallanceFactor { get; set; }

        public int Count { get; set; }

        public bool IsLeftChild
        {
            get
            {
                if (this == null)
                {
                    throw new InvalidOperationException("Node is null.");
                }

                if (this.Parent == null || this.Parent.LeftChild == null)
                {
                    return false;
                }

                return this.Parent.LeftChild == this;
            }
        }

        public bool IsRightChild
        {
            get
            {
                if (this == null)
                {
                    throw new InvalidOperationException("Node is null.");
                }

                if (this.Parent == null || this.Parent.RightChild == null)
                {
                    return false;
                }

                return this.Parent.RightChild == this;
            }
        }

        public int ChildrenCount
        {
            get
            {
                if (this == null)
                {
                    throw new InvalidOperationException("Node is null.");
                }

                int children = 0;
                if (this.LeftChild != null)
                {
                    children++;
                }

                if (this.RightChild != null)
                {
                    children++;
                }

                return children;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}

