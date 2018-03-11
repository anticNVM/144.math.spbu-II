using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LinkedListSource;

namespace Tests
{
    [TestClass]
    public class LinkedListTest
    {
        private ILinkedList _list;

        [TestInitialize]
        public void Init()
        {
            _list = new LinkedList();
        }

        [TestMethod]
        public void IndexerWithCorrectIndexesAppendBehaviorCheck()
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

        [TestMethod]
        public void ContainsBehaviorTest()
        {
            int nums = 10;
            for (int i = 0; i < nums; ++i)
            {
                _list.Append(i);
            }

            Assert.IsFalse(_list.Contains(nums));
        }

        [TestMethod]
        public void ClearBehaviorTest()
        {
            int nums = 10;
            for (int i = 0; i < nums; ++i)
            {
                _list.Append(i);
            }

            _list.Clear();

            Assert.IsTrue(_list.IsEmpty());
            for (int i = 0; i < nums; ++i)
            {
                Assert.IsTrue(!_list.Contains(i));
            }
        }

        [TestMethod]
        public void CopyShouldReturnSameList()
        {
            int nums = 10;
            for (int i = 0; i < nums; ++i)
            {
                _list.Append(i);
            }

            var copied = _list.Copy();

            Assert.AreEqual(_list.Count, copied.Count);
            for (int i = 0; i < nums; ++i)
            {
                Assert.AreEqual(_list[i], copied[i]);
            }
        }

        [TestMethod]
        public void GetTailShouldReturnListWithoutHead()
        {
            int nums = 10;
            for (int i = nums - 1; i >= 0; --i)
            {
                _list.AddToBegin(i);
            }

            var tail = _list.GetTail();

            Assert.AreEqual(_list.Count - 1, tail.Count);
            for (int i = 1; i < nums; ++i)
            {
                Assert.AreEqual(_list[i], tail[i - 1]);
            }
        }

        [TestMethod]
        public void CountShoulReturnAmountOfElemnts()
        {
            int nums = 10;
            for (int i = 0; i <= nums; ++i)
            {
                _list.AddToBegin(i);
            }

            _list.Remove(nums);

            Assert.AreEqual(nums, _list.Count);
        }

        [TestMethod]
        public void DoubleForeachBehaviorTest()
        {
            int nums = 10;
            for (int i = 0; i < nums; ++i)
            {
                _list.Append(i);
            }

            int currentVal = 0;
            foreach (var item in _list)
            {
                Assert.AreEqual(currentVal, item);
                currentVal++;
            }

            _list.Clear();
            for (int i = 0; i < nums; ++i)
            {
                _list.AddToBegin(i);
            }

            currentVal = nums - 1;
            foreach (var item in _list)
            {
                Assert.AreEqual(currentVal, item);
                currentVal--;
            }
        }
    }
}