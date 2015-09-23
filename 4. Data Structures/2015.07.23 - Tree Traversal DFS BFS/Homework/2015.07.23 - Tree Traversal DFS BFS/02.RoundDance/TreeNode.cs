namespace _02.RoundDance
{
    using System.Collections.Generic;

    public class TreeNode
    {
        public int Value { get; set; }

        public HashSet<TreeNode> Friends { get; set; }

        public TreeNode(int value)
        {
            this.Value = value;
            this.Friends = new HashSet<TreeNode>();
        }

        public void AddFriend(TreeNode friend)
        {
            this.Friends.Add(friend);
            friend.Friends.Add(this);
        }

        public bool IsFriendOf(TreeNode check)
        {
            return this.Friends.Contains(check);
        }
    }
}
