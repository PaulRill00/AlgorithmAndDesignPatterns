using System;

namespace AD
{
    public partial class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryNode<T> root;

        //----------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------

        public BinaryTree()
        {
        }

        public BinaryTree(T rootItem)
        {
            this.root = new BinaryNode<T>() { data = rootItem };
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public BinaryNode<T> GetRoot()
        {
            return root;
        }

        public int Size()
        {
            var size = 0;

            this.Traverse(this.root, (node, depth) => size++);

            return size;
        }

        public int Height()
        {
            if (this.IsEmpty()) return -1;

            var highest = 0;

            this.Traverse(this.root, (node, depth) =>
            {
                if (depth > highest)
                {
                    highest = depth;
                }
            });

            return highest;
        }

        public void MakeEmpty()
        {
            this.root = null;
        }

        public bool IsEmpty()
        {
            return this.root == null;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {
            this.root = new BinaryNode<T> {data = rootItem, left = t1?.root, right = t2?.root};
        }

        public string ToPrefixString()
        {
            if (this.root == null) return "NIL";
            return this.root.ToPrefixString();
        }

        public string ToInfixString()
        {
            if (this.root == null) return "NIL";
            return this.root.ToInfixString();
        }

        public string ToPostfixString()
        {
            if (this.root == null) return "NIL";
            return this.root.ToPostfixString();
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public int NumberOfLeaves()
        {
            var leaveCount = 0;

            this.Traverse(this.root, (node, _) =>
            {
                if (node.left == null && node.right == null) leaveCount++;
            });

            return leaveCount;
        }

        public int NumberOfNodesWithOneChild()
        {
            var nodeCount = 0;

            this.Traverse(this.root, (node, _) =>
            {
                if (node.left == null ^ node.right == null) nodeCount++;
            });

            return nodeCount;
        }

        public int NumberOfNodesWithTwoChildren()
        {
            var nodeCount = 0;

            this.Traverse(this.root, (node, _) =>
            {
                if (node.left != null && node.right != null) nodeCount++;
            });

            return nodeCount;
        }

        private void Traverse(BinaryNode<T> root, Action<BinaryNode<T>, int> func, int depth = 0)
        {
            if (root == null) return;
            func(root, depth);

            Traverse(root.left, func, depth + 1);
            Traverse(root.right, func, depth + 1);
        }
    }
}