namespace _1.AA_Tree
{
    using System;

    public class AATree<TKey, TValue> where TKey : IComparable<TKey>
    {
        public class Node
        {
            internal int Level { get; set; }
            internal Node Left;
            internal Node Right;
            
            internal TKey Key { get; set; }
            internal TValue Value { get; set; }

            // constructor for the sentinel node
            internal Node()
            {
                this.Level = 0;
                this.Left = this;
                this.Right = this;
            }

            // constructor for regular nodes (that start their life as a leaf)
            internal Node(TKey key, TValue value, Node sentinel)
            {
                this.Level = 1;
                this.Left = sentinel;
                this.Right = sentinel;
                this.Key = key;
                this.Value = value;
            }
        }

        private Node root;
        private Node sentinel;
        private Node deleted;

        public Node Root
        {
            get { return this.root; }
        }

        public AATree()
        {
            this.root = this.sentinel = new Node();
            this.deleted = null;
        }

        private void Skew(ref Node node)
        {
            if (node.Level == node.Left.Level)
            {
                // rotate right
                Node leftNode = node.Left;
                node.Left = node.Right;
                leftNode.Right = node;
                node = leftNode;
            }
        }

        private void Split(ref Node node)
        {
            if (node.Right.Right.Level == node.Level)
            {
                // rotate left
                Node rightNode = node.Right;
                node.Right = rightNode.Left;
                rightNode.Left = node;
                node = rightNode;
                node.Level++;
            }
        }

        private bool Insert(ref Node node, TKey key, TValue value)
        {
            if (node == this.sentinel)
            {
                node = new Node(key, value, this.sentinel);
                return true;
            }

            int compare = key.CompareTo(node.Key);
            if (compare < 0)
            {
                if (!Insert(ref node.Left, key, value))
                {
                    return false;
                }
            }
            else if (compare > 0)
            {
                if (!Insert(ref node.Right, key, value))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            Skew(ref node);
            Split(ref node);

            return true;
        }

        private bool Delete(ref Node node, TKey key)
        {
            if (node == this.sentinel)
            {
                return this.deleted != null;
            }

            int compare = key.CompareTo(node.Key);
            if (compare < 0)
            {
                if (!Delete(ref node.Left, key))
                {
                    return false;
                }
            }
            else
            {
                if (compare == 0)
                {
                    this.deleted = node;
                }

                if (!Delete(ref node.Right, key))
                {
                    return false;
                }
            }

            if (this.deleted != null)
            {
                this.deleted.Key = node.Key;
                this.deleted.Value = node.Value;
                this.deleted = null;
                node = node.Right;
            }
            else if (node.Left.Level < node.Level - 1 ||
                node.Right.Level < node.Level - 1)
            {
                --node.Level;
                if (node.Right.Level > node.Level)
                {
                    node.Right.Level = node.Level;
                }

                this.Skew(ref node);
                this.Skew(ref node.Right);
                this.Skew(ref node.Right.Right);
                this.Split(ref node);
                this.Split(ref node.Right);
            }

            return true;
        }

        private Node Search(Node node, TKey key)
        {
            if (node == this.sentinel)
            {
                return null;
            }

            int compare = key.CompareTo(node.Key);
            if (compare < 0)
            {
                return Search(node.Left, key);
            }
            else if (compare > 0)
            {
                return Search(node.Right, key);
            }
            else
            {
                return node;
            }
        }

        public bool Add(TKey key, TValue value)
        {
            return Insert(ref root, key, value);
        }

        public bool Remove(TKey key)
        {
            return Delete(ref root, key);
        }

        public TValue this[TKey key]
        {
            get
            {
                Node node = Search(root, key);
                return node == null ? default(TValue) : node.Value;
            }
            set
            {
                Node node = Search(root, key);
                if (node == null)
                {
                    Add(key, value);
                }
                else
                {
                    node.Value = value;
                }
            }
        }
    }
}
