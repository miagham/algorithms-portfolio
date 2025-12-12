using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HanoiAndStructures.DataStructures.LinkedList; 
using DSStack = HanoiAndStructures.DataStructures.Stack;
using HanoiAndStructures.Effects;

namespace HanoiAndStructures.Games
{
    public class TowerOfHanoi
    {
        private DSStack.Stack<int> _tower1 = new DSStack.Stack<int>();
        private DSStack.Stack<int> _tower2 = new DSStack.Stack<int>();
        private DSStack.Stack<int> _tower3 = new DSStack.Stack<int>();

        private int _numRings;

        public void Start()
        {
            Console.Clear();
            TypeFX.WriteColor("=== Tower of Hanoi ===\n\n", ConsoleColor.Cyan, 80);

            TypeFX.Write("How many rings? ", 10);
            if (!int.TryParse(Console.ReadLine(), out _numRings) || _numRings < 1)
            {
                TypeFX.WriteColor("\nInvalid number of rings.\n", ConsoleColor.Red, 70);
                TypeFX.Write("Press any key...");
                Console.ReadKey();
                return;
            }

            _tower1.Clear();
            _tower2.Clear();
            _tower3.Clear();

            for (int i = _numRings; i >= 1; i--)
                _tower1.Push(i);

            PlayGame();
        }

        private void PlayGame()
        {
            while (true)
            {
                Console.Clear();
                TypeFX.WriteColor("=== Tower of Hanoi ===\n\n", ConsoleColor.Cyan, 80);
                PrintTowers();

                TypeFX.Write("\nChoose a tower to move FROM (1, 2, 3): ", 70);
                int from = GetTowerSelection();

                TypeFX.Write("Choose a tower to move TO (1, 2, 3): ", 70);
                int to = GetTowerSelection();

                if (!IsMoveValid(from, to))
                {
                    TypeFX.WriteColor("\n⚠ Invalid move! You cannot place a larger ring on a smaller one.\n", ConsoleColor.Red, 70);
                    TypeFX.Write("Press any key...");
                    Console.ReadKey();
                    continue;
                }

                Move(from, to);

                if (_tower3.Count == _numRings)
                {
                    Console.Clear();
                    PrintTowers();
                    TypeFX.WriteColor("\n You solved the Tower of Hanoi!\n", ConsoleColor.Cyan, 80);
                    TypeFX.Write("Press any key...");
                    Console.ReadKey();
                    break;
                }
            }
        }
        private int GetTowerSelection()
        {
            while (true)
            {
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int num) && num >= 1 && num <= 3)
                    return num;

                TypeFX.WriteColor("Please enter 1, 2, or 3: ", ConsoleColor.Red, 70);
            }
        }
        private bool IsMoveValid(int from, int to)
        {
            var src = GetTower(from);
            var dst = GetTower(to);

            if (src.IsEmpty())
                return false;

            if (dst.IsEmpty())
                return true;

            return src.Peek() < dst.Peek();
        }
        private void Move(int from, int to)
        {
            var src = GetTower(from);
            var dst = GetTower(to);

            int ring = src.Pop();
            dst.Push(ring);
        }

        private DSStack.Stack<int> GetTower(int number)
        {
            return number switch
            {
                1 => _tower1,
                2 => _tower2,
                3 => _tower3,
                _ => _tower1
            };
        }

        private void PrintTowers()
        {
            TypeFX.WriteColor("Tower 1: ", ConsoleColor.Cyan, 70);
            TypeFX.Write(FormatTower(_tower1) + "\n", 1);

            TypeFX.WriteColor("Tower 2: ", ConsoleColor.Cyan, 70);
            TypeFX.Write(FormatTower(_tower2) + "\n", 1);

            TypeFX.WriteColor("Tower 3: ", ConsoleColor.Cyan, 70);
            TypeFX.Write(FormatTower(_tower3) + "\n\n", 1);
        }
        private string FormatTower(DSStack.Stack<int> tower)
        {
            var temp = new DSStack.Stack<int>();
            string result = "";

            while (!tower.IsEmpty())
            {
                int v = tower.Pop();
                result += v + " ";
                temp.Push(v);
            }

            while (!temp.IsEmpty())
                tower.Push(temp.Pop());

            return result.Trim();
        }
    }
}