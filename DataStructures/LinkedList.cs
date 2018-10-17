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

        private Node<T> LastAdd { get; set; }
        private Node<T> _current;
        private int _headPosition;



        public LinkedList() { }

        public void Add(T value)
        {

            if (_head == null)
            {
                _head = new Node<T>(value);
                Length++;
                LastAdd = _head;
                _current = _head;
                return;
            }

            _current = _head;
            while (_current._next != null)
            {
                _current = _current._next;
            }

            _current._next = new Node<T>(value);
            Length++;
            LastAdd = _current._next;

        }

        public void Pop()
        {
            _current = _head;
            if (LastAdd == _head)
            {
                var currentNode = _head._next;
                _head = currentNode;
                LastAdd = _head;
                _current = _head;
                Length--;
                return;
            }

            while (_current._next != LastAdd)
            {
                _current = _current._next;
            }

            LastAdd = _current;
            _current._next = _current._next._next;
            Length--;


        }

        public void Push(T value)
        {
            _current = _head;
            var previous = new Node<T>(value);
            _head = previous;
            _head._next = _current;
            LastAdd = _head;
            Length++;

        }

        public void AddAt(int index, T value)
        {
            _current = _head;

            while (_headPosition < index - 1)
            {
                _current = _current._next;
                _headPosition++;
            }

            var next = _current._next;
            _current._next = new Node<T>(value) { _next = next };
            Length++;
            LastAdd = _current._next;

            _headPosition = 0;
        }

        public T RemoveAt(int index)
        {
            _current = _head;
           
            while (_headPosition < index - 1)
            {
                _current = _current._next;
                _headPosition++;
            }
            if (_current == _head)
            {
                _head = null;
                Length--;
                return _current._value;
            }
            var removedNode = _current._next;
            _current._next = _current._next._next;
            Length--;
            _headPosition = 0;
            return removedNode._value;
        }

        public T ElementAt(int index)
        {
            
            _current = _head;
            while (_headPosition < index)
            {
                _current = _current._next;
                _headPosition++;
            }

            var currentValue = _current._value;
            _headPosition = 0;
            return currentValue;
        }

        public T Remove()
        {
            _current = _head;
            if (_head._next == null)
            {
                Length--;
                _head = null;
                return _current._value;
            }
            while (_current._next._next != null)
            {
                _current = _current._next;
            }

            var temp = _current._next;
            _current._next = null;
            Length--;

            return temp._value;
        }

        public IEnumerator<T> GetEnumerator()
        {

            _current = _head;
            while (_current != null)
            {
                yield return _current._value;
                _current = _current._next;
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