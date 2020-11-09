using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresImplementation.ArrayBasedStacks
{
    class FixedStack<T>
    {
        private T[] items;
        private int count;
        private const int defaultLength = 10;

        public int Count { get => count; }

        public int MaxSize { get => items.Length; }


        public FixedStack()
        {
            items = new T[defaultLength];
        }


        public FixedStack(int length)
        {
            items = new T[length];
        }

        public bool IsEmpty { get => count == 0; }


        public void Push(T item) // Inserts an object at the top of the stack
        {
            if(count == items.Length)
                throw new InvalidOperationException("Stack structure overflow");
            items[count++] = item;
        }


        public T Pop() // Removes and returns the object at the top of the stack.
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack structure is empty");

            T item = items[--count];
            items[count] = default(T);

            return item;
        }


        public T Peek() => items[count - 1]; // Returns the object at the top of the stack without removing it.



    }
}
