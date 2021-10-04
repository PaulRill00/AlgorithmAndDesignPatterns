using System;

namespace AD
{
    public partial class BinarySearchTree<T> : BinaryTree<T>, IBinarySearchTree<T>
        where T : System.IComparable<T>
    {
        public void Insert(T x)
        {
            this.root = TreeInsert(this.root, x);
        }

        private BinaryNode<T> TreeInsert(BinaryNode<T> node, T data)
        {
            if (node == null)
                return new BinaryNode<T>(data);

            if (IsLeftChild(node, data))
            {
                node.left = TreeInsert(node.left, data);
            }
            else
            {
                node.right = TreeInsert(node.right, data);
            }

            return node;
        }

        public T FindMin()
        {
            var minNode = FindMinNode();
            return minNode.data;
        }

        private BinaryNode<T> FindMinNode(BinaryNode<T> root = null)
        {
            if (this.IsEmpty())
            {
                throw new BinarySearchTreeEmptyException();
            }

            BinaryNode<T> parent = null;
            var next = root ?? this.root;

            while (next != null)
            {
                parent = next;
                next = next.left;
            }

            return parent;
        }

        private BinaryNode<T> FindParent(BinaryNode<T> node)
        {
            BinaryNode<T> parent = null;
            var next = this.root;

            while (next != null)
            {
                if (next.data.Equals(node.data)) break;

                parent = next;

                next = (IsLeftChild(next, node.data)) ? next.left : next.right;
            }

            return parent;
        }

        public void RemoveMin()
        {
            var min = FindMin();
            Remove(min);
        }

        public void Remove(T x)
        {
            if (this.IsEmpty())
            {
                throw new BinarySearchTreeEmptyException();
            }

            BinaryNode<T> parent = null;
            var next = this.root;

            while (next != null)
            {
                if (next.data.Equals(x))
                {

                    break;
                }

                var temp = IsLeftChild(next, x) ? next.left : next.right;
                if (temp == null) break;

                parent = next;
                next = temp;
            }

            if (parent == null)
            {
                this.root = null;
                return;
            }

            BinaryNode<T> newNode = null;

            if (next.right != null)
            {
                newNode = FindMinNode(next.right);
                var newNodeParent = FindParent(newNode);

                if (!next.data.Equals(newNodeParent.data))
                {
                    newNodeParent.left = newNode.right;
                }
                newNode.left = next.left;

                if (!newNode.data.Equals(next.right.data))
                    newNode.right = next.right;
            }
            else if (next.left != null)
            {
                newNode = next.left;
            }

            if (IsLeftChild(parent, x))
            {
                parent.left = newNode;
            }
            else
            {
                parent.right = newNode;
            }

        }

        public string InOrder()
        {
            return this.ToInfixString().Replace("[ ", "").Replace(" ]", "").Replace("NIL ", "").Replace(" NIL", "");
        }

        public override string ToString()
        {
            return IsEmpty() ? "" : this.InOrder();
        }

        private BinaryNode<T> Find(T x)
        {
            BinaryNode<T> parent = null;
            var next = this.root;

            while (next != null)
            {
                parent = next;

                if (next.data.Equals(x))
                {
                    break;
                }

                next = IsLeftChild(next, x) ? next.left : next.right;
            }

            return parent;
        }

        private bool IsLeftChild(BinaryNode<T> node, T x)
        {
            return x.CompareTo(node.data) < 0;
        }
    }
}
