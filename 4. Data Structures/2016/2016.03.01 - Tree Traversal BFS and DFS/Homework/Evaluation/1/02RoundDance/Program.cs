namespace _02RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static List<int> visited = new List<int>();
        static int counter = 1;
        static int bestCounter = 0;
        static void Main()
        {
            var graph = new Dictionary<int, List<int>>();
            int f = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            for (int i = 0; i < f; i++)
            {
                int[] edge = new int[2];
                edge =
                    Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                if (!graph.ContainsKey(edge[0]))
                {
                    graph[edge[0]] = new List<int>();
                }

                graph[edge[0]].Add(edge[1]);

                if (!graph.ContainsKey(edge[1]))
                {
                    graph[edge[1]] = new List<int>();
                }

                graph[edge[1]].Add(edge[0]);
            }

            var currentNode = k;
            int count = FindLongestDance(graph, k);
            Console.WriteLine(count);
        }

        private static int FindLongestDance(Dictionary<int, List<int>> graph, int k)
        {
            int current = k;
            visited.Add(current);
            var children = graph[current];
            
            foreach (var child in children)
            {
                if (!visited.Contains(child))
                {
                    counter++;
                    FindLongestDance(graph, child);
                }
            }

            if (bestCounter < counter)
            {
                bestCounter = counter;
                counter = 0;
            }

            return bestCounter;
        }
    }
}
