using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace HanoiAndStructures.Effects
{
    public static class TypeFX
    {
        public static void Write(string text, int delay = 20)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }
        public static void WriteColor(string text, ConsoleColor color, int delay = 20)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Write(text, delay);
            Console.ForegroundColor = old;
        }
        public static void LineColor(string text, ConsoleColor color)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = old;
        }
    }
}
