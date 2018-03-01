using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackCalculator.Test
{
    [TestClass]
    public class ArrayStackTest
    {
        private static ArrayStack _stack;

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

            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            var value1 = _stack.Pop();
            var value2 = _stack.Pop();
            var value3 = _stack.Pop();

            Assert.AreEqual(3, value1);
            Assert.AreEqual(2, value2);
            Assert.AreEqual(1, value3);
        }
    }
}