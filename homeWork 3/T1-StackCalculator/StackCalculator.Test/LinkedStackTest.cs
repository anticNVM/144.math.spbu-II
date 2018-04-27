using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exceptions;

namespace StackCalculator.Test
{
    /// <summary>
    /// Тесты, проверяющие работоспособность связного стека
    /// </summary>
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
        [ExpectedException(typeof(EmptyStackException))]
        public void PopFromEmptyStackShouldThrowException()
        {
            var value = _stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyStackException))]        
        public void PeekFromEmptyStackShouldThrowException()
        {
            var value = _stack.Peek();
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