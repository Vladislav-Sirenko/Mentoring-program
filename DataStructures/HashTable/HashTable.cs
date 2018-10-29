using System;
using System.ComponentModel;
using System.Data;


namespace DataStructures.HashTable
{
    public class HashTable : IHashTable
    { 
        private HashTableItem[] _array;

        private const int DefaultSize = 3;

        public HashTable()
        {
            _array = new HashTableItem[DefaultSize];
        }

        public int Hash(object key)
        {
            return key.GetHashCode() & 0x7fffffff % 10;
        }
        public bool Contains(object key)
        {
            int index = Hash(key);
            if (IsResizeRequired(index) || _array[index] == null)
            {
                return false;
            }

            return true;
        }

        public void Add(object key, object value)
        {
            int index = Hash(key);
            if (Contains(key))
            {
                throw new DuplicateNameException();
            }

            if (IsResizeRequired(index))
            {
                _array = Resize(index + 1);
            }

            _array[index] = new HashTableItem();
            _array[index].Value = value;
        }

        private bool IsResizeRequired(int index)
        {
            if (index >= _array.Length)
                return true;
            return false;
        }

        private HashTableItem[] Resize(int size)
        {
            HashTableItem[] temp = new HashTableItem[size];
            _array.CopyTo(temp, 0);
            return temp;
        }

        public object this[object key]
        {
            get => IsResizeRequired(Hash(key)) ? null : _array[Hash(key)].Value;
            set
            {
                if (value == null)
                {
                    Remove(key);
                }

                else if (Contains(key))
                {
                    _array[Hash(key)].Value = value;
                }

                else
                {
                    Add(key, value);
                }
            }
        }

        public void Remove(object key)
        {
            if (Contains(key))
            {
                _array[Hash(key)] = null;
            }
        }

        public bool TryGet(object key, out object value)
        {
            int index = Hash(key);
            if (IsResizeRequired(index))
            {
                value = null;
                return false;
            }

            if (!Contains(key))
            {
                value = null;
                return false;
            }

            value = _array[index].Value;
            return true;
        }
        private class HashTableItem
        {
            public object Value { get; set; }
        }
    }
}


