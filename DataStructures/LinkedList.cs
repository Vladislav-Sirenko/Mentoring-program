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

        private Node<T> _tail { get; set; }

        public LinkedList() { }

        public void Add(T value)
        {
            if (Length == 0)
            {
                _head = new Node<T>(value);
                Length++;
                _tail = _head;
                return;
            }

            _tail.Next = new Node<T>(value);
            _tail = _tail.Next;

            Length++;
        }

        public T Pop()
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (Length == 1)
            {
                var currentValue = _head.Value;
                Length--;
                _head = null;
                return currentValue;
            }
            else
            {
                var tailPrevious = _head;
                while (tailPrevious.Next != _tail)
                {
                    tailPrevious = tailPrevious.Next;
                }

                _tail = tailPrevious;
                tailPrevious.Next = null;
                Length--;
                return _tail.Value;
            }
        }

        public void AddAt(int index, T value)
        {
            var prev = GetByIndex(index - 1);
            var next = prev.Next;
            prev.Next = new Node<T>(value) { Next = next };
            Length++;
        }

        public T RemoveAt(int index)
        {
            if (Length == 0 || index > Length - 1)
            {
                throw new IndexOutOfRangeException();
            }

            var prev = GetByIndex(index - 1);
            if (prev == _head)
            {
                var itemToRemove = _head;
                _head = _head.Next;
                Length--;
                return itemToRemove.Value;
            }

            var removedNode = prev.Next;
            prev.Next = prev.Next.Next;
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
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (Length == 1)
            {
                var current = _head.Value;
                _head = null;
                Length--;
                return current;
            }
            else
            {
                var current = _head.Value;
                _head = _head.Next;
                Length--;
                return current;
            }
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