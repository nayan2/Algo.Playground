using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Basic.BST
{
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
                    if (value > currentNode.Value && currentNode.Right != null)
                        currentNode = currentNode.Right;
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

        public bool IsEqual(MyBst left, MyBst right)
        {
            if(left == right)
                throw  new ArgumentException("Both tree can't be null!", $"{nameof(left)}, {nameof(right)}");
            return this.IsEqual(left._root, right._root);
        }

        private bool IsEqual(Node left, Node right)
        {
            if (left == right)
                return true;
            var isValueEqual = left.Value == right.Value;
            var isLeftEqual = this.IsEqual(left.Left, right.Left);
            var isRightEqual = this.IsEqual(left.Right, right.Right);
            return isLeftEqual && isRightEqual && isValueEqual;
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
    }
}