using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SortingAlgorithms.Models;

namespace SortingAlgorithms.Algorithms
{
    public static class BubbleSort
    {
        public static SortResult Run(int[] input)
        {
            // This ensures each algorithm gets the exact same starting data.
            int[] arr = (int[])input.Clone();

            // This helps measure and compare algorithm efficiency.
            long comps = 0;

            // Stopwatch is used to measure the actual runtime in milliseconds.
            Stopwatch sw = Stopwatch.StartNew();

            int n = arr.Length;

            // Outer loop reduces the range each pass because the largest values
            // "bubble up" to the end of the array after each repeat.
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false; // Used to see if the list is already sorted.

                // Inner loop compares each pair of elements.
                for (int j = 0; j < n - 1 - i; j++)
                {
                    comps++; // Count every comparison for performance analysis.

                    // If the elements are out of order, swap them.
                    // This is the core operation that defines Bubble Sort.
                    if (arr[j] > arr[j + 1])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                        swapped = true;
                    }
                }

                // if no swaps occurred, the list is already sorted.
                // This reduces best-case time complexity to O(n).
                if (!swapped) break;
            }

            sw.Stop();

            // Return a detailed result object containing: name of algorithm, description,
            // Big-O notation, pseudocode, timing information, comparison count, sorted output data
            return new SortResult
            {
                Name = "Bubble Sort",
                Description = "Repeatedly swaps adjacent elements that are out of order; simple but inefficient.",
                BestCase = "O(n) (already sorted, optimized bubble)",
                WorstCase = "O(n^2)",
                Pseudocode = @"for i from 0 to n-2
    for j from 0 to n-2-i
        if arr[j] > arr[j+1]
            swap",

                DurationMs = sw.Elapsed.TotalMilliseconds,
                Comparisons = comps,
                SortedData = arr
            };
        }
    }
}
