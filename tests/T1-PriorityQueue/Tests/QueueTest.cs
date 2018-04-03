using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueueSource;
using System;

namespace Tests
{
    [TestClass]
    public class QueueTest
    {
        private IQueue<int> _queue;

        [TestInitialize]
        public void Init()
        {
            _queue = new Queue<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(QueueSource.Exceptions.QueueIsEmptyException))]
        public void DequeFromEmptyQueShouldThrowException()
        {
            _queue.Dequeue();
        }

        [TestMethod]
        public void EnqueOneElementBehaviorTest()
        {
            var expected = 10;
            _queue.Enqueue(expected, 1);

            var value = _queue.Dequeue();

            Assert.AreEqual(expected, value);
            Assert.IsTrue(_queue.IsEmpty());
        }

        [TestMethod]
        public void EnqueTwoElementsWithDifferentPriorities()
        {
            var expected = 10;
            _queue.Enqueue(5, 1);
            _queue.Enqueue(expected, -1);

            var value = _queue.Dequeue();

            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void EnqueTwoElementsWithEqualPriorities()
        {
            var expected = 10;
            _queue.Enqueue(expected, 1);
            _queue.Enqueue(5, 1);

            var value = _queue.Dequeue();

            Assert.AreEqual(expected, value);
        }
    }
}
