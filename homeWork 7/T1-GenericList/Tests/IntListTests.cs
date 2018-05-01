using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericListSource;

namespace Tests
{
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
    }
}
