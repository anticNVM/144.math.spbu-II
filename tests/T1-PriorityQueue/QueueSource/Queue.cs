using System;

namespace QueueSource
{
    /// <summary>
    /// Класс, реализующий очередь с приоритом на основе списка
    /// </summary>
    public class Queue<T> : IQueue<T>
    {
        private QueueElement _head;
        private QueueElement _tail;

        public T Dequeue()
        {
            if (_head == null)
            {
                throw new Exceptions.QueueIsEmptyException("Очередь пуста");
            }

            var popItem = _head;
            _head = popItem.Next;
            if (_head == null)
            {
                _tail = null;
            }
            
            return popItem.Item;
        }

        public void Enqueue(T item, int priority)
        {
            var newElem = new QueueElement(item, priority, null);
            if (_head == null)
            {
                _head = newElem;
                _tail = newElem;
            }
            else
            {
                // если наименьший приоритет -> вставляем в начало
                if (_head.Priotity > priority)
                {
                    newElem.Next = _head;
                    _head = newElem;
                    return;
                }

                var current = _head;
                while (priority >= current.Priotity && current.Next != null)
                {
                    current = current.Next;
                }

                // если приоритет наибольший -> добавляем в конец
                if (current.Next == null)
                {
                    _tail.Next = newElem;
                    _tail = newElem;
                }
                // иначе в серединку
                else 
                {
                    newElem.Next = current.Next;
                    current.Next = newElem;
                }
            }
        }
        
        public bool IsEmpty()
        {
            return _head == null;
        }

        /// <summary>
        /// Елемент очереди
        /// </summary>
        private class QueueElement
        {
            public QueueElement(T item, int priotity, QueueElement next)
            {
                this.Item = item;
                this.Priotity = priotity;
                this.Next = next;
            }

            public T Item { get; }
            public int Priotity { get; }
            public QueueElement Next { get; set; }
        }
    }
}
