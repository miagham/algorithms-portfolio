using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using SortingAlgorithms.Effects;
using SortingAlgorithms.Models;
using SortingAlgorithms.Algorithms;

namespace SortingAlgorithms
{
    internal class Program
    {
        // Stores the relative path to the scores.txt file.
        // This file contains the dataset that every algorithm must sort.
        static string DataPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Data", "scores.txt");

        static void Main(string[] args)
        {
            Console.Clear();

            // Title output using a typewriter effect to improve presentation.
            TypeFX.WriteLineColor("=== Sorting Algorithms Demonstration ===", ConsoleColor.Cyan, 80);
            TypeFX.WriteLine();

            int[] data;

            try
            {
                // The dataset is loaded from the project’s Data folder.
                // I use Path.Combine and GetFullPath to ensure it works regardless of where the EXE runs.
                string exeFolder = AppContext.BaseDirectory;
                string projectData = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Data", "scores.txt");
                string p = Path.GetFullPath(projectData);

                // Read all non-empty lines and convert them to integers.
                // This demonstrates data loading, parsing, and preparation before sorting.
                var lines = File.ReadAllLines(p)
                                .Where(l => !string.IsNullOrWhiteSpace(l))
                                .ToArray();

                data = lines.Select(l => int.Parse(l.Trim())).ToArray();
            }
            catch (Exception ex)
            {
                // If the file cannot be found or read, the program warns the user.
                // Good data validation is essential before running any algorithm.
                TypeFX.WriteColor("Error loading Data/scores.txt. Make sure the file exists and is one integer per line.\n", ConsoleColor.Red, 80);
                TypeFX.WriteLineColor(ex.Message, ConsoleColor.Red, 0);
                return;
            }

            // Confirms that the dataset was loaded and shows the total number of values.
            TypeFX.WriteColor($"Loaded {data.Length} numbers from scores.txt\n\n", ConsoleColor.Cyan, 50);

            // A list of sorting algorithm entry points.
            // Each algorithm exposes a Run method that returns a SortResult.
            var runners = new List<Func<int[], SortResult>>
            {
                BubbleSort.Run,
                InsertionSort.Run,
                SelectionSort.Run,
                HeapSort.Run,
                QuickSort.Run,
                MergeSort.Run
            };

            var results = new List<SortResult>();

            // Loop through all algorithms and run them on the same dataset.
            foreach (var run in runners)
            {
                TypeFX.WriteLineColor("--------------------------------------------------", ConsoleColor.DarkGray, 0);

                // First clone: retrieve descriptive information only
                var tmp1 = (int[])data.Clone();
                var sample = run(tmp1);

                // Display algorithm details
                TypeFX.WriteColor($"\nAlgorithm: {sample.Name}\n", ConsoleColor.Cyan, 4);
                TypeFX.WriteLineColor($"Description: {sample.Description}", ConsoleColor.Cyan, 0);
                TypeFX.WriteLineColor($"Best Case: {sample.BestCase}    Worst Case: {sample.WorstCase}", ConsoleColor.Cyan, 60);
                TypeFX.WriteLineColor("Pseudocode:", ConsoleColor.Cyan, 0);
                TypeFX.WriteLine(sample.Pseudocode, 0);

                // Second clone: real timed run
                var tmp2 = (int[])data.Clone();
                var res = run(tmp2);
                results.Add(res);

                TypeFX.WriteLine();
                TypeFX.WriteColor($"Time: {res.DurationMs:F4} ms    Comparisons: {res.Comparisons}\n", ConsoleColor.Red, 60);

                // Preview first 20 sorted numbers
                var preview = res.SortedData.Take(20).ToArray();
                TypeFX.WriteColor($"Preview (first 20): {string.Join(", ", preview)}\n", ConsoleColor.Cyan, 60);

                TypeFX.Pause();
            }


            // After running all algorithms individually, show a summary comparing performance.
            Console.Clear();
            TypeFX.WriteLineColor("=== Summary (runtimes ms) ===", ConsoleColor.Cyan, 0);
            TypeFX.WriteLine();

            // Sort results by runtime so the fastest algorithm appears first.
            var sortedSummary = results.OrderBy(r => r.DurationMs).ToList();

            foreach (var r in sortedSummary)
            {
                // Displays both runtime and comparison count,
                // connecting implementation details to efficiency.
                TypeFX.WriteColor($"{r.Name.PadRight(15)} : {r.DurationMs,8:F4} ms   comps: {r.Comparisons}\n", ConsoleColor.Cyan, 50);
            }

            TypeFX.WriteLine();
            TypeFX.Pause("Press any key to exit...");
        }
    }
}
