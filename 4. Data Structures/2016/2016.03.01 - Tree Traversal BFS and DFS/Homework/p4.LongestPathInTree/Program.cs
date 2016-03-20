using System;
using System.Collections.Generic;
using System.Linq;

namespace p4.LongestPathInTree
{
    class Program
    {
        static Dictionary<int, Node> tree;

        static void Main()
        {
            int nodesTotal = ReadTree();
            var root = FindRoot(nodesTotal);
            var leavesByPathLength = GetLeavesByPathLength();
            int longestPathSum = GetPathSum(leavesByPathLength.First().Key);
            int secondLongestPathSum = GetPathSum(leavesByPathLength.Skip(1).First().Key) - root.Value;
            Console.WriteLine("Longest path sum = " + (longestPathSum + secondLongestPathSum));
        }

        private static int GetPathSum(Node node)
        {
            int sum = 0;
            while(node.HasParent && !node.IsVisited)
            {
                sum += node.Value;
                node = node.Parent;
                node.IsVisited = true;
            }

            sum += node.Value; // adds the value of the root
            return sum;
        }

        private static Node FindRoot(int nodesTotal)
        {
            HashSet<Node> roots = new HashSet<Node>();
            foreach (Node node in tree.Values)
            {
                Node currentNode = node;
                int loopCounter = 0;
                while (currentNode != null && currentNode.HasParent && loopCounter <= nodesTotal)
                {
                    currentNode = currentNode.Parent;
                    loopCounter++;
                }

                if (currentNode != null && loopCounter <= nodesTotal)
                {
                    roots.Add(currentNode);
                }
            }

            int rootsTotal = roots.Count;
            if (rootsTotal == 0)
            {
                Console.WriteLine("No root!");
                return null;
            }
            else if (rootsTotal == 1)
            {
                Console.WriteLine("Root node's value: " + roots.First().Value);
            }
            else
            {
                Console.WriteLine("Multiple root nodes!");
                return null;
            }

            return roots.First();
        }

        private static int ReadTree()
        {
            int nodesTotal = int.Parse(Console.ReadLine());
            tree = new Dictionary<int, Node>();
            int edgesTotal = int.Parse(Console.ReadLine());
            for (int edge = 0; edge < edgesTotal; edge++)
            {
                int[] edgeParams = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int parentVal = edgeParams[0];
                int childVal = edgeParams[1];
                Node child = tree.ContainsKey(childVal) ? tree[childVal] : new Node(childVal);
                Node parent = tree.ContainsKey(parentVal) ? tree[parentVal] : new Node(parentVal);
                child.Parent = parent;
                parent.Children.Add(child);
                if (!tree.ContainsKey(childVal))
                {
                    tree.Add(childVal, child);
                }

                if (!tree.ContainsKey(parentVal))
                {
                    tree.Add(parentVal, parent);
                }
            }

            return nodesTotal;
        }

        private static IOrderedEnumerable<KeyValuePair<Node, int>> GetLeavesByPathLength()
        {
            var leavesByPathLength = new Dictionary<Node, int>();
            foreach (var node in tree.Values)
            {
                int length = 1;
                var currentNode = node;
                while(currentNode.HasParent)
                {
                    length++;
                    currentNode = currentNode.Parent;
                }

                leavesByPathLength.Add(node, length);
            }

            var result = leavesByPathLength.OrderByDescending(x => x.Value).ThenByDescending(n => n.Key.Value);
            return result;
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public IList<Node> Children { get; set; }
        public Node Parent { get; set; }
        public bool IsVisited { get; set; }
        public bool HasParent
        {
            get
            {
                return this.Parent != null;
            }
        }

        public Node(int value, IEnumerable<Node> children = null)
        {
            this.Value = value;
            this.Children = new List<Node>();
            if (children != null)
            {
                foreach (var child in children)
                {
                    this.Children.Add(child);
                }
            }
        }
    }
}
