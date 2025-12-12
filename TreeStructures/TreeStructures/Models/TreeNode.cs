using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeStructures.Models
{
    // Represents a single node in the binary search tree
    public class TreeNode
    {
        public int Value { get; set; }

        // Left spot holds smaller values
        public TreeNode Left { get; set; }

        // Right spot holds larger values
        public TreeNode Right { get; set; }

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
}

