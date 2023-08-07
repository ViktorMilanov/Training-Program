using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.DataStructures
{
    public class Leaf<T>
    {
        public T? Value { get; }
        protected TreeNode<T>? Parent { get; set; }
        public Leaf(T? v)
        {
            Value = v;
        }
    }
    public class TreeNode<T> : Leaf<T>
    {
        private List<Leaf<T>> children;



        public TreeNode(T value) : base(value)
        {
            children = new List<Leaf<T>>();
        }



        public void Add(TreeNode<T> leaf)
        {
            if (leaf.Parent != null)
            {
                throw new InvalidOperationException("The leaf is already attached to a parent node.");
            }
            leaf.Parent = this;
            children.Add(leaf);
        }
        public void Remove(TreeNode<T> leaf)
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
                if (child.Value.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }
        public Leaf<T> Find(T value)
        {
            if (Value != null && Value.Equals(value))
            {
                return this;
            }
            foreach (var child in children)
            {
                if (child.Value.Equals(value))
                {
                    return child;
                }
            }

            return null;
        }
    }
    /*public class CustomNonBinaryTree<T>
    {
        public int Count { get; private set; }
        private TreeNode<T> root;
        public CustomNonBinaryTree()
        {
            root = null;
        }
        public void AddRoot(T value)
        {
            if (root == null)
            {
                root = new TreeNode<T>(value);
                Count++;
            }
            else
            {
                throw new InvalidOperationException("There is root node already in the tree.");
            }
        }

        public void AddChild(TreeNode<T> parent, T value)
        {
            if (parent == null)
            {
                throw new ArgumentNullException(nameof(parent));
            }
            if (parent.firstChild == null)
            {
                parent.firstChild = new TreeNode<T>(value);
            }
            else
            {
                var currentSibling = parent.firstChild;
                while (currentSibling.nextSibling != null)
                {
                    currentSibling = currentSibling.nextSibling;
                }
                currentSibling.nextSibling = new TreeNode<T>(value);
            }
            Count++;
        }
        public void RemoveElement(T value)
        {
            if (root.value.Equals(value))
            {
                root = null;
                Count = 0;
                return;
            }
            var currentChild
            if (root.firstChild.value.Equals(value))
            {
                root.firstChild = root.firstChild.nextSibling;
                Count--;
                return;
            }

        }
            
    }*/
}
