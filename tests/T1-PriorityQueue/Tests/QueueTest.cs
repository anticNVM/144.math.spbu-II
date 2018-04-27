using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueueSource;
using System;

namespace Tests
{
    /// <summary>
    /// Класс, тестирующий методы очереди с приоритетом
    /// </summary>
    [TestClass]
    public class QueueTest
    {
        private IQueue<int> _queue;

        [TestInitialize]
        public void Init()
        {
            _queue = new Queue<int>();
        }

        /// <summary>
        /// Попытка получить элемент из пустой очереди
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(QueueSource.Exceptions.QueueIsEmptyException))]
        public void DequeFromEmptyQueShouldThrowException()
        {
            _queue.Dequeue();
        }

        /// <summary>
        /// Корректное поведение очереди при 1 элементе (smoke test)
        /// </summary>
        [TestMethod]
        public void EnqueOneElementBehaviorTest()
        {
            var expected = 10;
            _queue.Enqueue(expected, 1);

            var value = _queue.Dequeue();

            Assert.AreEqual(expected, value);
            Assert.IsTrue(_queue.IsEmpty());
        }

        /// <summary>
        /// Проверка корректной работы для разных приоритетов (должно возвращать наименьший)
        /// </summary>
        [TestMethod]
        public void EnqueTwoElementsWithDifferentPriorities()
        {
            var expected = 10;
            _queue.Enqueue(5, 1);
            _queue.Enqueue(expected, -1);

            var value = _queue.Dequeue();

            Assert.AreEqual(expected, value);
        }

        /// <summary>
        /// Проверка корректности при одинаковых приоритетах (должно вести себя как очередь)
        /// </summary>
        [TestMethod]
        public void EnqueTwoElementsWithEqualPriorities()
        {
            var expected = 10;
            _queue.Enqueue(expected, 1);
            _queue.Enqueue(5, 1);

            var value = _queue.Dequeue();

            Assert.AreEqual(expected, value);
        }

        /// <summary>
        /// Ещё 1 тест, который совмещает 2 предыдущие
        /// </summary>
        [TestMethod]
        public void EnqueThreeElementsWithBehaviorTest()
        {
            var expected = 10;
            _queue.Enqueue(expected, -1);
            _queue.Enqueue(5, 1);
            _queue.Enqueue(0, -1);

            var value = _queue.Dequeue();

            Assert.AreEqual(expected, value);
        }
    }
}
