using System;
using System.Collections;

namespace LinkedListSource
{
    /// <summary>
    /// Связный список
    /// </summary>
    public class LinkedList : ILinkedList
    {
        /// <summary>
        /// Голова списка
        /// </summary>
        private Node _head;

        /// <summary>
        /// Конец списка
        /// </summary>
        private Node _tail;

        public int this[int index]
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
        }

        public virtual void Append(int value)
        {
            var newNode = new Node(value, null);
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

            Count++;
        }

        public virtual void AddToBegin(int value)
        {
            if (_head == null)
            {
                this.Append(value);
            }
            else
            {
                _head = new Node(value, _head);
                Count++;
            }
        }

        public virtual void Insert(int value, int after)
        {
            if (after < 0 || after >= Count)
            {
                throw new IndexOutOfRangeException("Выход за границы списка");
            }

            if (after == (Count - 1))
            {
                this.Append(value);
            }
            else
            {
                Node current = _head;
                int currentIndex = 0;

                while (currentIndex != after)
                {
                    current = current.Next;
                    currentIndex++;
                }

                current.Next = new Node(value, current.Next);
                Count++;
            }
        }

        public void Remove(int value)
        {
            Node previous = null;
            Node current = _head;

            while (current != null)
            {
                if (current.Value.Equals(value))
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

                    Count--;
                    return;
                }

                previous = current;
                current = current.Next;
            }

            throw new ValueIsNotInListException(
                String.Format($"Значения параметра {nameof(value)} не существует в списке")
            );
        }

        public bool Contains(int value)
        {
            Node current = _head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool IsEmpty() => Count == 0;

        public ILinkedList Copy()
        {
            var copyList = new LinkedList();
            Node current = _head;

            while (current != null)
            {
                copyList.Append(current.Value);
                current = current.Next;
            }

            return copyList;
        }

        public int GetHead() => _head != null ? _head.Value : default(int);

        public ILinkedList GetTail()
        {
            var tailList = this.Copy() as LinkedList;
            if (!tailList.IsEmpty())
            {
                tailList._head = _head.Next;
                tailList.Count--;
            }

            return tailList;
        }

        public int Count { get; private set; }

        public override string ToString()
        {
            string list = "[";

            Node current = _head;
            while (current != null)
            {
                list += $"{current.Value}, ";
                current = current.Next;
            }

            list += "]";
            return list;
        }

        public IEnumerator GetEnumerator() => new ListEnumerator(_head);

        /// <summary>
        /// Узел списка
        /// </summary>
        private class Node
        {
            public int Value { get; }
            public Node Next { get; set; }

            public Node(int value, Node next)
            {
                Value = value;
                Next = next;
            }
        }

        /// <summary>
        /// Энумератор для итерации по списку циклом <see langword="foreach"/>
        /// </summary>
        private class ListEnumerator : IEnumerator
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

            public object Current => _currentPosition.Value;

            public void Reset() => _currentPosition = null;
        }
    }
}