using System;
using System.Collections.Generic;
using System.Linq;

namespace p2.RoundDance
{
    class Program
    {
        private static Dictionary<int, Node> everybody = new Dictionary<int, Node>();

        static void Main()
        {
            int friendships = int.Parse(Console.ReadLine());
            int leader = int.Parse(Console.ReadLine());
            for (int i = 0; i < friendships; i++)
            {
                int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int firstNodeVal = parameters[0];
                int secondNodeVal = parameters[1];
                Node firstNode = everybody.ContainsKey(firstNodeVal) ? everybody[firstNodeVal] : new Node(firstNodeVal);
                Node secondNode = everybody.ContainsKey(secondNodeVal) ? everybody[secondNodeVal] : new Node(secondNodeVal);
                firstNode.Friends.Add(secondNode);
                secondNode.Friends.Add(firstNode);
                if(!everybody.ContainsKey(firstNodeVal))
                {
                    everybody.Add(firstNodeVal, firstNode);
                }

                if(!everybody.ContainsKey(secondNodeVal))
                {
                    everybody.Add(secondNodeVal, secondNode);
                }
            }

            Node start = everybody[leader];
            DFS(start);
            Console.WriteLine("Longest dance: " + maxLength);
        }

        private static int maxLength = 1;
        private static int currentLength = 1;
        private static Dictionary<Node, bool> visited = new Dictionary<Node, bool>();
        static void DFS(Node person)
        {
            if(!visited.ContainsKey(person))
            {
                visited.Add(person, false);
            }

            visited[person] = true;
            foreach (Node friend in person.Friends)
            {
                if(!visited.ContainsKey(friend))
                {
                    visited.Add(friend, false);
                }

                if(!visited[friend])
                {
                    currentLength++;
                    DFS(friend);
                }
            }

            maxLength = maxLength < currentLength ? currentLength : maxLength;
            currentLength = 1;
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public IList<Node> Friends { get; set; }

        public Node(int value, Node friend = null)
        {
            this.Value = value;
            this.Friends = new List<Node>();
            if (friend != null)
            {
                this.Friends.Add(friend);
            }
        }
    }
}
