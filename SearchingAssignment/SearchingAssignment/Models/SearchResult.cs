using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchingAlgorithms.Models;

namespace SearchingAlgorithms.Models
{
    public class SearchResult
    {
        // Name of the searching algorithm
        public string Name { get; set; } = "";

        // Brief explanation of how it works
        public string Description { get; set; } = "";

        // Best and worst case Big-O
        public string BestCase { get; set; } = "";
        public string WorstCase { get; set; } = "";

        // Pseudocode shown to the user
        public string Pseudocode { get; set; } = "";

        // How long the search took in ms
        public double DurationMs { get; set; }

        // How many comparisons were made
        public long Comparisons { get; set; }

        // The index where the value was found (-1 if not found)
        public int IndexFound { get; set; }

    }
}
