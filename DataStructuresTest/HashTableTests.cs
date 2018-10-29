using System;
using System.Data;
using DataStructures.HashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTableTests
{
    [TestClass]
    public class HashTableTests
    {
        private const string FirstItem = "one"; 
        private const string SecondItem = "zero"; 
            
        [TestMethod]
        public void Add_when_add_one_item_then_should_contain_this_item()
        {
            //arrange
            var hashTable = new HashTable();

            //act
            hashTable.Add(1, 1);

            //assert
            Assert.IsTrue(hashTable.Contains(1));
        }

        [TestMethod]
        public void Setter_tries_to_set_null_then_should_remove_this_element_from_hashTable()
        {
            //arrange
            var hashTable = new HashTable();

            //act
            hashTable[1] = FirstItem;
            hashTable[1] = null;

            //assert
            Assert.IsFalse(hashTable.TryGet(1, out object obj));
        }

        [TestMethod]
        public void Getter_when_set_1_item_then_should_return_value()
        {
            //arrange
            var hashTable = new HashTable();

            //act
            hashTable[1] = FirstItem;

            //assert
            Assert.AreEqual(hashTable[1], FirstItem);
        }

        [TestMethod]
        public void Add_when_add_the_item_by_a_key_which_already_exists_then_should_throw_exeption()
        {
            //arrange
            var hashTable = new HashTable();

            //act
            hashTable.Add(1, FirstItem);

            //assert
            Assert.ThrowsException<DuplicateNameException>(() => hashTable.Add(1, SecondItem));
        }

        [TestMethod]
        public void TryGet_when_get_item_that_not_exists_then_method_should_throw_exception()
        {
            //arrange
            var hashTable = new HashTable();

            //assert
            Assert.IsFalse(hashTable.TryGet(1, out object obj));
        }

        [TestMethod]
        public void Contains_when_add_item_then_method_should_retrurn_true()
        {
            //arrange
            var hashTable = new HashTable();

            //act
            hashTable[0] = SecondItem;
            hashTable.Add(1, FirstItem);
            object obj = new object();
            hashTable.TryGet(1, out obj);

            //assert
            Assert.AreEqual(hashTable.Contains(1), true);
            Assert.AreEqual(obj, FirstItem);
        }

        [TestMethod]
        public void Contains_when_check_item_that_not_exists_then_method_should_retrurn_false()
        {
            //arrange
            var hashTable = new HashTable();

            //act
            hashTable[0] = SecondItem;

            //assert
            Assert.AreEqual(hashTable.Contains(1), false);
        }

        [TestMethod]
        public void Setter_when_add_item_with_index_larger_than_array_size_then_arry_should_be_increased()
        {
            //arrange
            var hashTable = new HashTable();

            //act
            hashTable[5] = SecondItem;

            //assert
            Assert.AreEqual(hashTable[5], SecondItem);
        }

        [TestMethod]
        public void TryGet_when_get_item_with_null_value_than_method_should_throw_exception()
        {
            //arrange
            var hashTable = new HashTable();

            //act
            hashTable[0] = 0;
            hashTable[2] = 2;
            hashTable[2] = null;

            //assert
            Assert.IsFalse(hashTable.TryGet(1, out object obj));
        }

        [TestMethod]
        public void Add_when_add_item_with_index_larger_than_array_size_then_array_should_be_increased()
        {
            //arrange
            var hashTable = new HashTable();

            //act
            hashTable[0] = 0;
            hashTable.Add(5, 5);

            //assert
            Assert.AreEqual(hashTable[5], 5);
        }

        [TestMethod]
        public void Add_when_add_item_with_null_value_and_try_get_item_with_index_larger_than_array_size_than_nothing_should_be_add()
        {
            //arrange
            var hashTable = new HashTable();

            //act
            hashTable[1] = null;

            //assert
            Assert.IsFalse(hashTable.TryGet(5, out object obj));
            Assert.IsNull(obj);
        }
    }
}
