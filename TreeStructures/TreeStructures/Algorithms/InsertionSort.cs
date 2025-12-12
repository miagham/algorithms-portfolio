using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeStructures.Algorithms
{
    // Simple insertion sort used to sort the dataset before building the tree
    public static class InsertionSort
    {
        public static int[] Sort(int[] data)
        {
            int[] arr = (int[])data.Clone();

            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;
                // Move larger values one position to the right
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }

            return arr;
        }
    }
}
