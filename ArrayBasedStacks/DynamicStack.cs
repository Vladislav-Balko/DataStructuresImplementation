using System;

namespace DataStructuresImplementation.ArrayBasedStacks
{
    /// <summary>
    /// Array based stack with dynamic count of elements. 
    /// The length of the array under the hood is increased / decreased in parts by 10 items 
    /// to achieve a compromise between memory usage and perfomance.
    /// </summary>
    /// <typeparam name="T">The element type of the stack</typeparam>
    class DynamicStack<T>
    {
        private T[] items;
        private int count;
       
        public DynamicStack(int length = 10)
        {
            items = new T[length];
        }

        public bool IsEmpty => count == 0;

        public int Count => count;

        private void Resize(int maxSize)
        {
            T[] newItems = new T[maxSize];
            
            for (int i = 0; i < count; i++)
                newItems[i] = items[i];
            
            items = newItems;
        }

        public void Push(T item)
        {
            if (count == items.Length) // If the stack is full
                Resize(items.Length + 10); // Add 10 new empty elements

            // The number 10 was chosen as a compromise: 1 allows to reduce memory usage to a minimum, but
            // this will increase the frequency of memory reallocation, which ultimately leads to reduced performance

            items[count++] = item; // Now you can push the value to the stack
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack structure is empty");

            T item = items[--count];
            items[count] = default(T);

            if (count > 0 && count < items.Length - 10)  
                Resize(items.Length - 10); // Remove 10 empty elements if possible

            return item;
        }

        public T Peek() => items[count - 1];

    }
}
