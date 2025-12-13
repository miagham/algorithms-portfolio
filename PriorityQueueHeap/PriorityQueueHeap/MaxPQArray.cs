using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueueHeap
{
    class MaxPQArray
    {
        private List<int> heap = new List<int>();

        public void Insert(int value)
        {
            heap.Add(value);
            Swim(heap.Count - 1);
        }

        public int RemoveMax()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Priority Queue is empty");

            int max = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            Sink(0);

            return max;
        }

        private void Swim(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;

                if (heap[index] <= heap[parent])
                    break;

                Swap(index, parent);
                index = parent;
            }
        }

        private void Sink(int index)
        {
            while (2 * index + 1 < heap.Count)
            {
                int left = 2 * index + 1;
                int right = left + 1;
                int largest = left;

                if (right < heap.Count && heap[right] > heap[left])
                    largest = right;

                if (heap[index] >= heap[largest])
                    break;

                Swap(index, largest);
                index = largest;
            }
        }

        private void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
