namespace RoundDance
{
	using System;
	using System.Collections.Generic;

	class RoundDance
	{
		static int bestCount = 0;
		static Dictionary<int, List<int>> dancers = new Dictionary<int, List<int>>();
		static Dictionary<int, bool> visited = new Dictionary<int, bool>();
		static void Main()
		{
			var numberOfInputs = int.Parse(Console.ReadLine());
			var startIndex = int.Parse(Console.ReadLine());

			for (int i = 0; i < numberOfInputs; i++)
			{
				var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				var parent = int.Parse(input[0]);
				var child = int.Parse(input[1]);

				if (!dancers.ContainsKey(parent))
				{
					dancers[parent] = new List<int>();
					visited[parent] = false;
				}

				if (!dancers.ContainsKey(child))
				{
					dancers[child] = new List<int>();
					visited[child] = false;
				}

				dancers[parent].Add(child);
				dancers[child].Add(parent);
			}

			DFS(startIndex, 0);
			Console.WriteLine(bestCount);
		}

		static void DFS(int index, int count)
		{
			if (!visited[index])
			{
				visited[index] = true;
				foreach (var i in dancers[index])
				{
					DFS(i, count + 1);
				}
			}

			bestCount = bestCount < count ? count : bestCount;
		}
	}
}
