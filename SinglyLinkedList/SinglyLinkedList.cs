using System.Collections.Generic;
using System.Collections;
using System;

namespace DataStructuresImplementation.SinglyLinkedList
{
    class SinglyLinkedList<T> : IEnumerable<T>
    {
        private SinglyNode<T> head;   // First element
        private SinglyNode<T> tail;   // Last element
        private int count;

        public T First
        {
            get
            {
                if (!IsEmpty)
                    return head.Value;
                else
                    throw new InvalidOperationException("List is empty");
            }
        }

        public T Last
        {
            get
            {
                if (!IsEmpty)
                    return tail.Value;
                else
                    throw new InvalidOperationException("List is empty");
            }
        }

        public int Count { get => count; }

        public bool IsEmpty { get => count == 0; }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;

        }

        public void Add(T value)
        {
            SinglyNode<T> newNode = new SinglyNode<T>(value);

            if (head == null)
                head = newNode;
            else
                tail.Next = newNode;

            tail = newNode;
            count++;
        }

        public void AppendFirst(T value)
        {
            SinglyNode<T> newNode = new SinglyNode<T>(value);
            newNode.Next = head;
            head = newNode;

            if (count == 0)
                tail = head;

            count++;
        }

        public bool Remove(T value)
        {
            SinglyNode<T> current = head;
            SinglyNode<T> previous = null;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous != null) // If removing element is not the first 
                    {
                        previous.Next = current.Next; // change the pointer of the next element(remove element, in fact)

                        if (current.Next == null) // in case of the last element, change the tail pointer 
                            tail = previous;
                    }
                    else // in case of the first element
                    {
                        head = head.Next; // change the head pointer 

                        if (head == null) // if the list's become empty, reset the tail pointer either
                            tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public bool Contains(T value)
        {
            SinglyNode<T> current = head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }

        #region IEnumarable interface implementation 

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
