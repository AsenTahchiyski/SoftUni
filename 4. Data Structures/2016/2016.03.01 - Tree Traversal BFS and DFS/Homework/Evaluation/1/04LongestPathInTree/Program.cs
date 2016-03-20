namespace _04LongestPathInTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static HashSet<int> children = new HashSet<int>();

        private static int sum = 0;

        private static int bestSum = 0;

        private static int treeRoot;

        private static List<int> bestSums = new List<int>(); 

        static void Main()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            var parentChildren = new Dictionary<int, List<int>>();
            for (int i = 0; i < edges; i++)
            {
                int[] edge =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                if (!parentChildren.ContainsKey(edge[0]))
                {
                    parentChildren[edge[0]] = new List<int>();
                }

                parentChildren[edge[0]].Add(edge[1]);
                children.Add(edge[1]);
            }

            int rootNode = parentChildren.Keys.FirstOrDefault(n => !children.Contains(n));
            treeRoot = rootNode;
            FindLongestPathWithBiggestSum(parentChildren, rootNode);
            Console.WriteLine("Max sum path is: " + (bestSums.Sum() + treeRoot));
        }

        private static void FindLongestPathWithBiggestSum(Dictionary<int, List<int>> parentChildren, int rootNode)
        {
            int currentNode = rootNode;
            if (parentChildren.ContainsKey(rootNode))
            {
                var children = parentChildren[rootNode];
                foreach (var child in children)
                {
                    if (rootNode == treeRoot)
                    {
                        bestSums.Add(bestSum);
                    }

                    sum += child;
                    FindLongestPathWithBiggestSum(parentChildren, child);
                    sum -= child;
                }

                if (rootNode == treeRoot)
                {
                    bestSums.Add(bestSum);
                }
            }

            if (bestSum < sum)
            {
                bestSum = sum;
            }
        }
    }
}
