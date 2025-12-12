using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchingAlgorithms.Models;

namespace SearchingAlgorithms.Algorithms
{
    public static class InterpolationSearch
    {
        public static SearchResult Run(int[] data, int target)
        {
            long comps = 0;
            var sw = System.Diagnostics.Stopwatch.StartNew();

            int left = 0;
            int right = data.Length - 1;

            // Interpolation search estimates the target's position using its value.
            while (left <= right && target >= data[left] && target <= data[right])
            {
                comps++;

                // Estimate the position based on value distribution
                int pos = left + (int)(((double)(target - data[left]) /
                (data[right] - data[left])) *
                (right - left));

                if (pos < 0 || pos >= data.Length)
                    break;

                if (data[pos] == target)
                {
                    sw.Stop();
                    return new SearchResult
                    {
                        Name = "Interpolation Search",
                        Description = "Uses the target value to estimate where it might be. Works best on uniformly distributed data.",
                        BestCase = "O(1)",
                        WorstCase = "O(n) (bad distribution)",
                        Pseudocode = @"left = 0, right = n-1 while target between A[left] and A[right] pos = left + ((target-A[left])/(A[right]-A[left])) * (right-left) if A[pos] == target return pos else if A[pos] < target left = pos+1 else right = pos-1",
                        IndexFound = pos,
                        Comparisons = comps,
                        DurationMs = sw.Elapsed.TotalMilliseconds
                    };
                }

                if (data[pos] < target)
                    left = pos + 1;
                else
                    right = pos - 1;
            }

            sw.Stop();
            return new SearchResult
            {
                Name = "Interpolation Search",
                Description = "Uses the target value to estimate where it might be. Works best on uniformly distributed data.",
                BestCase = "O(1)",
                WorstCase = "O(n)",
                Pseudocode = @"left = 0, right = n-1 while target between A[left] and A[right] pos = left + ((target-A[left])/(A[right]-A[left])) * (right-left) if A[pos] == target return pos else if A[pos] < target left = pos+1 else right = pos-1",
                IndexFound = -1,
                Comparisons = comps,
                DurationMs = sw.Elapsed.TotalMilliseconds
            };
        }
    }
}
