using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericListSource;

namespace Tests
{
    /// <summary>
    /// Класс тестов, проверяющий основную функциональность класса 
    /// <see cref="GenericList"/> для целочисленных значений <see langword="int"/>
    /// </summary>
    [TestClass]
    public class IntListTests
    {
        private GenericList<int> _list;

        [TestInitialize]
        public void Init()
        {
            _list = new GenericList<int>();
        }

        [TestMethod]
        public void AddToEmptyListBehaviorTest()
        {
            _list.Add(10);
            Assert.AreEqual(1, _list.Count);
            Assert.AreEqual(10, _list[0]);
        }

        [TestMethod]
        public void AddSomeElementsToListBehaviorTest()
        {
            var amount = 10;
            for (int i = 0; i < amount; ++i)
            {
                _list.Add(i);
            }

            Assert.AreEqual(amount, _list.Count);
            var value = 0;
            foreach (var elem in _list)
            {
                Assert.AreEqual(value, elem);
                value++;
            }
        }

        [TestMethod]
        public void ClearListBehaviorTest()
        {
            var amount = 10;
            for (int i = 0; i < amount; ++i)
            {
                _list.Add(i);
            }
            _list.Clear();

            Assert.AreEqual(0, _list.Count);
        }
        
        [TestMethod]
        public void ContainsShouldReturnTrueIfItemExists()
        {
            var item = 10;
            _list.Add(item);
            
            Assert.IsTrue(_list.Contains(item));
        }

        [TestMethod]
        public void ContainsShouldReturnFalseIfItemNotExists()
        {
            var item = 10;
            _list.Add(item);
            
            Assert.IsFalse(_list.Contains(item - 1));
        }

        [TestMethod]
        public void CopyToBehaviorTest()
        {
            var amount = 10;
            var array = new int[amount];
            for (int i = 0; i < amount; ++i)
            {
                _list.Add(i);
            }

            _list.CopyTo(array, 0);

            var value = 0;
            foreach (var elem in array)
            {
                Assert.AreEqual(value, elem);
                value++;
            }
        }

        [TestMethod]
        public void CopyToRightIndexesTest()
        {
            var array = new int[5];
            _list.Add(1);
            _list.Add(2);

            _list.CopyTo(array, 3);
        }

        [TestMethod]
        public void IndexOfShouldReturnIndexOfFirstItem()
        {
            var item = 5;
            var expexted = 0;

            _list.Add(item);

            Assert.AreEqual(expexted, _list.IndexOf(item));
        }

        [TestMethod]
        public void IndexOfShouldReturnMinus1IfItemNotExists()
        {
            var item = 5;
            var expexted = -1;

            _list.Add(item);

            Assert.AreEqual(expexted, _list.IndexOf(item - 1));
        }

        [TestMethod]
        public void InsertAtCountIndexShoulsAddItemAtEnd()
        {
            var amount = 10;
            for (int i = 0; i < amount; ++i)
            {
                _list.Add(i);
            }
            
            var item = 11;
            _list.Insert(amount, item);

            Assert.AreEqual(amount + 1, _list.Count);
            Assert.AreEqual(item, _list[amount]);
        }

        [TestMethod]
        public void InsertAtBeginInNotEmptyList()
        {
            _list.Add(1);
            var item = 2;
            _list.Insert(0, item);

            Assert.AreEqual(item, _list[0]);
            Assert.AreEqual(2, _list.Count);
        }

        [TestMethod]
        public void InsertAtBeginInEmptyList()
        {
            var item = 1;
            _list.Insert(0, item);

            Assert.AreEqual(item, _list[0]);
            Assert.AreEqual(1, _list.Count);
        }

        [TestMethod]
        public void RemoveNonExistingItemShouldReturnFalse()
        {
            var amount = 10;
            for (int i = 0; i < amount; ++i)
            {
                _list.Add(i);
            }
            
            var item = 11;
            var success = _list.Remove(item);

            Assert.AreEqual(false, success);
        }

        [TestMethod]
        public void RemoveAt0Index()
        {
            var amount = 10;
            for (int i = 0; i < amount; ++i)
            {
                _list.Add(i);
            }
            
            _list.RemoveAt(0);

            Assert.AreEqual(amount - 1, _list.Count);
            Assert.AreEqual(1, _list[0]);
        }

        [TestMethod]
        public void RemoveAtIfListHasSingleElement()
        {
            var item = 10;
            _list.Add(item);
            _list.RemoveAt(0);

            Assert.AreEqual(0, _list.Count);
        }

        [TestMethod]
        public void RemoveAtMiddleOfTheList()
        {
            var amount = 10;
            for (int i = 0; i < amount; ++i)
            {
                _list.Add(i);
            }
            
            _list.RemoveAt(amount / 2);

            Assert.AreEqual(amount - 1, _list.Count);
            Assert.AreEqual(amount / 2 + 1, _list[amount / 2]);
        }

        [TestMethod]
        public void RemoveAtLastIndex()
        {
            var amount = 10;
            for (int i = 0; i < amount; ++i)
            {
                _list.Add(i);
            }
            
            _list.RemoveAt(amount - 1);

            Assert.AreEqual(amount - 1, _list.Count);
            Assert.AreEqual(amount - 2, _list[amount - 2]);
        }

        [TestMethod]
        public void AsReadOnlyShouldBeAWrapperOfList()
        {
            var readonlyList = _list.AsReadOnly();
            var amount = 10;
            for (int i = 0; i < amount; ++i)
            {
                _list.Add(i);
            }

            Assert.AreEqual(amount, readonlyList.Count);
            var value = 0;
            foreach (var elem in readonlyList)
            {
                Assert.AreEqual(value, elem);
                value++;
            }
        }

        [TestMethod]
        public void CheckingPossibilityToGetItemsByIndex()
        {
            var amount = 10;
            for (int i = 0; i < amount; ++i)
            {
                _list.Add(i);
            }

            for (int i = 0; i < amount; i++)
            {
                Assert.AreEqual(i, _list[i]);
            }
        }

        [TestMethod]
        public void CheckingPossibilityToChangeTheLastItemByIndex()
        {
            var amount = 10;
            for (int i = 0; i < amount; ++i)
            {
                _list.Add(i);
            }

            _list[amount - 1] = amount;

            Assert.AreEqual(amount, _list[amount - 1]);
        }
    }
}
