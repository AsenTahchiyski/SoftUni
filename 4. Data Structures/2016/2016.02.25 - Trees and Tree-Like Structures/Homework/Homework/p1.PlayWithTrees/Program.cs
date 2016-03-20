using System;
using System.Collections.Generic;
using System.Linq;

namespace p1.PlayWithTrees
{
    class Program
    {
        static Dictionary<int, Tree<int>> nodesByValue = new Dictionary<int, Tree<int>>();

        static void Main()
        {
            // Read input parameters and build the tree
            int nodeCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < nodeCount - 1; i++)
            {
                var branch = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int parentVal = int.Parse(branch[0]);
                int childVal = int.Parse(branch[1]);
                var parent = GetNodeByValue(parentVal);
                var child = GetNodeByValue(childVal);
                parent.Children.Add(child);
                child.Parent = parent;
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            // Get and print first three results
            var root = FindRootNode();
            Console.WriteLine("Root node: " + root.Value);
            var leafNodesSorted = FindLeafNodes().OrderBy(l => l.Value).Select(n => n.Value);
            Console.WriteLine("Leaf nodes: " + string.Join(", ", leafNodesSorted));
            var middleNodesSorted = FindMiddleNodes().OrderBy(m => m.Value).Select(n => n.Value);
            Console.WriteLine("Middle nodes: " + string.Join(", ", middleNodesSorted.ToList()));

            // Find longest path
            var longestPathLeaf = FindLongestPathLeaf();
            var longestPath = BuildPathFromLeaf(longestPathLeaf);
            Console.WriteLine("Longest path: {0} (length = {1})", string.Join(" -> ", longestPath.Select(x => x.Value)), longestPath.Count());

            // Find paths with sum pathSum
            Console.WriteLine("Paths of sum {0}:", pathSum);
            var leavesInPaths = FindPathsWithGivenSum(pathSum);
            foreach (var node in leavesInPaths)
            {
                var path = BuildPathFromLeaf(node);
                Console.WriteLine(string.Join(" -> ", path.Select(l => l.Value)));
            }

            // Find subtrees of subtreeSum
            var subtreesWithGivenSum = FindSubtreesWithGivenSum(subtreeSum);
            Console.WriteLine("Subtrees of sum {0}:", subtreeSum);
            foreach (var node in subtreesWithGivenSum)
            {
                var path = GetAllTreeNodes(node);
                Console.WriteLine(string.Join(" + ", path.Select(e => e.Value)));
                allTreeNodes.Clear();
            }
        }

        static Tree<int> GetNodeByValue(int value)
        {
            if (!nodesByValue.ContainsKey(value))
            {
                nodesByValue[value] = new Tree<int>(value);
            }

            return nodesByValue[value];
        }

        static Tree<int> FindRootNode()
        {
            var root = nodesByValue.Values.FirstOrDefault(n => n.Parent == null);
            return root;
        }

        static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = nodesByValue.Values.Where(n => n.Children.Count > 0 && n.Parent != null);
            return middleNodes;
        }

        static IEnumerable<Tree<int>> FindLeafNodes()
        {
            var leaves = nodesByValue.Values.Where(n => n.Children.Count == 0 && n.Parent != null);
            return leaves;
        }

        static Tree<int> FindLongestPathLeaf()
        {
            var leaves = FindLeafNodes().ToArray();
            int counter = 1;
            int maxPathLength = 0;
            Tree<int> farthestLeaf = null;
            for (int i = 0; i < leaves.Length; i++)
            {
                Tree<int> currentNode = leaves[i];
                while(currentNode.Parent != null)
                {
                    counter++;
                    currentNode = currentNode.Parent;
                    if(currentNode.Parent == null) // reached the root
                    {
                        if(maxPathLength < counter)
                        {
                            maxPathLength = counter;
                            farthestLeaf = leaves[i];
                        }

                        counter = 1;
                    }
                }
            }

            return farthestLeaf;
        }

        static List<Tree<int>> BuildPathFromLeaf(Tree<int> leaf)
        {
            var path = new List<Tree<int>>();
            var currentNode = leaf;
            while(currentNode != null)
            {
                path.Add(currentNode);
                currentNode = currentNode.Parent;
            }

            path.Reverse();
            return path;
        }

        static List<Tree<int>> FindPathsWithGivenSum(int sum)
        {
            var leafNodes = FindLeafNodes().ToArray();
            var result = new List<Tree<int>>();
            for (int i = 0; i < leafNodes.Length; i++)
            {
                var currentNode = leafNodes[i];
                int currentSum = currentNode.Value;
                while(currentNode.Parent != null)
                {
                    currentNode = currentNode.Parent;
                    currentSum += currentNode.Value;
                    if (currentSum == sum && currentNode.Parent == null)
                    {
                        result.Add(leafNodes[i]);
                    }
                    else if(currentSum > sum)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        static List<Tree<int>> FindSubtreesWithGivenSum(int sum)
        {
            List<Tree<int>> result = new List<Tree<int>>();
            foreach (Tree<int> child in nodesByValue.Values)
            {
                totalTreeSum = 0;
                GetTreeSum(child);
                int currentSum = totalTreeSum;
                if (currentSum == sum)
                {
                    result.Add(child);
                }
            }

            return result;
        }

        private static int totalTreeSum;
        private static void GetTreeSum(Tree<int> root)
        {
            totalTreeSum += root.Value;
            foreach (var child in root.Children)
            {
                GetTreeSum(child);
            }
        }

        private static List<Tree<int>> allTreeNodes = new List<Tree<int>>();
        static List<Tree<int>> GetAllTreeNodes(Tree<int> root)
        {
            allTreeNodes.Add(root);
            foreach (var child in root.Children)
            {
                GetAllTreeNodes(child);
            }

            return allTreeNodes;
        }
    }
}
