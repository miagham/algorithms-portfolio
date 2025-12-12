using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SortingAlgorithms.Models;

namespace SortingAlgorithms.Algorithms
{
    public static class SelectionSort
    {
        public static SortResult Run(int[] input)
        {
            int[] arr = (int[])input.Clone(); // copy input so original stays unchanged
            long comps = 0;
            Stopwatch sw = Stopwatch.StartNew();

            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i; // track the index of the smallest value
                for (int j = i + 1; j < n; j++)
                {
                    comps++; // count comparison
                    if (arr[j] < arr[minIdx]) minIdx = j; // update smallest value found
                }

                if (minIdx != i) // only swap when a new minimum is found
                {
                    int tmp = arr[i];
                    arr[i] = arr[minIdx];
                    arr[minIdx] = tmp;
                }
            }

            sw.Stop();
            return new SortResult
            {
                Name = "Selection Sort",
                Description = "Selects the minimum element and places it at the front; simple, does minimal swaps.",
                BestCase = "O(n^2)",
                WorstCase = "O(n^2)",
                Pseudocode = @"for i from 0 to n-2 min = i for j from i+1 to n-1 if arr[j] < arr[min] min = j swap arr[i], arr[min]",
                DurationMs = sw.Elapsed.TotalMilliseconds,
                Comparisons = comps,
                SortedData = arr
            };
        }
    }
}
