namespace PlayWithTrees
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class Tree<T>
    {
        private static int treeDepthCounter = 1;
        private static Tree<int> currentRoot = FindRootNode(); 

        public T Value { get; set; }
        public Tree<T> Parent { get; set; }
        public IList<Tree<T>> Children { get; private set; }

        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.Children.Add(child);
                child.Parent = this;
            }
        }

        private static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        public static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }

        public static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent == null);
            return rootNode;
        }

        public static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = nodeByValue.Values.Where(node => node.Children.Count > 0 && node.Parent != null).ToList();
            return middleNodes;
        }

        public static IEnumerable<Tree<int>> FindLeafNodes()
        {
            var leafNodes = nodeByValue.Values.Where(node => node.Children.Count == 0).ToList();
            return leafNodes;
        }

        public static int FindLongestPath(Tree<int> root)
        {
            if (treeDepthCounter == 1)
            {
                root = currentRoot;
            }

            if (root.Children.Count == 0)
            {
                return treeDepthCounter;
            }
            else
            {
                foreach (var child in root.Children)
                {
                    treeDepthCounter++;
                    root = child;
                    FindLongestPath(root);
                }
            }
        }
    }
}
