using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiAndStructures.DataStructures.LinkedList
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
