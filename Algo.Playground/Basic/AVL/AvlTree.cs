using System;

namespace Basic.AVL
{
    // var avl = new AvlTree();
    // avl.Insert(10);
    // avl.Insert(14);
    // avl.Insert(16);
    // avl.Insert(15);
    public class AvlTree
    {
        private Node _root;
        
        private class Node
        {
            public Node Left { get; set; }
            public int Value { get; }
            public Node Right { get; set; } 
            public int Height { get; set; }
            public int BalanceFactor { get; set; }
            
            public Node(int value) =>
                (this.Value, this.Height) = (value, 0);

            public override string ToString()
            {
                return "Value = " + this.Value;
            }
        }

        public void Insert(int data)
        {
            if (data == default)
                throw new ArgumentException("Invalid data", nameof(data));
            
            this._root = this.Insert(this._root, data);
        }

        private Node Insert(Node root, int data)
        {
            if (root == null)
                return new Node(data);

            if(root.Value == data)
                return root;
            
            if (data < root.Value)
                root.Left = this.Insert(root.Left, data);
            else
                root.Right = this.Insert(root.Right, data);

            root.Height = this.NodeHeight(root);
            root.BalanceFactor = this.BalanceFactor(root);
            root = this.BalanceTree(root);
            
            return root;
        }

        private Node BalanceTree(Node root)
        {
            if (this.IsLeftHeavy(root))
            {
                if (root.Left?.BalanceFactor < 0)
                    root.Left = this.LeftRotate(root.Left);
                return this.RightRotate(root);
            }
            else if (this.IsRightHeavy(root))
            {
                if (root.Right?.BalanceFactor > 0)
                    root.Right = this.RightRotate(root.Right);
                return this.LeftRotate(root);
            }
            return root;
        }

        private Node RightRotate(Node root)
        {
            var newRoot = root.Left;
            root.Left = newRoot.Right;
            newRoot.Right = root;
            newRoot.Height = this.NodeHeight(newRoot);
            newRoot.Right.Height = this.NodeHeight(newRoot.Right);
            return newRoot;
        }

        private Node LeftRotate(Node root)
        {
            var newRoot = root.Right;
            root.Right = newRoot.Left;
            newRoot.Left = root;
            newRoot.Height = this.NodeHeight(newRoot);
            newRoot.Left.Height = this.NodeHeight(newRoot.Left);
            return newRoot;
        }

        private int NodeHeight(Node node)
        {
            return Math.Max(node.Left?.Height ?? -1, node.Right?.Height ?? -1) + 1;
        }

        private int BalanceFactor(Node node)
        {
            return (node.Left?.Height ?? -1) - (node.Right?.Height ?? -1);
        }

        private bool IsRightHeavy(Node node)
        {
            return (node.Left?.Height ?? -1) - (node.Right?.Height ?? -1) < -1;
        }

        private bool IsLeftHeavy(Node node)
        {
            return (node.Left?.Height ?? -1) - (node.Right?.Height ?? -1) > 1;
        }
    }
}