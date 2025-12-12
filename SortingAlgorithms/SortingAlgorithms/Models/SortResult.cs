using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Models
{
    public class SortResult
    {
        public string Name { get; set; } = ""; // algorithm name
        public string Description { get; set; } = ""; // short explanation
        public string BestCase { get; set; } = ""; // Big-O best case
        public string WorstCase { get; set; } = ""; // Big-O worst case
        public string Pseudocode { get; set; } = ""; // pseudocode shown to user
        public double DurationMs { get; set; } // runtime in milliseconds
        public long Comparisons { get; set; } // number of comparisons made
        public int[] SortedData { get; set; } = Array.Empty<int>(); // final sorted numbers
    }
}
