using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchingAlgorithms.Models;


namespace SearchingAlgorithms.Algorithms
{
    public static class BinarySearch
    {
        public static SearchResult Run(int[] data, int target)
        {
            long comps = 0;
            var sw = System.Diagnostics.Stopwatch.StartNew();

            int left = 0;
            int right = data.Length - 1;

            // Binary search cuts the search space in half each step.
            while (left <= right)
            {
                int mid = (left + right) / 2;
                comps++; // Count each comparison

                if (data[mid] == target)
                {
                    sw.Stop();
                    return new SearchResult
                    {
                        Name = "Binary Search",
                        Description = "Halves the search range each step by checking the middle element.",
                        BestCase = "O(1)",
                        WorstCase = "O(log n)",
                        Pseudocode = @"left = 0, right = n-1
while left <= right
    mid = (left+right)/2
    if A[mid] == target return mid
    else if target < A[mid] right = mid-1
    else left = mid+1",
                        IndexFound = mid,
                        Comparisons = comps,
                        DurationMs = sw.Elapsed.TotalMilliseconds
                    };
                }

                // Decide which half to search next
                if (target < data[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            sw.Stop();
            return new SearchResult
            {
                Name = "Binary Search",
                Description = "Halves the search range each step by checking the middle element.",
                BestCase = "O(1)",
                WorstCase = "O(log n)",
                Pseudocode = @"left = 0, right = n-1 while left <= right mid = (left+right)/2 if A[mid] == target return mid else if target < A[mid] right = mid-1 else left = mid+1",
                IndexFound = -1,
                Comparisons = comps,
                DurationMs = sw.Elapsed.TotalMilliseconds
            };
        }
    }
}
