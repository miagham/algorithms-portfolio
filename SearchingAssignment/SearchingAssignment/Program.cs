using SearchingAlgorithms.Algorithms;
using SearchingAlgorithms.Models;
using SearchingAlgorithms.Effects;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SearchingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            TypeFX.WriteLineColor("=== Searching Algorithms Demonstration ===", ConsoleColor.Cyan, 60);
            TypeFX.WriteLine();

            int[] data;

            // Load the dataset (scores.txt)
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Data", "scores.txt");
                path = Path.GetFullPath(path);

                var lines = File.ReadAllLines(path)
                    .Where(l => !string.IsNullOrWhiteSpace(l))
                    .Select(l => int.Parse(l.Trim()))
                    .ToArray();

                data = lines;
            }
            catch (Exception ex)
            {
                TypeFX.WriteLineColor("Failed to load Data/scores.txt", ConsoleColor.Red, 50);
                TypeFX.WriteLineColor(ex.Message, ConsoleColor.Red, 0);
                return;
            }

            TypeFX.WriteLineColor($"Loaded {data.Length} numbers from scores.txt\n", ConsoleColor.Cyan, 40);

            // Ask for a value to search for
            int target = AskForTarget();

            // List of search algorithms
            var searches = new Func<int[], int, SearchResult>[]
            {
                LinearSearch.Run,
                BinarySearch.Run,
                InterpolationSearch.Run
            };

            var results = new List<SearchResult>();

            foreach (var search in searches)
            {
                Console.Clear();

                // Run algorithm
                var sample = search(data, target);
                results.Add(sample);

                // Output details
                TypeFX.WriteColor($"\nAlgorithm: {sample.Name}\n", ConsoleColor.Cyan, 5);
                TypeFX.WriteLineColor($"Description: {sample.Description}", ConsoleColor.Cyan, 0);
                TypeFX.WriteLineColor($"Best Case: {sample.BestCase}    Worst Case: {sample.WorstCase}", ConsoleColor.Cyan, 0);

                TypeFX.WriteLineColor("Pseudocode:", ConsoleColor.Cyan, 0);
                TypeFX.WriteLine(sample.Pseudocode, 0);

                // Results
                TypeFX.WriteLine();
                TypeFX.WriteColor($"Index Found: {sample.IndexFound}\n", ConsoleColor.Red, 40);
                TypeFX.WriteColor($"Comparisons: {sample.Comparisons}\n", ConsoleColor.Red, 40);
                TypeFX.WriteColor($"Time: {sample.DurationMs:F4} ms\n\n", ConsoleColor.Red, 40);

                TypeFX.Pause("Press any key for next algorithm...");
            }

            // Summary
            Console.Clear();
            TypeFX.WriteLineColor("=== Summary of Search Algorithms ===", ConsoleColor.Cyan, 40);
            TypeFX.WriteLine();

            // Sorted fastest to slowest
            var ordered = results.OrderBy(r => r.DurationMs);

            foreach (var r in ordered)
            {
                TypeFX.WriteColor(
                    $"{r.Name.PadRight(20)}  |  Found: {r.IndexFound,4}  |  Time: {r.DurationMs,8:F4} ms  |  Comps: {r.Comparisons}\n",
                    ConsoleColor.Cyan,
                    30
                );
            }

            TypeFX.WriteLine();
            TypeFX.Pause("Press any key to exit...");
        }

        private static int AskForTarget()
        {
            while (true)
            {
                TypeFX.WriteColor("Enter a number to search for: ", ConsoleColor.Cyan, 0);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int num))
                    return num;

                TypeFX.WriteLineColor("Invalid number. Try again.\n", ConsoleColor.Red, 30);
            }
        }
    }
}
