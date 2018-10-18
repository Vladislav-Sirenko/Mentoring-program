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
            var list = new LinkedList<int> {1};

            //act

            //assert
            Assert.AreEqual(list.ElementAt(0), 1);
        }

        [TestMethod]
        public void AddAt_when_add_new_item_then_item_index_should_be_between_previous_and_next()
        {
            //arrange
            var list = new LinkedList<int>();
            AddMany(list, 1, 3);

            //act
            list.AddAt(1, 2);
            
            //assert
            Assert.AreEqual(list.ElementAt(1), 2);
        }

        [TestMethod]
        public void Lenght_when_add_five_items_then_lenght_should_be_equal_five()
        {
            //arrange
            var list = new LinkedList<int>();
            AddMany(list, 1, 2, 3, 4, 5);
            
            //assert
            Assert.AreEqual(list.Length, 5);
        }

        [TestMethod]
        public void RemoveAt_when_remove_then_method_should_return_removedItem()
        {
            //arrange
            var list = new LinkedList<int>();
            AddMany(list, 1, 2, 3, 4, 5);

            //act
            int removed = list.RemoveAt(4);

            //assert
            Assert.AreEqual(removed, 5);
        }

        [TestMethod]
        public void Remove_when_delete_item_then_should_return_last_item_of_list()
        {
            //arrange
            var list = new LinkedList<int>();
            AddMany(list, 0, 1, 2);

            //act
            int removed = list.Remove();

            //assert
            Assert.AreEqual(removed, 2);
            Assert.AreEqual(list.Length, 2);
            Assert.ThrowsException<NullReferenceException>(() => list.ElementAt(3));
        }

        [TestMethod]
        public void ElementAt_when_get_item_with_5_index_then_should_return_value_of_element_that_is_fifth_in_list()
        {
            var list = new LinkedList<int>();
            
            //act
            AddMany(list, 1, 2, 3, 4, 5);

            //assert
            var last = list.ElementAt(list.Length - 1);
            Assert.AreEqual(last, 5);

        }

        [TestMethod]
        public void Pop_when_add_item_with_2_index_then_should_delete_last_add_element()
        {
            var list = new LinkedList<int>();

            //act
            AddMany(list, 1, 2, 3, 4, 5);
            list.AddAt(2,100);
            list.Pop();
            //assert
            
            Assert.AreEqual(list.ElementAt(2), 3);

        }

        [TestMethod]
        public void Push_when_add_item_then_should_add_item_at_top_of_list()
        {
            var list = new LinkedList<int>();

            //act
            AddMany(list, 1, 2, 3, 4, 5);
            list.Push(25);
            //assert

            Assert.AreEqual(list.ElementAt(0), 25);

        }

        [TestMethod]
        public void Pop_when_push_item_then_should_delete_head_element()
        {
            var list = new LinkedList<int>();

            //act
            AddMany(list, 1, 2, 3, 4, 5);
            list.Push(100);
            list.Pop();
            //assert

            Assert.AreEqual(list.ElementAt(0), 1);

        }

        [TestMethod]
        public void Pop_when_call_2_times_then_should_delete_2_head_elements()
        {
            var list = new LinkedList<int>();

            //act
            AddMany(list, 1, 2, 3, 4, 5);
            list.Push(0);
            list.Pop();
            list.Pop();
            
            //assert

            Assert.AreEqual(list.ElementAt(0), 2);

        }

        [TestMethod]
        public void Add_when_add_3_elements_then_delete_3_elements_then_add_again()
        {
            var list = new LinkedList<int>();


            //act

            AddMany(list, 1, 2, 3);
            list.Remove();
            list.Remove();
            list.Remove();
            AddMany(list, 1, 2, 3);

            //assert

            Assert.AreEqual(list.ElementAt(0),1);
            Assert.AreEqual(list.ElementAt(1),2);
            Assert.AreEqual(list.ElementAt(2),3);

        }

        private void AddMany<T>(LinkedList<T> list, params T[] items)
        {
            foreach (var item in items)
                list.Add(item);
        }
    }
}
