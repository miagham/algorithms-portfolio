using System;
using System.Threading;

namespace BigONotation
{
    class Program
    {
        static void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            TypeWriter("========================================", 1);
            TypeWriter("   BIG O NOTATION DEMONSTRATION (C#)", 50);
            TypeWriter("========================================", 1);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            TypeWriter("O(1)  -> Constant Time", 60);

            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeWriter("O(n)  -> Linear Time", 60);

            Console.ForegroundColor = ConsoleColor.Green;
            TypeWriter("O(n²) -> Quadratic Time", 60);

            Console.ResetColor();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            PrintHeader();

            int[] numbers = { 1, 2, 3, 4, 5 };

            PrintFirstElement(numbers);// O(1)
            PrintAllElements(numbers); // O(n)
            PrintAllPairs(numbers);   // O(n^2)

            Console.ResetColor();
        }

        // --------------------------------------------------
        // Typewriter Effect
        // --------------------------------------------------
        static void TypeWriter(string text, int delay = 60)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }


        // --------------------------------------------------
        // O(1) – Constant Time
        // --------------------------------------------------
        static void PrintFirstElement(int[] array)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            TypeWriter("O(1) – Constant Time Example");
            TypeWriter("First element: " + array[0]);

            Console.WriteLine();
        }

        // --------------------------------------------------
        // O(n) – Linear Time
        // --------------------------------------------------
        static void PrintAllElements(int[] array)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            TypeWriter("O(n) – Linear Time Example");

            for (int i = 0; i < array.Length; i++)
            {
                TypeWriter("Element: " + array[i]);
            }

            Console.WriteLine();
        }

        // --------------------------------------------------
        // O(n^2) – Quadratic Time
        // --------------------------------------------------
        static void PrintAllPairs(int[] array)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            TypeWriter("O(n^2) – Quadratic Time Example");

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    TypeWriter($"Pair: ({array[i]}, {array[j]})", 50);
                }
            }

            Console.WriteLine();
        }
    }
}
