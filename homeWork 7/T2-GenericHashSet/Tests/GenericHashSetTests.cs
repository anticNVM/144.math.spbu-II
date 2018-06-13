using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using GenericHashSetSource;
//using System.Linq;

namespace Tests
{
    [TestClass]
    public class GenericHashSetTests
    {
        private ISet<int> _set;

        [TestInitialize]
        public void Init()
        {
            _set = new GenericHashSet<int>();
        }

        [TestMethod]
        public void AddBehaviorTest()
        {
            var count = 10;
            foreach (var num in Enumerable.Range(0, count))
            {
                _set.Add(num);
            }

            Assert.AreEqual(count, _set.Count);
            foreach (var num in Enumerable.Range(0, count))
            {
                Assert.IsTrue(_set.Contains(num));
            }
        }

        [TestMethod]
        public void ManyNumsAdded()
        {
            var count = 10000;
            foreach (var num in Enumerable.Range(0, count))
            {
                _set.Add(num);
            }

            Assert.AreEqual(count, _set.Count);
            foreach (var num in Enumerable.Range(0, count))
            {
                Assert.IsTrue(_set.Contains(num));
            }
        }

        [TestMethod]
        public void ClearBehaviorTest()
        {
            var count = 10;
            foreach (var num in Enumerable.Range(0, count))
            {
                _set.Add(num);
            }

            _set.Clear();

            Assert.AreEqual(0, _set.Count);
            foreach (var num in Enumerable.Range(0, count))
            {
                Assert.IsFalse(_set.Contains(num));
            }
        }

        [TestMethod]
        public void ContainsBehaviorTest()
        {
            var count = 10;
            foreach (var num in Enumerable.Range(0, count))
            {
                _set.Add(num);
            }

            foreach (var num in Enumerable.Range(0, count))
            {
                Assert.IsTrue(_set.Contains(num));
            }

            foreach (var num in Enumerable.Range(count, count))
            {
                Assert.IsTrue(!_set.Contains(num));
            }
        }

        [TestMethod]
        public void CopyToBehaviorTest()
        {
            var count = 10;
            var array = new int[count];
            foreach (var num in Enumerable.Range(0, count))
            {
                _set.Add(num);
            }

            _set.CopyTo(array, 0);

            foreach (var num in Enumerable.Range(0, count))
            {
                Assert.IsTrue(array.Contains(num));
            }
        }

        [TestMethod]
        public void ExceptWithBehaviorTest()
        {
            var count = 10;
            var list = new List<int>();
            foreach (var num in Enumerable.Range(0, count))
            {
                _set.Add(num);
            }

            foreach (var num in Enumerable.Range(5, count / 2))
            {
                list.Add(num);
            }

            _set.ExceptWith(list);

            foreach (var num in Enumerable.Range(0, count / 2))
            {
                Assert.IsTrue(_set.Contains(num));
            }

            Assert.IsTrue(!_set.Contains(5));
        }

        [TestMethod]
        public void IntersectWithBehaviorTest()
        {
            var count = 10;
            var list = new List<int>();
            foreach (var num in Enumerable.Range(0, count))
            {
                _set.Add(num);
            }

            foreach (var num in Enumerable.Range(0, count / 2))
            {
                list.Add(num);
            }

            _set.IntersectWith(list);

            foreach (var num in Enumerable.Range(count / 2, count / 2))
            {
                Assert.IsTrue(_set.Contains(num));
            }

            Assert.IsTrue(!_set.Contains(0));
        }

        [TestMethod]
        public void IsProperSubsetOfBehaviorTest()
        {
            var count = 10;
            var list = new List<int>();
            foreach (var num in Enumerable.Range(0, count))
            {
                _set.Add(num);
            }

            foreach (var num in Enumerable.Range(0, count / 2))
            {
                list.Add(num);
            }

            _set.IntersectWith(list);

            foreach (var num in Enumerable.Range(count / 2, count / 2))
            {
                Assert.IsTrue(_set.Contains(num));
            }

            Assert.IsTrue(!_set.Contains(0));
        }
    }
}
