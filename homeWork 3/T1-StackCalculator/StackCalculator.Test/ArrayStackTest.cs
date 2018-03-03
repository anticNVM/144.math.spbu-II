using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackCalculator.Test
{
    [TestClass]
    public class ArrayStackTest
    {
        private IStack _stack;

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
        public void PopFromEmptyStackShouldReturnsNull()
        {
            _stack = new ArrayStack();

            var result = _stack.Pop();

            Assert.IsNull(result);
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
    }
}