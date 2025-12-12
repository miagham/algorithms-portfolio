using HanoiAndStructures.Games;
using HanoiAndStructures.Effects;

namespace HanoiAndStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                TypeFX.WriteColor("=== Algorithms Portfolio ===\n", ConsoleColor.Cyan, 80);
                TypeFX.WriteColor("1. Tower of Hanoi\n", ConsoleColor.Red, 80);
                TypeFX.WriteColor("2. Exit\n\n", ConsoleColor.Cyan, 80);

                TypeFX.Write("Choose an option: ", 70);

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        new TowerOfHanoi().Start();
                        break;

                    case "2":
                        TypeFX.WriteColor("\nGoodbye!\n", ConsoleColor.Red, 60);
                        return;

                    default:
                        TypeFX.WriteColor("\nInvalid choice. Press any key...", ConsoleColor.Red, 60);
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
