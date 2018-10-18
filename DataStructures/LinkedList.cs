using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LinkedList
{

    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;

        public int Length { get; private set; }

        private Node<T> _lastAdd { get; set; }




        public LinkedList() { }

        public void Add(T value)
        {
            Node<T> current;
            if (_head == null)
            {
                _head = new Node<T>(value);
                Length++;
                _lastAdd = _head;
                return;
            }

            current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = new Node<T>(value);
            Length++;
            _lastAdd = current.Next;

        }

        public void Pop()
        {
            var current = _head;
            if (_lastAdd == _head)
            {
                var currentNode = _head.Next;
                _head = currentNode;
                _lastAdd = _head;
                Length--;
                return;
            }

            while (current.Next != _lastAdd)
            {
                current = current.Next;
            }

            _lastAdd = current;
            current.Next = current.Next.Next;
            Length--;
        }

        public void Push(T value)
        {
            var current = _head;
            var previous = new Node<T>(value);
            _head = previous;
            _head.Next = current;
            _lastAdd = _head;
            Length++;
        }

        public void AddAt(int index, T value)
        {
            var current = GetByIndex(index - 1);
            var next = current.Next;
            current.Next = new Node<T>(value) { Next = next };
            Length++;
            _lastAdd = current.Next;
        }

        public T RemoveAt(int index)
        {
            var current = GetByIndex(index - 1);
            if (current == _head)
            {
                _head = null;
                Length--;
                return current.Next.Value;
            }

            var removedNode = current.Next;
            current.Next = current.Next.Next;
            Length--;
            return removedNode.Value;
        }

        public T ElementAt(int index)
        {
            return GetByIndex(index).Value;
        }

        private Node<T> GetByIndex(int index)
        {
            var current = _head;
            int headPosition = 0;
            while (headPosition < index)
            {
                current = current.Next;
                headPosition++;
            }

            return current;
        }

        public T Remove()
        {
            var current = _head;
            if (_head.Next == null)
            {
                Length--;
                _head = null;
                return current.Value;
            }
            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            var temp = current.Next;
            current.Next = null;
            Length--;
            return temp.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Next.Value;
                current = current.Next;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Node<T>
        {
            public T Value { get; private set; }
            public Node<T> Next { get; set; }
            public Node(T value)
            {
                Value = value;
            }

        }
    }
}