namespace FindTheRoot
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	class FindTheRoot
	{
		static void Main()
		{
			var numberOfNodes = int.Parse(Console.ReadLine());
			var numberOfEdges = int.Parse(Console.ReadLine());

			var hasParent = new bool[numberOfNodes];
			for (int i = 0; i < numberOfEdges; i++)
			{
				var nums = Console.ReadLine()
					.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();
				hasParent[nums[1]] = true;
			}
			var roots = new List<int>();
			for (int i = 0; i < hasParent.Length; i++)
			{
				if (!hasParent[i])
				{
					roots.Add(i);
				}
			}

			if (roots.Count == 1)
			{
				Console.WriteLine(roots[0]);
			}
			else if (roots.Count > 1)
			{
				Console.WriteLine("Multiple root nodes!");
			}
			else
			{
				Console.WriteLine("No root!");
			}
		}
	}
}
