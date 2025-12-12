using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HanoiAndStructures.DataStructures.LinkedList;

namespace HanoiAndStructures.DataStructures.Queue
{
   
    public class Queue<T>
    {
        private readonly HanoiAndStructures.DataStructures.LinkedList.LinkedList<T> _list
            = new HanoiAndStructures.DataStructures.LinkedList.LinkedList<T>();

        public int Count => _list.Count;

        
        public void Enqueue(T value)
        {
            _list.AddLast(value);
        }

        public T Dequeue()
        {
            if (_list.IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            return _list.RemoveFirst();
        }

        public T Peek()
        {
            if (_list.IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            return _list.PeekFirst();
        }

        public bool IsEmpty() => _list.IsEmpty();

        public void Clear() => _list.Clear();
    }
}