namespace _02.RoundDance
{
    public class Tree
    {
        private readonly TreeNode root;

        public Tree(TreeNode root)
        {
            this.root = root;
        }

        public TreeNode GetRoot()
        {
            return this.root;
        }

        public TreeNode FindNodeByValue(int value)
        {
            TreeNode node = this.GetRoot();
            if (node.Value == value)
            {
                return node;
            }
            else
            {
                return TraverseTree(node, value);
            }
        }

        private static TreeNode TraverseTree(TreeNode node, int value)
        {
            foreach (TreeNode friend in node.Friends)
            {
                if (friend == null)
                {
                    continue;
                }
                
                if (friend.Value == value)
                {
                    return friend;
                }
                else if(friend.Friends.Count > 1)
                {
                    TraverseTree(friend, value);
                }
            }

            return null;
        }

        public bool Contains(TreeNode node)
        {
            if (this.root.Value == node.Value)
            {
                return true;
            }
            else
            {
                foreach (TreeNode friend in this.root.Friends)
                {
                    if (friend.Value == node.Value)
                    {
                        return true;
                    }
                    else
                    {
                        Contains(friend);
                    }
                }
            }

            return false;
        }
    }
}
