namespace LongestPathInATree
{
	using LongestPathInTree;
	using System;
	using System.Linq;

	class LongestPathInATree
	{
		static void Main()
		{
			var something = Console.ReadLine();

			var inputs = int.Parse(Console.ReadLine());

			for (int i = 0; i < inputs; i++)
			{
				var inputArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

				var parrent = int.Parse(inputArgs[0]);
				var child = int.Parse(inputArgs[1]);

				var parrentTree = !Tree<int>.TreeExist(parrent) ?
					new Tree<int>(parrent) :
					Tree<int>.GetTreeByValue(parrent);


				var childTree = !Tree<int>.TreeExist(child) ?
					new Tree<int>(child, Tree<int>.GetTreeByValue(parrent)) :
					Tree<int>.GetTreeByValue(child);

				parrentTree.AddChild(childTree);
			}

			var root = Tree<int>.FindRoot();

			var result = root.Value;
			foreach (var child in root.Children)
			{
				result += DFS(child, 0);
			}

			Console.WriteLine(result);

		}

		private static int DFS(Tree<int> tree, int bestSum)
		{
			if (tree.Children.Count() == 0)
			{
				return tree.Value;
			}

			var betterValue = int.MinValue;
			foreach (var child in tree.Children)
			{
				var currentValue = DFS(child, bestSum);
				if (betterValue < currentValue)
				{
					Console.WriteLine(child.Value);
					betterValue = currentValue;
				}
			}

			bestSum += betterValue;
			return bestSum;
		}
	}
}
