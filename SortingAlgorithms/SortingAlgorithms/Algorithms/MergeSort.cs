using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SortingAlgorithms.Models;

namespace SortingAlgorithms.Algorithms
{
    public static class MergeSort
    {
        public static SortResult Run(int[] input)
        {
            int[] arr = (int[])input.Clone();    
            long comps = 0;                     
            Stopwatch sw = Stopwatch.StartNew(); // start timing

            MergeSortInternal(arr, 0, arr.Length - 1, ref comps); // start merge sort

            sw.Stop();                            
            return new SortResult
            {
                Name = "Merge Sort",
                Description = "Divide-and-conquer: split array, sort halves, and merge them.",
                BestCase = "O(n log n)",
                WorstCase = "O(n log n)",
                Pseudocode = @"mergeSort(A, lo, hi) if lo < hi mid = (lo+hi)/2 mergeSort(A, lo, mid) mergeSort(A, mid+1, hi) merge(A, lo, mid, hi)",
                DurationMs = sw.Elapsed.TotalMilliseconds,
                Comparisons = comps,
                SortedData = arr // return sorted results
            };
        }

        private static void MergeSortInternal(int[] a, int lo, int hi, ref long comps)
        {
            if (lo >= hi) return; // stop when the section is size 1
            int mid = (lo + hi) / 2; // find the middle point
            MergeSortInternal(a, lo, mid, ref comps); // sort the left part
            MergeSortInternal(a, mid + 1, hi, ref comps); // sort the right part
            Merge(a, lo, mid, hi, ref comps); // merge the parts together
        }

        private static void Merge(int[] a, int lo, int mid, int hi, ref long comps)
        {
            int n1 = mid - lo + 1; // size of left part
            int n2 = hi - mid; // size of right part
            int[] L = new int[n1]; // left temporary array
            int[] R = new int[n2]; // right temporary array

            // copy values into temporary arrays
            for (int i = 0; i < n1; i++) L[i] = a[lo + i];
            for (int j = 0; j < n2; j++) R[j] = a[mid + 1 + j];

            int i1 = 0, j1 = 0, k = lo;// indexes for merge work

            // merge the two halves while comparing each step
            while (i1 < n1 && j1 < n2)
            {
                comps++;// count each comparison
                if (L[i1] <= R[j1]) a[k++] = L[i1++];
                else a[k++] = R[j1++];
            }

            // copy leftover values from left side
            while (i1 < n1) a[k++] = L[i1++];

            // copy leftover values from right side
            while (j1 < n2) a[k++] = R[j1++];
        }
    }
}
