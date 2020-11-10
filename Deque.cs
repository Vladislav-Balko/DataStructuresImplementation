using System;
using System.Collections;
using System.Collections.Generic;
using DataStructuresImplementation.DoublyLinkedList;

namespace DataStructuresImplementation
{
    class Deque<T> : IEnumerable<T>
    {
        DoublyNode<T> head;
        DoublyNode<T> tail;
        int count;

        public int Count => count;

        public bool IsEmpty => count == 0;

        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Deque is empty");
                return head.Value;
            }
        }

        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Deque is empty");
                return tail.Value;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;

        }

        public void AddLast(T value)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(value);

            if (head == null)
                head = newNode;
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
            }
            tail = newNode;
            count++;
        }

        public void AddFirst(T value)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(value);
            DoublyNode<T> oldHead = head;
            newNode.Next = oldHead;
            head = newNode;

            if (count == 0)
                tail = head;
            else
                oldHead.Previous = newNode;

            count++;
        }

        public T RemoveFirst()
        {
            if (count == 0)
                throw new InvalidCastException("Deque is empty");

            T removedItem = head.Value;

            if (count == 1)
                head = tail = null;
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            count--;
            return removedItem;
        }

        public T RemoveLast()
        {
            if (count == 0)
                throw new InvalidCastException("Deque is empty");

            T removedItem = tail.Value;

            if (count == 1)
                head = tail = null;
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            count--;

            return removedItem;
        }

        public bool Contains(T value)
        {
            DoublyNode<T> current = head;

            while(current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }

        #region IEnumerable interface implementation
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        #endregion

    }
}
