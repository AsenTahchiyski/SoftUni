namespace PlayWithTrees
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < nodesCount - 1; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');

                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = Tree<int>.GetTreeNodeByValue(parentValue);

                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = Tree<int>.GetTreeNodeByValue(childValue);

                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            var rootNode = Tree<int>.FindRootNode();
            Console.WriteLine("Root node: {0}", rootNode.Value);

            var leafNodes = Tree<int>.FindLeafNodes();
            var leafNodesValues = leafNodes.Select(node => node.Value).OrderBy(x => x);
            Console.WriteLine("Leaf nodes: " + string.Join(", ", leafNodesValues));

            var middleNodes = Tree<int>.FindMiddleNodes();
            var middleNodesValues = middleNodes.Select(node => node.Value).OrderBy(x => x);
            Console.WriteLine("Middle nodes: " + string.Join(", ", middleNodesValues));

            //int pathSum = int.Parse(Console.ReadLine());
            //int subtreeSum = int.Parse(Console.ReadLine());
        }
    }
}
