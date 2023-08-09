namespace Hristo.DataStructures
{
    public class MyLeaf<T>
    {
        public T? Value { get; }
        public MyTreeNode<T>? Parent { get; set; }

        public MyLeaf(T? value)
        {
            Value = value;
        }
    }

    public class MyTreeNode<T> : MyLeaf<T>
    {
        private List<MyLeaf<T>> children;

        public MyTreeNode(T value) : base(value)
        {
            children = new List<MyLeaf<T>>();
        }

        public void Add(MyTreeNode<T> leaf)
        {
            if (leaf.Parent != null)
            {
                throw new Exception("The leaf is already attached to a parent node.");
            }

            leaf.Parent = this;
            children.Add(leaf);
        }

        public void Remove(MyTreeNode<T> leaf)
        {
            if (children.Contains(leaf))
            {
                leaf.Parent = null;
                children.Remove(leaf);
            }
        }

        public bool Contains(T value)
        {
            if (Value != null && Value.Equals(value))
            {
                return true;
            }

            foreach (var child in children)
            {
                if (child is MyTreeNode<T> treeNode && treeNode.Contains(value))
                {
                    return true;
                }
            }

            return false;
        }

        public MyLeaf<T>? Find(T value)
        {
            if (Value != null && Value.Equals(value))
            {
                return this;
            }

            foreach (var child in children)
            {
                if (child is MyTreeNode<T> treeNode)
                {
                    var foundNode = treeNode.Find(value);
                    if (foundNode != null)
                    {
                        return foundNode;
                    }
                }
            }

            return null;
        }

        public IReadOnlyList<MyLeaf<T>> Children { get { return children; } }
    }
}
