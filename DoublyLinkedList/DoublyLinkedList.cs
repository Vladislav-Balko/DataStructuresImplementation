using System;
using System.Collections.Generic;
using System.Collections;

namespace DataStructuresImplementation.DoublyLinkedList
{
    class DoublyLinkedList<T> : IEnumerable<T>
    {
        DoublyNode<T> head;
        DoublyNode<T> tail;
        int count;

        public T First { get => head.Value; }

        public T Last { get => tail.Value; }

        public bool IsEmpty { get => count == 0; }

        public int Count { get => count; }

        public void Add(T value)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(value);

            if (head == null) // if list is empty, also initialize the head
                head = newNode;
            else // in case of not empty list
            {
                tail.Next = newNode; // add the pointer of the next item to tail
                newNode.Previous = tail; // add the pointer of the previous 
            }
            tail = newNode;
            count++;
        }

        public void AddFirst(T value)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(value);
            
            if (count == 0) 
                head = tail = newNode;
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }

            count++;
        }

        public bool Remove(T value)
        {
            DoublyNode<T> current = head;

            while (current != null) // Brute force search for deleted value
            {
                if (current.Value.Equals(value))
                    break;
                current = current.Next;
            }

            if (current != null) // if deleted value was found
            {
                if (current.Next != null) // if item is not the last 
                    current.Next.Previous = current.Previous;
                else
                    tail = current.Previous; // in case of the last, reset the tail 

                if (current.Previous != null) // if element is not the first
                    current.Previous.Next = current.Next;
                else
                    head = current.Next; // in case of the first, reset the head

                count--;
                return true;
            }
            return false;
        }


        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T value)
        {
            DoublyNode<T> current = head;
            while (current != null)
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
            DoublyNode<T> current = head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        #endregion

        public IEnumerable<T> BackEnumerator() // Another one enumerator to iterate over elements from the end
        {
            DoublyNode<T> current = tail;

            while (current != null)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }

    }
}
