using System;
using System.Collections.Generic;
using System.Data;
using LinkedList;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Table
{
    public class HashTable : IHashTable
    {
        private object[] _array;
        public int Length => _array.Length;


        public HashTable()
        {
            _array = new object[3];
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
            if (index > _array.Length - 1)
            {
                object[] temp = new object[index + 1];
                for (int i = 0; i <= _array.Length - 1; i++)
                {
                    temp[i] = _array[i];
                }

                _array = temp;
            }

            if (_array[index] != null)
            {
                throw new DuplicateNameException();
            }

            _array[index] = value;
        }

        public object this[object key]
        {
            get => _array[Hash(key)];

            set
            {
                int index = Hash(key);
                if (index > _array.Length - 1)
                {
                    object[] temp = new object[index + 1];
                    for (int i = 0; i <= _array.Length - 1; i++)
                    {
                        temp[i] = _array[i];
                    }

                    _array = temp;
                    if (value == null)
                    {
                        _array[index] = null;
                        return;
                    }
                }

                _array[index] = value;             
            }
        }

        public bool TryGet(object key, out object value)
        {
            int index = Hash(key);
            if (_array[index]==null)
            {
                throw new NullReferenceException();
            }

            value = _array[index];
            return true;
        }
    }
}


