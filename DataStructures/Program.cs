using System;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // My array which is just a list of items in order 
            string[] fruitsArray =
             {
                "Apple", "Banana", "Cherry", "Mango", "Peach",
                "Watermelon", "Orange", "Plum", "Strawberry"
            };

            TypeWrite("=== ARRAY ===");
            TypeWrite("Array items:");

            // Loop through each fruit and print it
            foreach (var fruit in fruitsArray)
            {
                Console.ForegroundColor = GetFruitColor(fruit);
                TypeWrite(fruit, 70);
            }
            Console.ResetColor();

            Dictionary<int, string> fruitMap = new Dictionary<int, string>()
            {
                {1, "Apple"},
                {2, "Banana"},
                {3, "Cherry"},
                {4, "Mango"},
                {5, "Peach"},
                {6, "Watermelon"},
                {7, "Orange"},
                {8, "Plum"},
                {9, "Strawberry"}
            };


            // A Dictionary stores KEY -> VALUE pairs
            TypeWrite("\n=== MAP / DICTIONARY ===");
            TypeWrite("Key Value pairs:");
            foreach (var pair in fruitMap)
            {
                Console.ForegroundColor = GetFruitColor(pair.Value);
                TypeWrite($"{pair.Key}: {pair.Value}", 70);
            }
            Console.ResetColor();

            Stack<string> fruitStack = new Stack<string>();
            fruitStack.Push("Apple");
            fruitStack.Push("Banana");
            fruitStack.Push("Cherry");
            fruitStack.Push("Mango");
            fruitStack.Push("Peach");
            fruitStack.Push("Watermelon");
            fruitStack.Push("Orange");
            fruitStack.Push("Plum");
            fruitStack.Push("Strawberry");


            // Stack = Last In, First Out, like a stack of books
            TypeWrite("\n=== STACK (LIFO) ===");
            TypeWrite("Stack items (top to bottom):");
            foreach (var item in fruitStack)
            {
                Console.ForegroundColor = GetFruitColor(item);
                TypeWrite(item, 70);
            }
            Console.ResetColor();

            // Pop removes the item at the top of the stack
            TypeWrite("Popping top item: " + fruitStack.Pop(), 70);

            Queue<string> fruitQueue = new Queue<string>();
            fruitQueue.Enqueue("Apple");
            fruitQueue.Enqueue("Banana");
            fruitQueue.Enqueue("Cherry");
            fruitQueue.Enqueue("Mango");
            fruitQueue.Enqueue("Peach");
            fruitQueue.Enqueue("Watermelon");
            fruitQueue.Enqueue("Orange");
            fruitQueue.Enqueue("Plum");
            fruitQueue.Enqueue("Strawberry");


            // Queue = First In, First Out, like a line at a store
            TypeWrite("\n=== QUEUE (FIFO) ===");
            TypeWrite("Queue items (first to last):");
            foreach (var item in fruitQueue)
            {
                Console.ForegroundColor = GetFruitColor(item);
                TypeWrite(item, 70);
            }
            Console.ResetColor();


            // Dequeue removes the item that entered first
            TypeWrite("Dequeuing first item: " + fruitQueue.Dequeue(), 70);

            TypeWrite("\nProgram finished. Press any key to exit...");
            Console.ReadKey();
        }

        static void TypeWrite(string text, int delay = 70)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        static ConsoleColor GetFruitColor(string fruit)
        {
            return fruit.ToLower() switch
            {
                "apple" => ConsoleColor.Red,
                "banana" => ConsoleColor.Yellow,
                "cherry" => ConsoleColor.DarkRed,
                "mango" => ConsoleColor.DarkYellow,
                "peach" => ConsoleColor.Yellow,
                "watermelon" => ConsoleColor.Green,
                "plum" => ConsoleColor.DarkMagenta,
                "strawberry" => ConsoleColor.Red,
                _ => ConsoleColor.White
            };
        }
    }
}

