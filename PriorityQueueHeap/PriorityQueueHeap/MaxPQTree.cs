using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PriorityQueueHeap
{
    class MaxPQTree
    {
        private TreeNode root;
        private List<TreeNode> nodes = new List<TreeNode>();

        // Insert a value into the priority queue
        public void Insert(int value)
        {
            TreeNode newNode = new TreeNode(value);
            nodes.Add(newNode);

            if (nodes.Count == 1)
            {
                root = newNode;
                return;
            }

            TreeNode parent = nodes[(nodes.Count - 2) / 2];
            newNode.Parent = parent;

            if (parent.Left == null)
                parent.Left = newNode;
            else
                parent.Right = newNode;

            Swim(newNode);
        }

        // Remove and return the maximum value
        public int RemoveMax()
        {
            if (root == null)
                throw new InvalidOperationException("Priority Queue is empty");

            int max = root.Value;
            TreeNode lastNode = nodes[nodes.Count - 1];

            root.Value = lastNode.Value;

            if (lastNode.Parent != null)
            {
                if (lastNode.Parent.Left == lastNode)
                    lastNode.Parent.Left = null;
                else
                    lastNode.Parent.Right = null;
            }

            nodes.RemoveAt(nodes.Count - 1);

            if (nodes.Count > 0)
                Sink(root);

            return max;
        }

        private void Swim(TreeNode node)
        {
            while (node.Parent != null && node.Value > node.Parent.Value)
            {
                int temp = node.Value;
                node.Value = node.Parent.Value;
                node.Parent.Value = temp;

                node = node.Parent;
            }
        }

        private void Sink(TreeNode node)
        {
            while (node.Left != null)
            {
                TreeNode largerChild = node.Left;

                if (node.Right != null && node.Right.Value > node.Left.Value)
                    largerChild = node.Right;

                if (node.Value >= largerChild.Value)
                    break;

                int temp = node.Value;
                node.Value = largerChild.Value;
                largerChild.Value = temp;

                node = largerChild;
            }
        }
    }
}
