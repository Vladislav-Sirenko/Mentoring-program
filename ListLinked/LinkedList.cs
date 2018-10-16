using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public  class LinkedList<T> : IEnumerable<T>
    {
        private int position = 0;
        public Node<T> head;


        public void Add(T value)
        {
            if (head == null)
            {
                head = new Node<T>(value);
                return;
            }
            Node<T> current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = new Node<T>(value);

        }

        public void AddAt(int index, T value)
        {
            Node<T> current = head;
            int head_position = 0;
            while (head_position < index - 1)
            {
                current = current.next;
                head_position++;
            }
            var next = current.next;
            current.next = new Node<T>(value);
            current.next.next = next;
        }

        public int Length()
        {
            int length = 1;
            Node<T> current = head;
            while (current.next != null)
            {
                current = current.next;
                length++;
            }
            return length;
        }

        public Node<T> RemoveAt(int index)
        {
            Node<T> current = head;
            int head_position = 0;
            while (head_position < index - 1)
            {
                current = current.next;
                head_position++;
            }
            var removed_node = current.next;
            current.next = current.next.next;
            return removed_node;
        }

        public T ElementAt(int index)
        {
            Node<T> current = head;
            int head_position = 0;
            while (head_position < index)
            {
                current = current.next;
                head_position++;
            }
            return current._value;
        }
        public void Remove()
        {
            Node<T> current = head;

            while (current.next.next != null)
            {
                current = current.next;
            }
            current.next = null;
        }



        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
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