using System;
using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListTests
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void Add_when_add_one_item_then_should_be_equal_to_element_with_zero_index()
        {
            //arrange
            var list = new LinkedList<int>();
            //act
            list.Add(1);
            //assert
            Assert.AreEqual(list.ElementAt(0), 1);
        }
        [TestMethod]
        public void AddAt_when_add_new_item_then_item_index_should_be_between_previous_and_next()
        {
            //arrange
            var list = new LinkedList<int>();
            //act
            list.Add(1);
            list.Add(3);
            list.AddAt(1, 2);
            //assert
            Assert.AreEqual(list.ElementAt(1), 2);
        }
        [TestMethod]
        public void Lenght_when_add_five_items_then_lenght_should_be_equal_five()
        {
            //arrange
            var list = new LinkedList<int>();
            //act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //assert
            Assert.AreEqual(list.Length(), 5);
        }
        [TestMethod]
        public void RemoveAt_when_remove_then_method_should_return_removedItem()
        {
            var list = new LinkedList<int>();
            //act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //assert
            Assert.AreEqual(list.RemoveAt(4), 5);
        }
        [TestMethod]
        public void Remove_when_delete_item_then_should_return_last_item_of_list()
        {
            var list = new LinkedList<int>();
            //act
            list.Add(0);
            list.Add(1);
            list.Add(2);         
            //assert
            Assert.AreEqual(list.Remove(),2);
            Assert.AreEqual(list.Length(), 2);
            Assert.ThrowsException<NullReferenceException>(() => list.ElementAt(3));
            

        }
        [TestMethod]
        public void ElementAt_when_get_item_with_5_index_then_should_return_value_of_element_that_is_fifth_in_list()
        {
            var list = new LinkedList<int>();
            //act
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //assert
            Assert.AreEqual(list.ElementAt(5), 5);

        }
    }
}
