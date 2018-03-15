using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HashSetSource;

namespace Tests
{
    [TestClass]
    public class HashSetTest
    {
        private IHashSet _set;

        [TestInitialize]
        public void Init()
        {
            _set = new HashSet(x => Math.Abs(x));
        }

        [TestMethod]
        public void NegativeNumbersShouldNotCrash() => _set.Add(-100);

        [TestMethod]
        [ExpectedException(typeof(ValueIsAlreadyInSetException))]
        public void AddExistedValueShouldThrowException()
        {
            _set.Add(20);
            _set.Add(20);
        }

        [TestMethod]
        public void ResizingHashTableBehaviorTest()
        {
            // такой себе тест
            int value = 0;
            while (value <= 10)
            {
                _set.Add(value);
                value++;
            }

            Assert.IsTrue(_set.Factor < 1);
        }

        [TestMethod]
        public void ManyDataStressTest()
        {
            int count = -10000;
            for (var i = count; i <= Math.Abs(count); ++i)
            {
                _set.Add(i);
            }

            for (var i = count; i <= Math.Abs(count); ++i)
            {
                Assert.IsTrue(_set.Contains(i));
            }            
        }

        [TestMethod]
        public void ClearBehaviorTest()
        {
            int nums = -10;
            for (var i = nums; i <= Math.Abs(nums); ++i)
            {
                _set.Add(i);
            }

            _set.Clear();
            Assert.IsTrue(_set.Count == 0);
            for (var i = nums; i <= Math.Abs(nums); ++i)
            {
                Assert.IsFalse(_set.Contains(i));
            }
        }

        [TestMethod]
        public void ValueAfterRemovingShouldNotExist()
        {
            int value = 10;
            _set.Add(value);
            _set.Remove(value);

            Assert.IsTrue(!_set.Contains(value));
        }

        [TestMethod]
        [ExpectedException(typeof(ValueIsNotInSetException))]
        public void RemovingNotExistedValueShouldThrowException()
        {
            int nums = 10;
            for (var i = 0; i < nums; ++i)
            {
                _set.Add(i);
            }

            _set.Remove(nums);
        }

        [TestMethod]
        public void CountBehaviorTest()
        {
            int nums = 10000;
            for (var i = 0; i < nums; ++i)
            {
                _set.Add(i);
            }

            var actual = _set.Count;

            Assert.AreEqual(nums, actual);
        }
    }
}