using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Effects
{
    public static class TypeFX
    {
        public static void Write(string text, int delay = 6)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }
        public static void WriteLine(string text = "", int delay = 0)
        {
            if (delay <= 0) { Console.WriteLine(text); return; }
            Write(text, delay);
            Console.WriteLine();
        }
        public static void WriteColor(string text, ConsoleColor color, int delay = 6)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Write(text, delay);
            Console.ForegroundColor = old;
        }
        public static void WriteLineColor(string text, ConsoleColor color, int delay = 0)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            WriteLine(text, delay > 0 ? delay : 0);
            Console.ForegroundColor = old;
        }
        public static void Pause(string prompt = "Press any key to continue...")
        {
            Console.WriteLine();
            Console.Write(prompt);
            Console.ReadKey(true);
        }
    }
}
