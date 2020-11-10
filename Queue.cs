using DataStructuresImplementation.SinglyLinkedList;
using System;
using System.Collections.Generic;
using System.Collections;

namespace DataStructuresImplementation
{
    class Queue<T> : IEnumerable<T>
    {
        SinglyNode<T> head;
        SinglyNode<T> tail;

        int count;

        public int Count => count;

        public bool IsEmpty => count == 0;

        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Queue is empty");
                return head.Value;
            }
        }

        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Queue is empty");
                return tail.Value;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Enqueue(T value)
        {
            SinglyNode<T> newNode = new SinglyNode<T>(value);
            SinglyNode<T> oldTail = tail;

            tail = newNode;

            if (count == 0)
                head = tail;
            else
                oldTail.Next = tail;

            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException("Queue is empty");

            T dequeued = head.Value;
            head = head.Next;
            count--;

            return dequeued;
        }

        public bool Contains(T value)
        {
            SinglyNode<T> current = head;

            while(current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }

        #region IENumerable interface implementation 
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            SinglyNode<T> current = head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        #endregion

    }
}
