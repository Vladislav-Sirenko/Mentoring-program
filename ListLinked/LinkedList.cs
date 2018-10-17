using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LinkedList
{
    
    public  class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        public int Length { get; private set; }

        private Node<T> LastAdd { get; set; }
        private Node<T> _current;
        private int _headPosition;

     

        public LinkedList() {  }

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

            
            while (_current._next != null)
            {
                _current = _current._next;
            }

            _current._next = new Node<T>(value);
            Length++;
            LastAdd = _current._next;
            _current = _head;
        }

        public void Pop()
        {
            if (LastAdd == _head)
            {
                var currentNode = _head._next;
                _head = currentNode;
                LastAdd = _head;
                _current = _head;
                return;
            }
            
            while (_current._next != LastAdd)
            {
                _current = _current._next;
            }

            LastAdd = _current;
            _current._next = _current._next._next;
            _current = _head;

        }

        public void Push(T value)
        {
            
            var previous = new Node<T>(value);
            _head = previous;
            _head._next = _current;
            LastAdd = _head;
            _current = _head;
        }

        public void AddAt(int index, T value)
        {
            

            while (_headPosition < index - 1)
            {
                _current = _current._next;
                _headPosition++;
            }

            var next = _current._next;
            _current._next = new Node<T>(value) {_next = next};
            Length++;
            LastAdd = _current._next;
            _current =_head;
            _headPosition = 0;
        }
        
        public T RemoveAt(int index)
        {

            while (_headPosition < index - 1)
            {
                _current = _current._next;
                _headPosition++;
            }

            var removedNode = _current._next;
            _current._next = _current._next._next;
            Length--;
            _current = _head;
            _headPosition = 0;
            return removedNode._value;
        }

        public T ElementAt(int index)
        {
            while (_headPosition < index)
            {
                _current = _current._next;
                _headPosition++;
            }

            var currentValue = _current._value;
            _current = _head;
            return currentValue;
        }

        public T Remove()
        {

            while (_current._next._next != null)
            {
                _current = _current._next;
            }

            var temp = _current._next;
            _current._next = null;
            Length--;
            _current = _head;
            return temp._value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (_current != null)
            {
                yield return _current._value;
                _current = _current._next;
            }

            _current = _head;
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