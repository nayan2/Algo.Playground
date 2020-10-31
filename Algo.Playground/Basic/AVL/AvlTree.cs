using System;

namespace Basic.AVL
{
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

            root.Height = Math.Max(root.Left?.Height ?? -1, root.Right?.Height ?? -1) + 1;
            root.BalanceFactor = this.BalanceFactor(root);
            
            if(this.LeftHeavy(root) && root.Left?.BalanceFactor >= 1)
                Console.WriteLine("Left heavy tree and need a right rotation on " + root.Value);
            else if(this.LeftHeavy(root) && root.Left?.BalanceFactor <= -1)
                Console.WriteLine("Left heavy and need to perform a left right rotation, left rotation on " + root.Left?.Value + "and right rotation on " + root.Value);
            else if(this.RightHeave(root) && root.Right?.BalanceFactor <= -1)
                Console.WriteLine("Right heavy tree and need a left rotation on " + root.Value);
            else if(this.RightHeave(root) && root.Right?.BalanceFactor >= 1)
                Console.WriteLine("Right heavy tree and need a right left rotation, right rotation on " + root.Right?.Value + "and left rotation on " + root.Value);
            
            return root;
        }

        private int BalanceFactor(Node node)
        {
            return (node.Left?.Height ?? -1) - (node.Right?.Height ?? -1);
        }

        private bool RightHeave(Node node)
        {
            return (node.Left?.Height ?? -1) - (node.Right?.Height ?? -1) < -1;
        }

        private bool LeftHeavy(Node node)
        {
            return (node.Left?.Height ?? -1) - (node.Right?.Height ?? -1) > 1;
        }
    }
}