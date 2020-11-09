namespace DataStructuresImplementation.DoublyLinkedList
{
    class DoublyNode<T>
    {
        public DoublyNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }

        public DoublyNode<T> Previous { get; set; }

        public DoublyNode<T> Next { get; set; }


    }
}
