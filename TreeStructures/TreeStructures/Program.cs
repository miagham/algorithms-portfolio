using SearchingAlgorithms.Effects;
using System;
using System.IO;
using System.Linq;
using TreeStructures.Algorithms;
using TreeStructures.Trees;

namespace TreeStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            TypeFX.WriteLineColor("=== Tree Structures Demonstration ===", ConsoleColor.Cyan, 60);
            TypeFX.WriteLine();

            int[] data;

            // Load dataset from scores.txt
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Data", "scores.txt");
                path = Path.GetFullPath(path);

                data = File.ReadAllLines(path)
                           .Where(l => !string.IsNullOrWhiteSpace(l))
                           .Select(l => int.Parse(l.Trim()))
                           .ToArray();
            }
            catch (Exception ex)
            {
                TypeFX.WriteLineColor("Failed to load Data/scores.txt", ConsoleColor.Red, 40);
                TypeFX.WriteLineColor(ex.Message, ConsoleColor.Red, 0);
                return;
            }

            TypeFX.WriteLineColor($"Loaded {data.Length} numbers from scores.txt\n", ConsoleColor.Cyan, 40);

            // Sort the data before inserting into the tree
            TypeFX.WriteLineColor("Sorting data using Insertion Sort...\n", ConsoleColor.Cyan, 40);
            int[] sortedData = InsertionSort.Sort(data);

            // Build the Binary Search Tree
            TypeFX.WriteLineColor("Building Binary Search Tree...\n", ConsoleColor.Cyan, 40);
            BinarySearchTree bst = new BinarySearchTree();

            foreach (int value in sortedData)
                bst.Insert(value);

            // Traverse the tree in-order
            TypeFX.WriteLineColor("In-order traversal of the tree:\n", ConsoleColor.Cyan, 40);

            int count = 0;
            bst.InOrderTraversal(value =>
            {
                Console.Write(value + " ");
                count++;

                // New line every 20 values for readability
                if (count % 20 == 0)
                    Console.WriteLine();
            });

            TypeFX.WriteLine();
            TypeFX.WriteLine();
            TypeFX.Pause("Press any key to exit...");
        }
    }
}