using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueHeap
{
    class TreeNode
    {
        public int Value;
        public TreeNode Parent;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value)
        {
            Value = value;
        }
    }
}
