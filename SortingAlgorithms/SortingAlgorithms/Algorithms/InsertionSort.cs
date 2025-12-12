using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SortingAlgorithms.Models;

namespace SortingAlgorithms.Algorithms
{
    public static class InsertionSort
    {
        public static SortResult Run(int[] input)
        {
            int[] arr = (int[])input.Clone(); // make a copy so the original data stays untouched
            long comps = 0;
            Stopwatch sw = Stopwatch.StartNew(); // start timing the sort

            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];// the value we are inserting
                int j = i - 1; // start checking from the left side

                // move bigger values to the right until we find the correct spot
                while (j >= 0)
                {
                    comps++;
                    if (arr[j] > key)
                    {
                        arr[j + 1] = arr[j]; // shift the value to the right
                        j--;
                    }
                    else break; // stop if the correct spot is found
                }

                arr[j + 1] = key;// insert the value into the right position
            }

            sw.Stop();// stop timing

            return new SortResult
            {
                Name = "Insertion Sort",
                Description = "Builds the sorted array one element at a time by inserting into the correct position.",
                BestCase = "O(n) (already sorted)",
                WorstCase = "O(n^2)",
                Pseudocode = @"for i from 1 to n-1 key = arr[i] j = i -1 while j >= 0 and arr[j] > key shift arr[j] right insert key",
                DurationMs = sw.Elapsed.TotalMilliseconds,
                Comparisons = comps,
                SortedData = arr              
            };
        }
    }
}
