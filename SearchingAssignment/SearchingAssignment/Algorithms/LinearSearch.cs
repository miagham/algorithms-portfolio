using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchingAlgorithms.Models;

namespace SearchingAlgorithms.Algorithms
{
    public static class LinearSearch
    {
        public static SearchResult Run(int[] data, int target)
        {
            long comps = 0;
            var sw = System.Diagnostics.Stopwatch.StartNew();

            // Check one item at a time from start to end.
            for (int i = 0; i < data.Length; i++)
            {
                comps++; // Counting comparisons for performance info.

                if (data[i] == target)
                {
                    sw.Stop();
                    return new SearchResult
                    {
                        Name = "Linear Search",
                        Description = "Checks each element one by one until the target is found.",
                        BestCase = "O(1) (first element)",
                        WorstCase = "O(n)",
                        Pseudocode = @"for i = 0 to n-1
    if A[i] == target
        return i",
                        IndexFound = i,
                        Comparisons = comps,
                        DurationMs = sw.Elapsed.TotalMilliseconds
                    };
                }
            }

            // If not found:
            sw.Stop();
            return new SearchResult
            {
                Name = "Linear Search",
                Description = "Checks each element one by one until the target is found.",
                BestCase = "O(1)",
                WorstCase = "O(n)",
                Pseudocode = @"for i = 0 to n-1
    if A[i] == target
        return i",
                IndexFound = -1,
                Comparisons = comps,
                DurationMs = sw.Elapsed.TotalMilliseconds
            };
        }
    }
}
