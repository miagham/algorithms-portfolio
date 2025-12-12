using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiAndStructures.DataStructures.LinkedList
{
    public class LinkedList<T>
    {
        public Node<T>? Head { get; private set; }
        public int Count { get; private set; }

        public LinkedList()
        {
            Head = null;
            Count = 0;
        }

        public void AddFirst(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.Next = Head;
            Head = newNode;
            Count++;
        }

        public void AddLast(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node<T> current = Head;
                while (current.Next != null)
                    current = current.Next;

                current.Next = newNode;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            if (Head == null)
                throw new InvalidOperationException("List is empty.");

            T value = Head.Data;
            Head = Head.Next;
            Count--;
            return value;
        }

        public T PeekFirst()
        {
            if (Head == null)
                throw new InvalidOperationException("List is empty.");

            return Head.Data;
        }

        public bool IsEmpty() => Count == 0;

   
        public void Clear()
        {
            Head = null;
            Count = 0;
        }
    }
}
