using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    
    public  class LinkedList<T> : IEnumerable<T>
    {
        private class Node<T>
        {
            public T _value { get; private set; }
            public Node<T> next { get; set; }
            public Node(T value)
            {
                _value = value;
            }

        }
        private Node<T> _head;
        private int _length { get; set; }

        public LinkedList()
        {
            _length = 0;
        }

        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new Node<T>(value);
                _length++;
                return;
            }
            var current = _head;
            while (current.next != null)
            {
                current = current.next;
            }

            current.next = new Node<T>(value);
            _length++;

        }

        public void AddAt(int index, T value)
        {
            var current = _head;
            int headPosition = 0;
            while (headPosition < index - 1)
            {
                current = current.next;
                headPosition++;
            }

            var next = current.next;
            current.next = new Node<T>(value);
            current.next.next = next;
            _length++;
        }

        public int Length()
        {
            return _length;
        }

        public T RemoveAt(int index)
        {
            var current = _head;
            int headPosition = 0;
            while (headPosition < index - 1)
            {
                current = current.next;
                headPosition++;
            }

            var removedNode = current.next;
            current.next = current.next.next;
            _length--;
            return removedNode._value;
        }

        public T ElementAt(int index)
        {
            var current = _head;
            int headPosition = 0;
            while (headPosition < index)
            {
                current = current.next;
                headPosition++;
            }

            return current._value;
        }
        public T Remove()
        {
            var current = _head;

            while (current.next.next != null)
            {
                current = current.next;
            }
            var temp = current.next;
            current.next = null;
            _length--;
            return temp._value;
        }



        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current._value;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}