using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_Problem1
{
    class Program
    {
        static int nodesNumber = 7;
        static int edgesNumber = 6;

        static List<int>[] graph = new List<int>[]
        {
        
        };

        static bool[] hasParent;

        static void DFS(int node)
        {
            foreach (int child in graph[node])
            {
                if (!hasParent[child])
                {
                    hasParent[child] = true;
                    DFS(child);
                }
            }
        }

        static List<int>[] ReadGraph()
        {
            nodesNumber = int.Parse(Console.ReadLine());
            edgesNumber = int.Parse(Console.ReadLine());

            var graph = new List<int>[nodesNumber];

            for (int i = 0; i < nodesNumber; i++)
            {
                graph[i] = new List<int> { };
            }

                for (int i = 0; i < edgesNumber; i++)
            {
                var nodes = Console.ReadLine().Split(' ');
                
                int currentNode = int.Parse(nodes[0]);
                int nextNode = int.Parse(nodes[1]);

                graph[currentNode].Add(nextNode);
                
            }
                return graph;
        }

        public static void Main()
        {
            graph = ReadGraph();
            hasParent = new bool[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                DFS(i);
            }

            int countParents = 0;
            int root = -1;
            for(int i = 0; i < graph.Length; i++)
            {
                if(!hasParent[i])
                {
                    countParents++;
                    if (countParents > 1)
                    {
                        
                        root = -1;
                        break;
                    }
                    root = i;
                }
            }


            if(countParents == 0)
            {
                Console.WriteLine("No root!");
            }
            else if (countParents > 0)
            {
                Console.WriteLine("Multiple roots!");
            }

            else
            {
                Console.WriteLine(root);
            }
            Console.WriteLine();
        }
    }
}
