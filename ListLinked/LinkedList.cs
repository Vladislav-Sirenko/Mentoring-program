using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    
    public  class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        public int Length { get; private set; }

        public LinkedList() {  }

        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new Node<T>(value);
                Length++;
                return;
            }

            var current = _head;
            while (current._next != null)
            {
                current = current._next;
            }

            current._next = new Node<T>(value);
            Length++;
        }

        public void AddAt(int index, T value)
        {
            var current = _head;
            int headPosition = 0;
            while (headPosition < index - 1)
            {
                current = current._next;
                headPosition++;
            }

            var next = current._next;
            current._next = new Node<T>(value) {_next = next};
            Length++;
        }
        
        public T RemoveAt(int index)
        {
            var current = _head;
            int headPosition = 0;
            while (headPosition < index - 1)
            {
                current = current._next;
                headPosition++;
            }

            var removedNode = current._next;
            current._next = current._next._next;
            Length--;
            return removedNode._value;
        }

        public T ElementAt(int index)
        {
            var current = _head;
            int headPosition = 0;
            while (headPosition < index)
            {
                current = current._next;
                headPosition++;
            }

            return current._value;
        }

        public T Remove()
        {
            var current = _head;
            while (current._next._next != null)
            {
                current = current._next;
            }

            var temp = current._next;
            current._next = null;
            Length--;
            return temp._value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current._value;
                current = current._next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Node<T>
        {
            public T _value { get; private set; }
            public Node<T> _next { get; set; }
            public Node(T value)
            {
                _value = value;
            }
        }
    }
}