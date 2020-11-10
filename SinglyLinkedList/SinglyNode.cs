namespace DataStructuresImplementation.SinglyLinkedList
{
    public class SinglyNode<T>
    {
        public SinglyNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public SinglyNode<T> Next { get; set; }

    }
}
