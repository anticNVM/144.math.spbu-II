using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exceptions;
using LinkedList;
using System;

namespace Tests
{
    [TestClass]
    public class LinkedListTest
    {
        private ILinkedList _list;

        [TestInitialize]
        public void Init()
        {
            _list = new LinkedList.LinkedList();
        }

        [TestMethod]
        public void IndexerWithCorrectIndexesBehaviorCheck()
        {
            int size = 10;
            for (var i = 0; i < size; ++i)
            {
                _list.Append(i);
            }

            for (var i = 0; i < size; ++i)
            {
                Assert.AreEqual(i, _list[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexerWithBiggerThanSizeIndexShouldThrowException()
        {
            int size = 10;
            for (var i = 0; i < size; ++i)
            {
                _list.Append(i);
            }

            var value =_list[size];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexerWithLessThanZeroIndexShouldThrowException()
        {
            int size = 10;
            for (var i = 0; i < size; ++i)
            {
                _list.Append(i);
            }

            var value =_list[-1];
        }

        [TestMethod]
        public void AddToBeginBehaviorCheck()
        {
            int size = 10;
            for (var i = 0; i < size; ++i)
            {
                _list.AddToBegin(i);
            }

            for (var i = 0; i < size; ++i)
            {
                Assert.AreEqual(size - i - 1, _list[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertionWithBiggerThanSizeAfterParamShouldThrowException()
        {
            int size = 10;
            for (var i = 0; i < size; ++i)
            {
                _list.Append(i);
            }

            _list.Insert(10, size);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertionWithLessThanZeroAfterParamShouldThrowException()
        {
            int size = 10;
            for (var i = 0; i < size; ++i)
            {
                _list.Append(i);
            }

            _list.Insert(10, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ValueIsNotInListException))]
        public void RemovingNonExistentValueShouldThrowException()
        {
            int size = 10;
            for (var i = 0; i < size; ++i)
            {
                _list.Append(i);
            }

            _list.Remove(size);
        }

        [TestMethod]
        public void RemovingFromBeginingOfListShouldWorkCorrecrly()
        {
            int size = 10;
            for (var i = 0; i < size; ++i)
            {
                _list.Append(i);
            }

            _list.Remove(0);

            Assert.AreEqual(size - 1, _list.Count);
            Assert.AreEqual(1, _list.GetHead());
        }

        [TestMethod]
        [ExpectedException(typeof(ValueIsNotInListException))]
        public void RemovingFromEmptyListShouldThrowException()
        {
            _list.Clear();

            _list.Remove(10);
        }
    }
}