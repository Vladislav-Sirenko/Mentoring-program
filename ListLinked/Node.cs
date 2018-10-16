namespace LinkedList
{
    public class Node<T>
    {
        public T _value { get; set; }
        public Node<T> next { get; set; }
        public Node(T value)
        {
            _value = value;
        }

    }
}