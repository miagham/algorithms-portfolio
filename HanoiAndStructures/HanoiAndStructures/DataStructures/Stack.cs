using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HanoiAndStructures.DataStructures.LinkedList;

namespace HanoiAndStructures.DataStructures.Stack
{
    public class Stack<T>
    {
        private readonly LinkedList.LinkedList<T> _list
            = new LinkedList.LinkedList<T>();

        public int Count => _list.Count;

        public void Push(T value)
        {
            _list.AddFirst(value);
        }

        public T Pop()
        {
            if (_list.IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            return _list.RemoveFirst();
        }

        public T Peek()
        {
            if (_list.IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            return _list.PeekFirst();
        }

        public bool IsEmpty() => _list.IsEmpty();

        public void Clear() => _list.Clear();
    }
}
