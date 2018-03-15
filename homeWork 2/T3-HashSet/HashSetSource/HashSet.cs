using System;
using System.Collections;
using LinkedListSource;
using UniqueListSource;

namespace HashSetSource
{
    /// <summary>
    /// Множество int`ов на основе хеш-таблицы
    /// </summary>
    public class HashSet : IHashSet
    {
        /// <summary>
        /// Размерность таблицы по умолчанию.
        /// </summary>
        private const int _defaultCapacity = 10;

        /// <summary>
        /// Сама хеш-таблица
        /// </summary>
        private Buckets _buckets;

        /// <summary>
        /// Размерность таблицы в данный момент
        /// </summary>
        private int _capacity;

        /// <summary>
        /// Кол-во элементов в множестве
        /// </summary>
        private int _count;

        private Func<int, int> _hashFunc = null;

        public void ChangeHashFunction(Func<int, int> hashFunc) => _hashFunc = hashFunc;

        public HashSet(Func<int, int> hashFunc)
        {
            _buckets = new Buckets(_defaultCapacity);
            _capacity = _defaultCapacity;
            _hashFunc = hashFunc;
        }

        public void Add(int value)
        {
            int index = _hashFunc(value) % _capacity;
            try
            {
                _buckets[index].Append(value);
            }
            catch (ValueAlreadyInListException)
            {
                throw new ValueIsAlreadyInSetException(
                    $"Значение параметра {nameof(value)} уже существует в множестве."
                );
            }

            _count++;

            if (this.Factor > 1)
            {
                this.Resize();
            }
        }

        public void Clear()
        {
            _count = 0;
            foreach (ILinkedList list in _buckets)
            {
                list.Clear();
            }
        }

        public bool Contains(int value)
        {
            int index = _hashFunc(value) % _capacity;
            return _buckets[index].Contains(value);
        }

        public void Remove(int value)
        {
            int index = _hashFunc(value) % _capacity;
            try
            {
                _buckets[index].Remove(value);
            }
            catch (ValueIsNotInListException)
            {
                throw new ValueIsNotInSetException(
                    $"Значение параметра {nameof(value)} отсутствует в множестве."
                );
            }

            _count--;
        }

        public int Count => _count;

        public float Factor => (float)_count / (float)_capacity;

        private void Resize()
        {
            int factor = 2;
            _capacity *= factor;
            var newBuckets = new Buckets(_capacity);
            foreach (ILinkedList list in _buckets)
            {
                foreach (int value in list)
                {
                    int index = Math.Abs(value.GetHashCode()) % _capacity;
                    newBuckets[index].Append(value);
                }
            }

            _buckets = newBuckets;
        }

        /// <summary>
        /// Масиисв списков
        /// </summary>
        private class Buckets : IEnumerable
        {
            private ILinkedList[] _array;

            public Buckets(int capacity)
            {
                _array = new ILinkedList[capacity];
                for (var i = 0; i < _array.Length; ++i)
                {
                    _array[i] = new UniqueList();
                }
            }

            public ILinkedList this[int index] => _array[index];

            public int Length => _array.Length;

            public IEnumerator GetEnumerator() => _array.GetEnumerator();
        }
    }
}
