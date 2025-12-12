using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeStructures.Models;

namespace TreeStructures.Trees
{
    // Binary Search Tree implementation
    public class BinarySearchTree
    {
        public TreeNode? Root { get; private set; }

        // Insert a value into the tree
        public void Insert(int value)
        {
            Root = InsertRecursive(Root, value);
        }
        private TreeNode InsertRecursive(TreeNode? node, int value)
        {
            // If we reach an empty spot, create a new node
            if (node == null)
                return new TreeNode(value);

            // Smaller values go left
            if (value < node.Value)
                node.Left = InsertRecursive(node.Left, value);

            // Larger or equal values go right
            else
                node.Right = InsertRecursive(node.Right, value);

            return node;
        }

        // In-order traversal prints values in sorted order
        public void InOrderTraversal(Action<int> visit)
        {
            InOrderRecursive(Root, visit);
        }
        private void InOrderRecursive(TreeNode? node, Action<int> visit)
        {
            if (node == null) return;
            InOrderRecursive(node.Left, visit);
            visit(node.Value);
            InOrderRecursive(node.Right, visit);
        }
    }
}
