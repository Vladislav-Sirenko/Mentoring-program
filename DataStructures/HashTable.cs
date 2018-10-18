using System;
using System.Collections.Generic;
using System.Data;
using LinkedList;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Table
{
    public class HashTable :IHashTable
     {
         private LinkedList.LinkedList<KeyValue> _hashtable;
        private class KeyValue 
        {
            public int Key { get; private set; }
            public object Value { get; set; }

            public KeyValue(object key,object value)
            {
                Key = key.GetHashCode();
                Value = value;
            }
        }

         public HashTable()
         {
             _hashtable=new LinkedList.LinkedList<KeyValue>();
         }

        public bool Contains(object key)
        {
            foreach (var pair in _hashtable)
            {

                if (pair.Key.Equals(key.GetHashCode())) { 


                    return true;
                }
        }

            return false;
        }

        public void Add(object key, object value)
        {
            foreach (var pair in _hashtable)
            {
                if (pair.Key.Equals(key.GetHashCode()))
                {
                    throw new DuplicateNameException();
                }
            }

            _hashtable.Add(new KeyValue(key,value));
        }

        public object this[object key]
        {
            get
            {
                TryGet(key, out object value);
                return value;
            }

            set
            {
                if (value == null)
                {
                    int position = 0;
                    
                    foreach(var pair in _hashtable)
                    {
                        if (pair.Key.Equals(key.GetHashCode()))
                        {
                            _hashtable.RemoveAt(position);
                        }
                        position++;
                    }
                    return;
                }

                if (_hashtable.Any(k => k.Key == key.GetHashCode()))
                {
                    _hashtable.First(k => k.Key == key.GetHashCode()).Value = value;
                   
                } ;
                Add(key,value);
            }
        }

        public bool TryGet(object key, out object value)
         {
           foreach (var pair in _hashtable)
            {

                if (pair.Key.Equals(key.GetHashCode()))
                {

                    value = pair.Value;
                    return true;
                }
        }

             value = null;
            throw new NullReferenceException();
        }
    }
}


