namespace _02.RoundDance
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int numberOfFriends = int.Parse(Console.ReadLine());
            int leadDancer = int.Parse(Console.ReadLine());
            Tree dancers = new Tree(new TreeNode(leadDancer));

            // create tree of friends
            for (int i = 0; i < numberOfFriends; i++)
            {
                string[] friendship = Console.ReadLine().Split(' ');
                int firstPerson = int.Parse(friendship[0]);
                int secondPerson = int.Parse(friendship[1]);
                TreeNode firstPersonNode = dancers.FindNodeByValue(firstPerson);
                TreeNode secondPersonNode = dancers.FindNodeByValue(secondPerson);
                if (firstPersonNode == null)
                {
                    firstPersonNode = new TreeNode(firstPerson);
                }
                if (secondPersonNode != null)
                {
                    firstPersonNode.AddFriend(secondPersonNode);
                }
                else
                {
                    TreeNode presentSecondPerson = new TreeNode(secondPerson);
                    firstPersonNode.AddFriend(presentSecondPerson);
                }
            }

            int longestPath = BFS(dancers.GetRoot());
            Console.WriteLine(longestPath);
        }

        private static int BFS(TreeNode node)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            int longestPath = 0;
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue();
                foreach (TreeNode friend in currentNode.Friends)
                {
                    queue.Enqueue(friend);
                }

                longestPath++;
            }

            return longestPath;
        }
    }
}
