namespace _01FindTheRoot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
            }

            for (int i = 0; i < m; i++)
            {
                int[] edge =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                graph[edge[0]].Add(edge[1]);
            }

            var children = new HashSet<int>();
            for (int i = 0; i < graph.Count; i++)
            {
                for (int j = 0; j < graph[i].Count; j++)
                {
                    children.Add(graph[i][j]);
                }
            }

            List<int> nodes = new List<int>();
            for (int i = 0; i < n; i++)
            {
                nodes.Add(i);
            }

            for (int i = 0; i < n; i++)
            {
                if (children.Contains(i))
                {
                    nodes.Remove(i);
                }
            }

            if (nodes.Count == 0)
            {
                Console.WriteLine("No root!");
            }
            else if (nodes.Count == 1)
            {
                Console.WriteLine("{0}", string.Join("", nodes[0]));
            }
            else
            {
                Console.WriteLine("Multiple roots!");
            }
        }
    }
}
