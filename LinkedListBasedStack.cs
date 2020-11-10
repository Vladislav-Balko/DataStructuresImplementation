using System;
using System.Collections.Generic;
using System.Collections;
using DataStructuresImplementation.SinglyLinkedList;


namespace DataStructuresImplementation.LinkedListBasedStack
{
    class LinkedListBasedStack<T> : IEnumerable<T>
    {
        SinglyNode<T> top;
        int count;

        public bool IsEmpty => count == 0;


        public int Count => count;


        public void Push(T item)
        {
            SinglyNode<T> newNode = new SinglyNode<T>(item);
            newNode.Next = top;
            top = newNode;
            count++;
        }


        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            SinglyNode<T> poppedItem = top;
            top = top.Next;
            count--;

            return poppedItem.Value;
        }

        
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            return top.Value;
        }


        #region IEnumerable interface implementation 
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            SinglyNode<T> current = top;

            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        #endregion

    }
}
