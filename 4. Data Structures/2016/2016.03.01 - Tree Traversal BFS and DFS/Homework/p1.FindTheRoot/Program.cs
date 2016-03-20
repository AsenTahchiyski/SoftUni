using System;
using System.Collections.Generic;
using System.Linq;

namespace p1.FindTheRoot
{
    class Program
    {
        static Dictionary<int, Node> graph;

        static void Main()
        {
            int nodesTotal = int.Parse(Console.ReadLine());
            graph = new Dictionary<int, Node>();
            int edgesTotal = int.Parse(Console.ReadLine());
            for (int edge = 0; edge < edgesTotal; edge++)
            {
                int[] edgeParams = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int parentVal = edgeParams[0];
                int childVal = edgeParams[1];
                Node child = graph.ContainsKey(childVal) ? graph[childVal] : new Node(childVal);
                Node parent = graph.ContainsKey(parentVal) ? graph[parentVal] : new Node(parentVal);
                child.Parent = parent;
                parent.Children.Add(child);
                if(!graph.ContainsKey(childVal))
                {
                    graph.Add(childVal, child);
                }

                if (!graph.ContainsKey(parentVal)) 
                {
                    graph.Add(parentVal, parent);
                }   
            }

            // find root
            HashSet<Node> roots = new HashSet<Node>();
            foreach (Node node in graph.Values)
            {
                Node currentNode = node;
                int loopCounter = 0;
                while(currentNode != null && currentNode.HasParent && loopCounter <= nodesTotal)
                {
                    currentNode = currentNode.Parent;
                    loopCounter++;
                }

                if(currentNode != null && loopCounter <= nodesTotal)
                {
                    roots.Add(currentNode);
                }
            }

            int rootsTotal = roots.Count;
            if (rootsTotal == 0)
            {
                Console.WriteLine("No root!");
            }
            else if (rootsTotal == 1)
            {
                Console.WriteLine("Root node's value: " + roots.First().Value);
            } 
            else
            {
                Console.WriteLine("Multiple root nodes!");
            }
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public IList<Node> Children { get; set; }
        public Node Parent { get; set; }
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
            if(children != null)
            {
                foreach (var child in children)
                {
                    this.Children.Add(child);
                }
            }
        }
    }
}
