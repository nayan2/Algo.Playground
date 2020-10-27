using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Basic.BST
{
    // MyBst test = new MyBst();
    // test.Insert(7);
    // test.Insert(7);
    // test.Insert(4);
    // test.Insert(9);
    // test.Insert(1);
    // test.Insert(6);
    // test.Insert(8);
    // test.Insert(10);
    // test.Insert(0);
    // test.Insert(2);
    // test.Insert(5);
    // test.Insert(10);

    // bool result = test.Find(1);
    // Console.WriteLine(test.TraversePreOrder());
    // Console.WriteLine(test.TraverseInOrder());
    // Console.WriteLine(test.TraversePostOrder());
    // var height = test.Height();
    // var min = test.MinInATree();
    // var isTreeEqual = test.IsEqual(null);
    // var isBst = test.IsBst();
    // test.PrintKthNode(1);
    // test.PrintBreadthFirstSearchOrder();
    public class MyBst
    {
        private Node _root;
        
        private class Node
        {
            public Node Left { get; set; }
            public int Value { get; set; }
            public Node Right { get; set; }

            public Node(int value) => Value = value;
        }

        public void Insert(int value)
        { 
            var node = new Node(value);
            
            if (this._root == null)
                this._root = node;
            else
            {
                var currentNode = this._root;
                while (true)
                {
                    if (value < currentNode.Value && currentNode.Left == null)
                    {
                        currentNode.Left = node;
                        break;
                    }
                    else if (value < currentNode.Value && currentNode.Left != null)
                        currentNode = currentNode.Left;
                    else if (value > currentNode.Value && currentNode.Right == null)
                    {
                        currentNode.Right = node;
                        break;
                    }
                    else if (value > currentNode.Value && currentNode.Right != null)
                        currentNode = currentNode.Right;
                    else
                        break;
                }
            }
        } 

        public bool Find(int value)
        {
            return this.Find(value, this._root);
        }

        private bool Find(int value, Node node)
        {
            if (node.Left == node.Right)
                return node.Value == value;
            return node.Value == value || this.Find(value, value < node.Value ? node.Left : node.Right);
        }

        public string TraversePreOrder()
        {
            return this.ToPreOrder(this._root);
        }
        
        public string TraverseInOrder()
        {
            return this.ToInOrder(this._root);
        }
        
        public string TraversePostOrder()
        {
            return this.ToPostOrder(this._root);
        }

        public int Height()
        {
            return this.GetHeight(this._root);
        }

        public int Min()
        {
            if(this._root == null)
                throw new InvalidOperationException("BST is Empty!");
            
            return this.Min(this._root);
        }

        public int MinInATree()
        {
            return this.MinInATree(this._root);
        }

        public bool IsEqual(MyBst other)
        {
            if(other == null || this._root == other._root)
                throw  new ArgumentException("Tree can't be null or empty!", $"{nameof(other)}");
            
            return this.IsEqual(this._root, other._root);
        }

        //O(n)
        public bool IsBst()
        {
            return this.IsBst(this._root, int.MinValue, int.MaxValue);
        }

        public void PrintKthNode(int level)
        {
            this.PrintKthNode(this._root, level);
        }

        public void PrintBreadthFirstSearchOrder()
        {
            for (int i = 0; i <= this.Height(); i++)
            {
                this.PrintKthNode(i);
            }
        }

        private bool IsEqual(Node left, Node right)
        {
            if (left == right)
                return true;
            if (left == null || right == null)
                return false;

            return left.Value == right.Value
                   && this.IsEqual(left.Left, right.Left)
                   && this.IsEqual(left.Right, right.Right);
        }
        
        private string ToPreOrder(Node node)
        {
            string nodeValues = string.Empty;
            nodeValues += node.Value;
            if(node.Left != null)
                nodeValues += " " + ToPreOrder(node.Left);
            if(node.Right != null)
                nodeValues += " " + ToPreOrder(node.Right);
            return nodeValues; 
        }
        
        private string ToInOrder(Node node)
        {
            if (node == null) return string.Empty;
            
            string nodeValues = string.Empty;
            nodeValues += " " + ToPreOrder(node.Left);
            nodeValues += node.Value;
            nodeValues += " " + ToPreOrder(node.Right);
            return nodeValues; 
        }
        
        private string ToPostOrder(Node node)
        {
            if (node == null) return string.Empty;
            
            string nodeValues = string.Empty;
            nodeValues += " " + ToPreOrder(node.Left);
            nodeValues += " " + ToPreOrder(node.Right);
            nodeValues += node.Value;
            return nodeValues; 
        }

        private int GetHeight(Node node)
        {
            if (node == null||node.Left == node.Right)
                return 0;
            return 1 + Math.Max(this.GetHeight(node.Left), this.GetHeight(node.Right));
        }

        // O(log n)
        private int Min(Node root)
        {
            return root.Left == null ? root.Value : this.Min(root.Left);
        }

        // O(n)
        private int MinInATree(Node root)
        {
            if (this.IsLeafNode(root))
                return root.Value;
            
            var left = root.Left != null ? this.MinInATree(root.Left) : 0;
            var right = root.Right != null ? this.MinInATree(root.Right) : 0;
            return Math.Min(root.Value, Math.Min(left, right));
        }

        private bool IsLeafNode(Node node)
        {
            return node.Left == node.Right;
        }

        private bool IsBst(Node root, int from, int to)
        {
            if (root == null)
                return true;
            
            return from < root.Value && root.Value < to
                                     && this.IsBst(root.Left, from, root.Value)
                                     && this.IsBst(root.Right, root.Value, to);
        }

        private void PrintKthNode(Node root, int requiredLevel)
        {
            if (root == null)
                return;

            if (requiredLevel == 0)
            {
                Console.Write("{0} ", root.Value);
                return;
            }
            
            this.PrintKthNode(root.Left, requiredLevel - 1);
            this.PrintKthNode(root.Right, requiredLevel - 1);
        }
    }
}