using System;
using System.Collections;
using System.Collections.Generic;

namespace ListSource
{
    public class LinkedList<T> : IList<T>
    {
        private ListNode _head;
        private ListNode _tail;
        private int _count;

        public LinkedList()
        {
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Выход за границы списка");
                }

                var current = _head;
                for (var _ = 0; _ < index; ++_)
                {
                    current = current.Next;
                }

                return current.Value;
            }

            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Выход за границы списка");
                }

                var current = _head;
                for (var _ = 0; _ < index; ++_)
                {
                    current = current.Next;
                }

                current.Value = value;
            }
        }

        public int Count => _count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            var newNode = new ListNode(item, null);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }

            _count++;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var elem in this)
            {
                if (elem.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var elem in this)
            {
                array[arrayIndex] = elem;
                arrayIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator() => new ListEnumerator(_head);

        public int IndexOf(T item)
        {
            int index = 0;
            foreach (var elem in this)
            {
                if (elem.Equals(item))
                {
                    return index;
                }

                index++;
            }

            throw new ItemIsNotInListException("Элемент отсутствует в списке");
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            ListNode previous = null;
            ListNode current = _head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    // если в начале списка
                    if (previous == null)
                    {
                        _head = current.Next;
                        // если единственный элемент списка
                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }
                    else
                    {
                        previous.Next = current.Next;
                        // если в конце списка
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }

                    _count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Выход за границы списка");
            }

            ListNode previous = null;
            ListNode current = _head;

            for (var _ = 0; _ < index; ++_)
            {
                previous = current;
                current = current.Next;
            }

            if (previous == null)
            {
                _head = current.Next;
                // если единственный элемент списка
                if (_head == null)
                {
                    _tail = null;
                }
            }
            else
            {
                previous.Next = current.Next;
                // если в конце списка
                if (current.Next == null)
                {
                    _tail = previous;
                }
            }

            _count--;
        }

        IEnumerator IEnumerable.GetEnumerator() => new ListEnumerator(_head);

        private class ListNode
        {
            public T Value { get; set; }
            public ListNode Next { get; set; }

            public ListNode(T value, ListNode next)
            {
                Value = value;
                Next = next;
            }
        }

        private class ListEnumerator : IEnumerator<T>
        {
            private ListNode _startPosition;
            private ListNode _currentPosition;

            public ListEnumerator(ListNode begin) => _startPosition = begin;

            public T Current => _currentPosition.Value;

            object IEnumerator.Current => _currentPosition.Value;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                // Если список пустой ИЛИ достигнут конец списка
                if (_startPosition == null || (_currentPosition != null && _currentPosition.Next == null))
                {
                    return false;
                }
                // Если обход не начался
                else if (_currentPosition == null)
                {
                    _currentPosition = _startPosition;
                }
                else
                {
                    _currentPosition = _currentPosition.Next;
                }

                return true;
            }

            public void Reset() => _currentPosition = null;
        }
    }
}
