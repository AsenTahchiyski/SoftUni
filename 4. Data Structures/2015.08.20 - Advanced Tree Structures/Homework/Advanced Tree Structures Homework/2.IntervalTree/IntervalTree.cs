//// https://github.com/vvondra/Interval-Tree
namespace _2.IntervalTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Tree capable of adding arbitrary intervals and performing search queries on them
    /// </summary>
    public class IntervalTree<T> : IEnumerable<Interval<T>> where T : struct, IComparable<T>
    {
        internal static IntervalNode<T> Sentinel = new IntervalNode<T>(new Interval<T>());

        internal IntervalNode<T> Root { get; set; }

        public IntervalTree()
        {
            this.Root = Sentinel;
            this.Root.Left = Sentinel;
            this.Root.Right = Sentinel;
            this.Root.Parent = Sentinel;
        }

        /// <summary>
        /// Search interval tree for a given point
        /// </summary>
        /// <param name="value">value to be searched for</param>
        /// <returns>list of intervals which contain the value</returns>
        public List<Interval<T>> Search(T value)
        {
            var result = new List<Interval<T>>();
            this.SearchSubtree(Root, value, result);
            return result;
        }

        /// <summary>
        /// Search interval tree for intervals overlapping with given
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public List<Interval<T>> Search(Interval<T> interval)
        {
            var result = new List<Interval<T>>();
            this.SearchSubtree(Root, interval, result);
            return result;
        }

        /// <summary>
        /// Searches for the first overlapping interval
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public Interval<T> SearchFirstOverlapping(Interval<T> interval)
        {
            var node = this.Root;

            while (node != Sentinel && !node.Interval.Overlaps(interval))
            {
                if (node.Left != Sentinel && node.Left.MaxEnd.CompareTo(interval.Start) >= 0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            if (node == Sentinel)
            {
                throw new KeyNotFoundException("No overlapping interval found.");
            }

            return node.Interval;
        }

        private void SearchSubtree(IntervalNode<T> node, Interval<T> interval, ICollection<Interval<T>> result)
        {
            if (node == Sentinel)
            {
                return;
            }

            if (node.Left != Sentinel)
            {
                SearchSubtree(node.Left, interval, result);
            }

            if (interval.Overlaps(node.Interval))
            {
                result.Add(node.Interval);
            }

            // Interval start is greater than largest endpoint in this subtree
            if (node.Right != Sentinel && interval.Start.CompareTo(node.MaxEnd) <= 0)
            {
                this.SearchSubtree(node.Right, interval, result);
            }
        }

        private static IntervalNode<T> FindInterval(IntervalNode<T> tree, Interval<T> interval)
        {
            while (tree != Sentinel)
            {

                if (tree.Interval.CompareTo(interval) > 0)
                {
                    tree = tree.Left;
                    continue;
                }

                if (tree.Interval.CompareTo(interval) < 0)
                {
                    tree = tree.Right;
                    continue;
                }

                if (tree.Interval.CompareTo(interval) == 0)
                {
                    return tree;
                }
            }

            return Sentinel;
        }

        /// <summary>
        /// Recursively descends down the tree and adds valids results to the resultset
        /// </summary>
        /// <param name="node">subtree to be searched</param>
        /// <param name="val">value to be searched for</param>
        /// <param name="result">current resultset</param>
        private void SearchSubtree(IntervalNode<T> node, T val, List<Interval<T>> result)
        {
            if (node == Sentinel)
            {
                return;
            }

            // Value is higher than any interval in this subtree
            if (val.CompareTo(node.MaxEnd) > 0)
            {
                return;
            }

            if (node.Left != Sentinel)
            {
                this.SearchSubtree(node.Left, val, result);
            }

            if (node.Interval.Contains(val))
            {
                result.Add(node.Interval);
            }

            if (val.CompareTo(node.Interval.Start) < 0)
            {
                return;
            }

            if (node.Right != Sentinel)
            {
                this.SearchSubtree(node.Right, val, result);
            }
        }

        /// <summary>
        /// Insert new interval to interval tree
        /// </summary>
        /// <param name="interval">interval to add</param>
        public void Add(Interval<T> interval)
        {
            var node = new IntervalNode<T>(interval);
            if (this.Root == Sentinel)
            {
                node.Color = NodeColor.Black;
                this.Root = node;
            }
            else
            {
                this.InsertInterval(interval, Root);
            }
        }

        /// <summary>
        /// Recursively descends to the correct spot for interval insertion in the tree
        /// When a free spot is found for the node, it is attached and tree state is validated
        /// </summary>
        /// <param name="interval">interval to be added</param>
        /// <param name="currentNode">subtree accessed in recursion</param>
        private void InsertInterval(Interval<T> interval, IntervalNode<T> currentNode)
        {
            var addedNode = Sentinel;
            if (interval.CompareTo(currentNode.Interval) < 0)
            {
                if (currentNode.Left == Sentinel)
                {
                    addedNode = new IntervalNode<T>(interval);
                    addedNode.Color = NodeColor.Red;
                    currentNode.Left = addedNode;
                    addedNode.Parent = currentNode;
                }
                else
                {
                    InsertInterval(interval, currentNode.Left);
                    return;
                }
            }
            else if (interval.CompareTo(currentNode.Interval) > 0)
            {
                if (currentNode.Right == Sentinel)
                {
                    addedNode = new IntervalNode<T>(interval);
                    addedNode.Color = NodeColor.Red;
                    currentNode.Right = addedNode;
                    addedNode.Parent = currentNode;
                }
                else
                {
                    this.InsertInterval(interval, currentNode.Right);
                    return;
                }
            }
            else
            {
                return;
            }

            addedNode.Parent.RecalculateMaxEnd();
            this.RenewConstraintsAfterInsert(addedNode);
            this.Root.Color = NodeColor.Black;
        }

        /// <summary>
        /// Validates and applies RB-tree constaints to node 
        /// </summary>
        /// <param name="node">node to be validated and fixed</param>
        private void RenewConstraintsAfterInsert(IntervalNode<T> node)
        {
            if (node.Parent == Sentinel)
            {
                return;
            }

            if (node.Parent.Color == NodeColor.Black)
            {
                return;
            }

            var uncle = node.Uncle;

            if (uncle != Sentinel && uncle.Color == NodeColor.Red)
            {
                node.Parent.Color = uncle.Color = NodeColor.Black;

                var gparent = node.GrandParent;
                if (gparent != Sentinel && !gparent.IsRoot)
                {
                    gparent.Color = NodeColor.Red;
                    this.RenewConstraintsAfterInsert(gparent);
                }
            }
            else
            {
                if (node.ParentDirection == NodeDirection.Left && node.Parent.ParentDirection == NodeDirection.Right)
                {
                    RotateLeft(node.Parent);
                    node = node.Left;
                }
                else if (node.ParentDirection == NodeDirection.Right && node.Parent.ParentDirection == NodeDirection.Left)
                {
                    this.RotateRight(node.Parent);
                    node = node.Right;
                }

                node.Parent.Color = NodeColor.Black;
                if (node.GrandParent == Sentinel)
                {
                    return;
                }

                node.GrandParent.Color = NodeColor.Red;
                if (node.ParentDirection == NodeDirection.Right)
                {
                    this.RotateRight(node.GrandParent);
                }
                else
                {
                    this.RotateLeft(node.GrandParent);
                }
            }
        }

        /// <summary>
        /// Removes interval from tree (if present in tree)
        /// </summary>
        /// <param name="?"></param>
        public void Remove(Interval<T> interval)
        {
            this.RemoveNode(FindInterval(Root, interval));
        }

        private void RemoveNode(IntervalNode<T> node)
        {
            if (node == Sentinel)
            {
                return;
            }

            IntervalNode<T> temp = node;
            if (node.Right != Sentinel && node.Left != Sentinel)
            {
                // Trick when deleting node with both children, switch it with closest in order node
                // swap values and delete the bottom node converting it to other cases

                temp = node.GetSuccessor();
                node.Interval = temp.Interval;

                node.RecalculateMaxEnd();
                while (node.Parent != Sentinel)
                {
                    node = node.Parent;
                    node.RecalculateMaxEnd();
                }
            }

            node = temp;
            temp = node.Left != Sentinel ? node.Left : node.Right;

            // we will replace node with temp and delete node
            temp.Parent = node.Parent;
            if (node.IsRoot)
            {
                this.Root = temp; // Set new root
            }
            else
            {

                // Reattach node to parent
                if (node.ParentDirection == NodeDirection.Right)
                {
                    node.Parent.Left = temp;
                }
                else
                {
                    node.Parent.Right = temp;
                }

                IntervalNode<T> maxAux = node.Parent;
                maxAux.RecalculateMaxEnd();
                while (maxAux.Parent != Sentinel)
                {
                    maxAux = maxAux.Parent;
                    maxAux.RecalculateMaxEnd();
                }
            }

            if (node.Color == NodeColor.Black)
            {
                this.RenewConstraintsAfterDelete(temp);
            }

        }

        /// <summary>
        /// Ensures constraints still apply after node deletion
        /// 
        ///  - made with the help of algorithm from Cormen et Al. Introduction to Algorithms 2nd ed.
        /// </summary>
        /// <param name="node"></param>
        private void RenewConstraintsAfterDelete(IntervalNode<T> node)
        {
            // Need to bubble up and fix
            while (node != this.Root && node.Color == NodeColor.Black)
            {
                if (node.ParentDirection == NodeDirection.Right)
                {
                    IntervalNode<T> aux = node.Parent.Right;
                    if (aux.Color == NodeColor.Red)
                    {
                        aux.Color = NodeColor.Black;
                        node.Parent.Color = NodeColor.Red;
                        this.RotateLeft(node.Parent);
                        aux = node.Parent.Right;
                    }

                    if (aux.Left.Color == NodeColor.Black && aux.Right.Color == NodeColor.Black)
                    {
                        aux.Color = NodeColor.Red;
                        node = node.Parent;
                    }
                    else
                    {
                        if (aux.Right.Color == NodeColor.Black)
                        {
                            aux.Left.Color = NodeColor.Black;
                            aux.Color = NodeColor.Red;
                            RotateRight(aux);
                            aux = node.Parent.Right;
                        }

                        aux.Color = node.Parent.Color;
                        node.Parent.Color = NodeColor.Black;
                        aux.Right.Color = NodeColor.Black;
                        this.RotateLeft(node.Parent);
                        node = Root;
                    }
                }
                else
                {
                    IntervalNode<T> aux = node.Parent.Left;
                    if (aux.Color == NodeColor.Red)
                    {
                        aux.Color = NodeColor.Black;
                        node.Parent.Color = NodeColor.Red;
                        this.RotateRight(node.Parent);
                        aux = node.Parent.Left;
                    }

                    if (aux.Left.Color == NodeColor.Black && aux.Right.Color == NodeColor.Black)
                    {
                        aux.Color = NodeColor.Red;
                        node = node.Parent;
                    }
                    else
                    {
                        if (aux.Left.Color == NodeColor.Black)
                        {
                            aux.Right.Color = NodeColor.Black;
                            aux.Color = NodeColor.Red;
                            this.RotateLeft(aux);
                            aux = node.Parent.Left;
                        }

                        aux.Color = node.Parent.Color;
                        node.Parent.Color = NodeColor.Black;
                        aux.Left.Color = NodeColor.Black;
                        this.RotateRight(node.Parent);
                        node = Root;
                    }
                }
            }

            node.Color = NodeColor.Black;
        }

        /// <summary>
        /// General right rotation
        /// </summary>
        /// <param name="node">Top of rotated subtree</param>
        private void RotateRight(IntervalNode<T> node)
        {
            var pivot = node.Left;
            NodeDirection dir = node.ParentDirection;
            var parent = node.Parent;
            var tempTree = pivot.Right;
            pivot.Right = node;
            node.Parent = pivot;
            node.Left = tempTree;
            if (tempTree != Sentinel)
            {
                tempTree.Parent = node;
            }

            if (dir == NodeDirection.Left)
            {
                parent.Right = pivot;
            }
            else if (dir == NodeDirection.Right)
            {
                parent.Left = pivot;
            }
            else
            {
                this.Root = pivot;
            }

            pivot.Parent = parent;
            pivot.RecalculateMaxEnd();
            node.RecalculateMaxEnd();
        }

        /// <summary>
        /// General left rotation
        /// </summary>
        /// <param name="node">top of rotated subtree</param>
        private void RotateLeft(IntervalNode<T> node)
        {
            var pivot = node.Right;
            NodeDirection dir = node.ParentDirection;
            var parent = node.Parent;
            var tempTree = pivot.Left;
            pivot.Left = node;
            node.Parent = pivot;
            node.Right = tempTree;
            if (tempTree != Sentinel)
            {
                tempTree.Parent = node;
            }

            if (dir == NodeDirection.Left)
            {
                parent.Right = pivot;
            }
            else if (dir == NodeDirection.Right)
            {
                parent.Left = pivot;
            }
            else
            {
                this.Root = pivot;
            }

            pivot.Parent = parent;
            pivot.RecalculateMaxEnd();
            node.RecalculateMaxEnd();
        }

        private IEnumerable<Interval<T>> InOrderWalk(IntervalNode<T> node)
        {
            if (node.Left != Sentinel)
            {
                foreach (Interval<T> val in InOrderWalk(node.Left))
                {
                    yield return val;
                }
            }

            if (node != Sentinel)
            {
                yield return node.Interval;
            }

            if (node.Right != Sentinel)
            {
                foreach (Interval<T> val in InOrderWalk(node.Right))
                {
                    yield return val;
                }
            }
        }

        public IEnumerator<Interval<T>> GetEnumerator()
        {
            foreach (Interval<T> val in InOrderWalk(Root))
            {
                yield return val;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}