using System;
using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListTests
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void AddedElemntShouldBeEqualToElementAtFirstIndex()
        {
            //arrange
            var list = new LinkedList<int>();
            //act
            list.Add(1);
            //assert
            Assert.AreEqual(list.ElementAt(0), 1);
        }
        [TestMethod]
        public void AddedElementShouldBeBetweenFirstAndSecond()
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
        public void ListLenghtShouldBeEqualFive()
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
        public void RemoveAtShouldReturnValueOfRemovedNode()
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
        public void RemoveShouldDeleteLastElementOfList()
        {
            var list = new LinkedList<int>();
            //act
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Remove();
            //assert
            Assert.AreEqual(list.Length(), 2);
            Assert.ThrowsException<NullReferenceException>(() => list.ElementAt(3));

        }
        [TestMethod]
        public void ElementAtFifthIndexShouldReturnTheFifthElementOfList()
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
