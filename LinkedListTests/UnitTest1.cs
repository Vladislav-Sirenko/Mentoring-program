using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddedElemntShouldBeEqualToElementAtFirstIndex()
        {
            //arrange
         LinkedList<int>  list  = new LinkedList<int>();
            //act
            list.Add(1);
            //assert
            Assert.AreEqual(list.ElementAt(0),1);
        }
        [TestMethod]
        public void AddedElementShouldBeBetweenFirstAndSecond()
        {
            //arrange
            LinkedList<int> list = new LinkedList<int>();
            //act
            list.Add(1);
            list.Add(3);
            list.AddAt(1,2);
            //assert
            Assert.AreEqual(list.ElementAt(1), 2);
        }
        [TestMethod]
        public void ListLenghtShouldBeEqualFive()
        {
            //arrange
            LinkedList<int> list = new LinkedList<int>();
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
            LinkedList<int> list = new LinkedList<int>();
            //act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //assert
            Assert.AreEqual(list.RemoveAt(4)._value,5);
        }
        [TestMethod]
        public void RemoveShouldDeleteLastElementOfList()
        {
            LinkedList<int> list = new LinkedList<int>();
            //act
            list.Add(1);
            list.Add(2);
            list.Remove();
            //assert
            Assert.IsNull(list.head.next);

        }
        [TestMethod]
        public void ElementAtFifthIndexShouldReturnTheFifthElementOfList()
        {
            LinkedList<int> list = new LinkedList<int>();
            //act
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //assert
            Assert.AreEqual(list.ElementAt(5),5);

        }
    }
}
