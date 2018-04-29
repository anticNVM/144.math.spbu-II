using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericListSource
{
    /// <summary>
    /// Implements a generic list <see cref="IList{T}"/>
    /// </summary>
    /// <typeparam name="T">Type of elements in the list</typeparam>
    public class GenericList<T> : IList<T>
    {
        /// <summary>
        /// Reference to the first element of the list
        /// </summary>
        private Node _head;

        /// <summary>
        /// Reference to the last element of the list
        /// </summary>
        private Node _tail;

        /// <summary>
        /// Amount of elements in the list
        /// </summary>
        private int _count;

        /// <summary>
        /// If list is not able to be changed
        /// </summary>
        private bool _isReadOnly;

        public T this[int index]
        {
            get => GetNodeOnIndex(index).Item;
            set
            {
                if (_isReadOnly)
                {
                    throw new NotSupportedException(
                        "Список доступен только для чтения"
                    );
                }

                GetNodeOnIndex(index).Item = value;
            }
        }

        public int Count => _count;

        public bool IsReadOnly => _isReadOnly;

        /// <summary>
        /// Adds item to end of the list
        /// </summary>
        public void Add(T item)
        {
            if (_isReadOnly)
            {
                throw new NotSupportedException(
                    "Список доступен только для чтения"
                );
            }

            if (_head == null)
            {
                _head = new Node(item, null);
                _tail = _head;
            }
            else
            {
                _tail.Next = new Node(item, null);
                _tail = _tail.Next;
            }

            _count++;
        }

        public void Clear()
        {
            if (_isReadOnly)
            {
                throw new NotSupportedException(
                    "Список доступен только для чтения"
                );
            }

            _head = null;
            _tail = null;
            _count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var element in this)
            {
                //https://msdn.microsoft.com/ru-ru/library/bsc2ak47(v=vs.110).aspx
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(
                    "Аргумент array имеет значение null."
                );
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Значение параметра arrayIndex меньше 0."
                );
            }

            if (array.Length - arrayIndex < this._count)
            {
                throw new ArgumentException(
                    "Количество элементов в исходной коллекции больше, чем свободное пространство от arrayIndex до конца массива назначения array."
                );
            }

            var currentIndex = arrayIndex;
            foreach (var element in this)
            {
                array[currentIndex] = element;
                currentIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator(_head);
        }

        public int IndexOf(T item)
        {
            var current = _head;
            for (var i = 0; i < _count; ++i)
            {
                if (current.Item.Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (_isReadOnly)
            {
                throw new NotSupportedException(
                    "Список доступен только для чтения"
                );
            }

            if (index < 0 || index > _count)
            {
                throw new IndexOutOfRangeException(
                    $"{index} не является допустимым индексом"
                );
            }

            if (index == _count)
            {
                this.Add(item);
                return;
            }

            if (index == 0)
            {
                _head = new Node(item, _head);
                _count++;
                return;
            }

            var previous = GetNodeOnIndex(index - 1);
            previous.Next = new Node(item, previous.Next);
            _count++;
        }

        public bool Remove(T item)
        {
            if (_isReadOnly)
            {
                throw new NotSupportedException(
                    "Список доступен только для чтения"
                );
            }

            var index = this.IndexOf(item);
            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (_isReadOnly)
            {
                throw new NotSupportedException(
                    "Список доступен только для чтения"
                );
            }

            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException(
                    $"{index} не является допустимым индексом"
                );
            }

            // если в начале
            if (index == 0)
            {
                _head = _head.Next;
                // если единственный элемент списка
                if (_head == null)
                {
                    _tail = null;
                }
            }
            else
            {
                var previous = GetNodeOnIndex(index - 1);
                previous.Next = previous.Next.Next;
                // если в конце списка
                if (previous.Next.Next == null)
                {
                    _tail = previous;
                }
            }

            _count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListEnumerator(_head);
        }

        private Node GetNodeOnIndex(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException(
                    $"{index} не является допустимым индексом"
                );
            }

            var current = _head;
            for (var i = 0; i < index; ++i)
            {
                current = current.Next;
            }

            return current;
        }

        /// <summary>
        /// Element of the list
        /// </summary>
        private class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }

            public Node(T item, Node next)
            {
                Item = item;
                Next = next;
            }
        }

        /// <summary>
        /// Implements list enumerator <see cref="IEnumerator{T}"/>
        /// </summary>
        private class ListEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// Стартовая позиция обхода
            /// </summary>
            private Node _startPosition;

            /// <summary>
            /// Текущая позиция
            /// </summary>
            private Node _currentPosition;

            public ListEnumerator(Node begin) => _startPosition = begin;

            public T Current => _currentPosition.Item;

            object IEnumerator.Current => _currentPosition.Item;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                //Если список пустой ИЛИ достигнут конец списка
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
