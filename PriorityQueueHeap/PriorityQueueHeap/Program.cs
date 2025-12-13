using System;

namespace PriorityQueueHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test MaxPQArray
            MaxPQArray arrayPQ = new MaxPQArray();
            arrayPQ.Insert(10);
            arrayPQ.Insert(4);
            arrayPQ.Insert(25);
            arrayPQ.Insert(8);

            Console.WriteLine("MaxPQArray:");
            Console.WriteLine(arrayPQ.RemoveMax()); // 25
            Console.WriteLine(arrayPQ.RemoveMax()); // 10

            Console.WriteLine();

            // Test MaxPQTree
            MaxPQTree treePQ = new MaxPQTree();
            treePQ.Insert(15);
            treePQ.Insert(30);
            treePQ.Insert(5);
            treePQ.Insert(20);

            Console.WriteLine("MaxPQTree:");
            Console.WriteLine(treePQ.RemoveMax()); // 30
            Console.WriteLine(treePQ.RemoveMax()); // 20
        }
    }
}
