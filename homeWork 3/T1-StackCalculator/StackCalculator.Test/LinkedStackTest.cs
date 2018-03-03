using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackCalculator.Test
{
    [TestClass]
    public class LinkedStackTest
    {
        private IStack _stack;

        [TestInitialize]
        public void Init()
        {
            _stack = new LinkedStack();
        }

        [TestMethod]
        public void PopFromEmptyStackShouldReturnNull()
        {
            var value = _stack.Pop();

            Assert.IsNull(value);
        }

        [TestMethod]
        public void PeekFromEmptyStackShouldReturnNull()
        {
            var value = _stack.Peek();

            Assert.IsNull(value);
        }

        [TestMethod]
        public void RightBehaviorOfStack()
        {
            for (var i = 0; i <= 100; ++i)
            {
                _stack.Push(i);
            }

            for (var i = 100; i >= 0; --i)
            {
                var result = _stack.Pop();
                Assert.AreEqual(i, result);
            }
        }

        [TestMethod]
        public void RightCountBehavior()
        {
            int expected = 100;
            for (var i = 0; i < 100; ++i)
            {
                _stack.Push(i);
            }

            int actual = _stack.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClearTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                _stack.Push(i);
            }

            int expectedCount = 0;
            _stack.Clear();
            int actualCount = _stack.Count;


            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void EmptyStackShouldBeEmpty()
        {
            for (var i = 0; i < 100; ++i)
            {
                _stack.Push(i);
            }

            _stack.Clear();
            bool isEmpty = _stack.IsEmpty();;

            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void NotEmptyStackShouldBeNotEmpty()
        {
            for (var i = 0; i < 100; ++i)
            {
                _stack.Push(i);
            }

            bool isEmpty = _stack.IsEmpty();;

            Assert.IsFalse(isEmpty);
        }
    }
}