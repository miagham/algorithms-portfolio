using System.Threading;



namespace FisherYatesShuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading data from data.txt...");

            //Read the file and put into a list so there is data to shuffle
            string[] lines = File.ReadAllLines("data.txt");
            List<string> items = new List<string>(lines);

            //Shows the original list before shuffling + Color
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypeWrite("\nOriginal order:");
            Console.ResetColor();
            PrintColored(items);

            //Call my Fisher Yates method in to shuffle the list
            FisherYates(items);
          
            //Shows the shuffled list to confirm the algorithm worked
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypeWrite("\nShuffled order:");
            Console.ResetColor();

            PrintColored(items);
        }

        // This is my application of the Fisher-Yates Shuffle.
        // I loop from the end of the list toward the beginning.
        // For each i position, I pick a random j index between 0 and i.
        // Then I swap the items at i and j. This keeps the shuffle fair.
        static void FisherYates(List<string> list)
        {
            Random rng = new Random();
            // Loop it backwards this is a key part 
            for (int i = list.Count - 1; i > 0; i--)
            {
                // Pick a random index from 0 to i
                int j = rng.Next(0, i + 1);

                // Swap the two values at i and j
                string temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        // Prints each fruit in a specific color + uses the typewriter effect
        static void PrintColored(List<string> items)
        {
            foreach (var item in items)
            {
                Console.ForegroundColor = GetFruitColor(item.Trim());
                TypeWrite(item, 20);
            }
            Console.ResetColor();
        }

        static ConsoleColor GetFruitColor(string fruit)
        {
            return fruit.ToLower() switch
            {
                "apple" => ConsoleColor.Red,
                "banana" => ConsoleColor.Yellow,
                "plum" => ConsoleColor.DarkMagenta,
                "cherry" => ConsoleColor.DarkRed,
                "grape" => ConsoleColor.Magenta,
                "pineapple" => ConsoleColor.Yellow,
                "strawberries" => ConsoleColor.Red,
                "watermelon" => ConsoleColor.Green,
                "mango" => ConsoleColor.DarkYellow,
                "peach" => ConsoleColor.Yellow,
                "apricot" => ConsoleColor.DarkYellow,
                _ => ConsoleColor.White
            };
        }
        // Creates a typewriter effect by printing one character at a time
        static void TypeWrite(string text, int delay = 67)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

    }
    
}

