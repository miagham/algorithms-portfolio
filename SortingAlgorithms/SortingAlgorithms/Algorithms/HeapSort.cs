using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SortingAlgorithms.Models;

namespace SortingAlgorithms.Algorithms
{
    public static class HeapSort
    {
        public static SortResult Run(int[] input)
        {
            // Make a copy of the input so the original list isn’t changed.
            int[] arr = (int[])input.Clone();
            long comps = 0;

            // Start the timer to measure how long heap sort takes.
            Stopwatch sw = Stopwatch.StartNew();

            int n = arr.Length;

            // Build the max heap by heapifying from the bottom up.
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i, ref comps);

            // Extract the largest element and rebuild the heap each time.
            for (int i = n - 1; i > 0; i--)
            {
                int tmp = arr[0];
                arr[0] = arr[i];
                arr[i] = tmp;

                //heapify: process of rearranging elements in an array
                Heapify(arr, i, 0, ref comps);
            }

            sw.Stop();

            return new SortResult
            {
                Name = "Heap Sort",
                Description = "Transforms the array into a heap and repeatedly extracts the max to build sorted array.",
                BestCase = "O(n log n)",
                WorstCase = "O(n log n)",
                Pseudocode = @"build-max-heap(A) for i = n-1 downto 1 swap A[0], A[i] heapify(A, 0, i)",
                DurationMs = sw.Elapsed.TotalMilliseconds,
                Comparisons = comps,
                SortedData = arr
            };
        }

        private static void Heapify(int[] arr, int size, int root, ref long comps)
        {
            // Assume the root is the largest value.
            int largest = root;
            int l = 2 * root + 1;
            int r = 2 * root + 2;

            // Check left spot and update largest if needed.
            if (l < size) { comps++; if (arr[l] > arr[largest]) largest = l; }

            // Check right spot and update largest if needed.
            if (r < size) { comps++; if (arr[r] > arr[largest]) largest = r; }

            // If the largest value isn’t the root, swap them and continue heapifying.
            if (largest != root)
            {
                int swap = arr[root];
                arr[root] = arr[largest];
                arr[largest] = swap;

                // restore heap structure.
                Heapify(arr, size, largest, ref comps);
            }
        }
    }
}
