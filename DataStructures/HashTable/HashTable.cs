using System;
using System.Data;


namespace DataStructures.HashTable
{
    public class HashTable : IHashTable
    {
        private object[] _array;

        private const int _defaultSize = 3;

        public HashTable()
        {
            _array = new object[_defaultSize];
        }

        public int Hash(object key)
        {
            return key.GetHashCode() & 0x7fffffff % 10;
        }
        public bool Contains(object key)
        {
            if (_array[Hash(key)] == null)
            {
                return false;
            }

            return true;
        }

        public void Add(object key, object value)
        {
            int index = Hash(key);
            if (index <= _array.Length - 1 && _array[index] != null)
            {
                throw new DuplicateNameException();
            }

            if (index > _array.Length - 1)
            {
                Copy(out _array, index);
            }

            _array[index] = value;
        }

        public void Copy(out object[] array, int index)
        {
            object[] temp = new object[index + 1];
            _array.CopyTo(temp, 0);
            array = temp;
        }

        public object this[object key]
        {
            get => _array[Hash(key)];

            set
            {
                int index = Hash(key);
                if (index > _array.Length - 1)
                {
                    if (value == null)
                    {
                        return;
                    }

                    Copy(out _array, index);
                }

                _array[index] = value;
            }
        }

        public bool TryGet(object key, out object value)
        {
            int index = Hash(key);
            if (index > _array.Length - 1)
            {
                value = null;
                return false;
            }

            if (_array[index] == null)
            {
                throw new NullReferenceException();
            }

            value = _array[index];
            return true;
        }
    }
}


