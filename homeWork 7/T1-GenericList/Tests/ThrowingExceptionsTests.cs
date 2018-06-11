using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericListSource;
using System;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Класс тестов, проверяющий <see cref="GenericList"/> при некорректных условиях вызова
    /// </summary>
    [TestClass]
    public class ThrowingExceptionsTests
    {
        private GenericList<int> _list;
        private IList<int> _readonlyList;

        [TestInitialize]
        public void Init()
        {
            _list = new GenericList<int>();
            _readonlyList = _list.AsReadOnly();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void AlterationByIndexIfListIsReadonly()
        {
            _readonlyList[10] = 10;
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void AddToReadOnlyListShouldThrowException()
        {
            _readonlyList.Add(10);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void ClearReadOnlyListShouldThrowException()
        {
            _readonlyList.Clear();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyToNullArrayShouldThrowException()
        {
            _list.CopyTo(null, -100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyToWithNegativeArrayIndexParamShouldThrowException()
        {
            _list.CopyTo(new int[5], -10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyToBehaviorTest()
        {
            var array = new int[5];
            _list.Add(1);
            _list.Add(2);

            _list.CopyTo(array, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void InsertToReadOnlyListShouldThrowException()
        {
            _readonlyList.Insert(-19, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertionToNegativeIndexShouldThrowException()
        {
            _list.Insert(-1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertionToWrongIndexShouldThrowException()
        {
            var amount = 10;
            for (int i = 0; i < amount; i++)
            {
                _list.Add(i);
            }

            _list.Insert(-1, amount + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void RemoveFromReadOnlyListShouldThrowException()
        {
            _readonlyList.Remove(10);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void RemoveAtReadOnlyListShouldThrowException()
        {
            _readonlyList.RemoveAt(-999);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAtNegativeIndexShouldThrowException()
        {
            _list.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAtWrongIndexShouldThrowException()
        {
            var amount = 10;
            for (int i = 0; i < amount; i++)
            {
                _list.Add(i);
            }

            _list.Insert(-1, amount);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ReceivingItemOnNegativeIndexShouldThrowException()
        {
            var item = _readonlyList[-120];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ReceivingItemOnWrongIndexShouldThrowException()
        {
            var amount = 10;
            for (int i = 0; i < amount; i++)
            {
                _list.Add(i);
            }

            var item = _list[amount];
        }
    }
}