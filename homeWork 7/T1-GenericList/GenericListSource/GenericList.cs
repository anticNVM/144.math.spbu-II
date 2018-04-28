using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericListSource
{
    public class GenericList<T> : IList<T>
    {
        private Node _head;
        private Node _tail;
        private int _count;
        private bool _isReadOnly;

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => _count;

        public bool IsReadOnly => _isReadOnly;

        public void Add(T item)
        {
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
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

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
    }
}
