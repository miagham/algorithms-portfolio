using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SortingAlgorithms.Models;

namespace SortingAlgorithms.Algorithms
{
    public static class QuickSort
    {
        public static SortResult Run(int[] input)
        {
            int[] arr = (int[])input.Clone();
            long comps = 0;
            Stopwatch sw = Stopwatch.StartNew();

            QuickSortInternal(arr, 0, arr.Length - 1, ref comps); // start quicksort

            sw.Stop();
            return new SortResult
            {
                Name = "Quick Sort",
                Description = "Divide-and-conquer: partition array around a pivot and recursively sort partitions.",
                BestCase = "O(n log n)",
                WorstCase = "O(n^2) (bad pivot choices)",
                Pseudocode = @"quickSort(A, lo, hi) if lo < hi p = partition(A, lo, hi) quickSort(A, lo, p-1) quickSort(A, p+1, hi)",
                DurationMs = sw.Elapsed.TotalMilliseconds,
                Comparisons = comps,
                SortedData = arr
            };
        }

        private static void QuickSortInternal(int[] a, int lo, int hi, ref long comps)
        {
            if (lo >= hi) return;
            int p = Partition(a, lo, hi, ref comps); // split around pivot
            QuickSortInternal(a, lo, p - 1, ref comps); // sort left side
            QuickSortInternal(a, p + 1, hi, ref comps); // sort right side
        }

        private static int Partition(int[] a, int lo, int hi, ref long comps)
        {
            int pivot = a[hi]; // choose last element as pivot
            int i = lo - 1; // boundary for smaller elements

            for (int j = lo; j < hi; j++)
            {
                comps++; // count comparison
                if (a[j] <= pivot) // move smaller values to the left
                {
                    i++;
                    int tmp = a[i]; a[i] = a[j]; a[j] = tmp;
                }
            }
            // put pivot into final position
            int t = a[i + 1]; a[i + 1] = a[hi]; a[hi] = t;
            return i + 1; // return pivot index
        }
    }
}
