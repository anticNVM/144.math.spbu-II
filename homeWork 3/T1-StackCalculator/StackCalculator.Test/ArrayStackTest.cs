using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exceptions;

namespace StackCalculator.Test
{
    /// <summary>
    /// Тесты, проверяющие работоспособность стека на массиве
    /// </summary>
    [TestClass]
    public class ArrayStackTest
    {
        private IStack _stack;

        [TestInitialize]
        public void Init()
        {
            _stack = new ArrayStack();
        }

        [TestMethod]
        public void StackResizingTest()
        {
            _stack = new ArrayStack(2);

            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);

            Assert.AreEqual(3, _stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyStackException))]        
        public void PopFromEmptyStackShouldThrowException()
        {
            var result = _stack.Pop();
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
            _stack = new ArrayStack();

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