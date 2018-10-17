using System;
using System.Data;
using Hash_Table;
using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTableTests
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void Add_when_add_one_item_then_should_contain_this_item()
        {
            //arrange
            var hashTable = new HashTable();

            //act
            hashTable.Add(1,1);

            //assert
            Assert.IsTrue(hashTable.Contains(1));
        }

        [TestMethod]
        public void Setter_tries_to_set_null_then_should_remove_this_element_from_hashTable()
        {
            //arrange
            var hashTable = new HashTable();
            //act
            hashTable[1] = "one";
            hashTable[1] = null;

            //assert
            Assert.ThrowsException<NullReferenceException>(() => hashTable.TryGet(1, out object obj));
        }

        [TestMethod]
        public void Getter_when_set_1_item_then_should_return_value()
        {
            //arrange
            var hashTable = new HashTable();
            //act
            hashTable[1] = "one";
            

            //assert
            Assert.AreEqual(hashTable[1],"one");
        }

        [TestMethod]
        public void Add_when_add_the_item_by_a_key_which_already_exists_then_should_throw_exeption()
        {
            //arrange
            var hashTable = new HashTable();
            //act
            hashTable.Add(1,"one");
            //assert
            Assert.ThrowsException<DuplicateNameException>(()=> hashTable.Add(1, "two"));
        }
        [TestMethod]
        public void TryGet_when_get_item_that_not_exists_then_method_should_throw_exception()
        {
            //arrange
            var hashTable = new HashTable();
            //act
            //assert
            Assert.ThrowsException<NullReferenceException>(() => hashTable.TryGet(1, out object obj));
        }

    }
}
