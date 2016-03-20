namespace _01.FindTheRoot
{
    using System.Collections;
    using System.Collections.Generic;

    class BinaryTree : IEnumerable<BinaryTree>
    {
        private readonly Dictionary<int, BinaryTree> children =
                                            new Dictionary<int, BinaryTree>();

        public readonly int ID;
        public BinaryTree Parent { get; private set; }

        public BinaryTree(int id)
        {
            this.ID = id;
        }

        public BinaryTree GetChild(int id)
        {
            return this.children[id];
        }

        public void Add(BinaryTree item)
        {
            if (item.Parent != null)
            {
                item.Parent.children.Remove(item.ID);
            }

            item.Parent = this;
            this.children.Add(item.ID, item);
        }

        public IEnumerator<BinaryTree> GetEnumerator()
        {
            return this.children.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Count
        {
            get { return this.children.Count; }
        }
    }
}
