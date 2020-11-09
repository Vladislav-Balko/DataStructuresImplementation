using System;
using System.Collections.Generic;
using System.Collections;


namespace DataStructuresImplementation.SinglyLinkedList
{
    class SinglyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;   // First element
        private Node<T> tail;   // Last element
        private int count;

        public T First { get => head.Value; }
        
        public T Last { get => tail.Value; }

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
            Node<T> newNode = new Node<T>(value);

            if (head == null)
                head = newNode;
            else
                tail.Next = newNode;

            tail = newNode;
            count++;
        }

        public void AppendFirst(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.Next = head;
            head = newNode;

            if (count == 0)
                tail = head;

            count++;
        }

        public bool Remove(T value)
        {
            Node<T> current = head;
            Node<T> previous = null;

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
            Node<T> current = head;

            while(current != null)
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
            Node<T> current = head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        #endregion


    }
}
