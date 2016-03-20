namespace LongestPathInTree
{
	using System.Collections.Generic;
	using System.IO;

	public class Tree<T>
	{
		private static readonly Dictionary<T, Tree<T>> trees = new Dictionary<T, Tree<T>>();

		private readonly IList<Tree<T>> children;

		public Tree(T value, Tree<T> parrent = null)
		{
			this.Value = value;
			this.Parrent = parrent;
			this.children = new List<Tree<T>>();

			trees[this.Value] = this;
		}

		public T Value { get; set; }

		public IEnumerable<Tree<T>> Children
		{
			get
			{
				return this.children;
			}
		}

		public Tree<T> Parrent { get; private set; }

		public void AddChild(Tree<T> element)
		{
			this.children.Add(element);
		}

		public static Tree<T> GetTreeByValue(T value)
		{
			return trees[value];
		}

		public static bool TreeExist(T element)
		{
			return trees.ContainsKey(element);
		}

		public static Tree<T> FindRoot()
		{
			foreach (var pair in trees)
			{
				if (pair.Value.Parrent == null)
				{
					return pair.Value;
				}
			}

			throw new InvalidDataException("This is not a tree structure!");
		}
	}
}