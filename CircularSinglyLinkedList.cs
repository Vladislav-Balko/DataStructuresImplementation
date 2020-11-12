using System.Collections.Generic;
using System.Collections;
using DataStructuresImplementation.SinglyLinkedList;

namespace DataStructuresImplementation
{
    class CircularSinglyLinkedList<T> : IEnumerable<T>
    {
        SinglyNode<T> head;
        SinglyNode<T> tail;
        int count;

        public int Count => count;

        public bool IsEmpty => count == 0;

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
            {
                head = newNode;
                tail = newNode;
                tail.Next = head;
            }
            else
            {
                newNode.Next = head;
                tail.Next = newNode;
                tail = newNode;
            }
            count++;
        }

        public bool Remove(T value)
        {
            SinglyNode<T> current = head;
            SinglyNode<T> previous = null;

            if (IsEmpty) 
                return false;

            do
            {
                if (current.Value.Equals(value))
                {
                    if (previous != null) // if removing node is not the first
                    {
                        previous.Next = current.Next;

                        if (current == tail)
                            tail = previous;
                    }
                    else    // if the first node is removing
                    {
                        if (count == 1)
                            head = tail = null;
                        else
                        {
                            head = current.Next;
                            tail.Next = current.Next;
                        }

                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            while (current != head);

            return false;
        }

        public bool Contains(T value)
        {
            SinglyNode<T> current = head;
            if (current == null) return false;

            do
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            while (current != head);

            return false;
        }




        #region IENumerable interface implementation
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            SinglyNode<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.Value;
                    current = current.Next;
                }
            }
            while (current != head);
        }
        #endregion
    }
}
