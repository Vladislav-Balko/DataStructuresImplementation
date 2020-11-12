using System.Collections.Generic;
using System.Collections;
using DataStructuresImplementation.DoublyLinkedList;

namespace DataStructuresImplementation
{
    class CircularDoublyLinkedList<T> : IEnumerable<T>
    {
        DoublyNode<T> head;
        int count = 0;

        public int Count => count;

        public bool IsEmpty => count == 0;

        public void Clear()
        {
            head = null;
            count = 0;
        }


        public void Add(T value)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(value);

            if (head == null)
            {
                head = newNode;
                head.Next = newNode;
                head.Previous = newNode;
            }
            else
            {
                newNode.Previous = head.Previous;
                newNode.Next = head;
                head.Previous.Next = newNode;
                head.Previous = newNode;
            }
            count++;
        }

        public bool Remove(T value)
        {
            DoublyNode<T> current = head;
            DoublyNode<T> removedItem = null;

            if (count == 0)
                return false;

            do
            {
                if (current.Value.Equals(value))
                {
                    removedItem = current;
                    break;
                }
                current = current.Next;
            }
            while (current != head);

            if(removedItem != null)
            {
                if (count == 1)
                    head = null;
                else
                {
                    if (removedItem == head)
                        head = head.Next;

                    removedItem.Previous.Next = removedItem.Next;
                    removedItem.Next.Previous = removedItem.Previous;
                }
                count--;
                return true;
            }
            return false;
        }

        public bool Contains(T value)
        {
            DoublyNode<T> current = head;

            if (current == null) 
                return false;

            do 
            {
                if (current.Value.Equals(value))
                    return true;

                current = current.Next;
            }
            while (current != head);
            return false;
        }

        #region IEnumerable interface imlementation
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
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
