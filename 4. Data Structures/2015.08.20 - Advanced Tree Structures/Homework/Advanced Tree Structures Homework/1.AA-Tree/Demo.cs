namespace _1.AA_Tree
{
    using System;

    internal class Demo
    {
        public static void Main()
        {
            var tree = new AATree<int, string>();
            Console.WriteLine("The AA tree created.");
            var nums = new[] {1, 2, 14, 3, 5, 8, 12, 17, 210, -1};
            for (int i = 0; i < nums.Length; i++)
            {
                AddNumber(tree, nums[i], "value " + nums[i]);
            }
        }

        public static void AddNumber(AATree<int, string> tree, int key, string value)
        {
            tree.Add(key, value);
            Console.WriteLine("Added " + key);

            DisplayTree(tree.Root, string.Empty);
            Console.WriteLine("----------------------");
        }

        private static void DisplayTree(AATree<int, string>.Node node, string intend)
        {
            Console.WriteLine(intend + node.Key + " (level:" + node.Level + ")");
            if (node.Left.Level != 0)
            {
                DisplayTree(node.Left, intend + "  ");
            }
            if (node.Right.Level != 0)
            {
                DisplayTree(node.Right, intend + "  ");
            }
        }
    }
}