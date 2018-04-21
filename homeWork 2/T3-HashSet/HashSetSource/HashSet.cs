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
        /// Значение, максимальное для величины заполнения хеш-таблицы
        /// Если фактор больше этой константы, то необхожимо увеличить размер таблицы
        /// </summary>
        private const int _сriticalFactor = 1;

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

        public HashSet()
        {
            _buckets = new Buckets(_defaultCapacity);

            _capacity = _defaultCapacity;
        }

        public void Add(int value)
        {
            int index = GetIndex(value);
            try
            {
                _buckets[index].Append(value);
            }
            catch (ValueAlreadyInListException e)
            {
                throw new ValueIsAlreadyInSetException(
                    $"Значение параметра {nameof(value)} уже существует в множестве.", e
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
            foreach (LinkedListSource.IList list in _buckets)
            {
                list.Clear();
            }
        }

        public bool Contains(int value)
        {
            int index = GetIndex(value);
            return _buckets[index].Contains(value);
        }

        public void Remove(int value)
        {
            int index = GetIndex(value);
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
            foreach (LinkedListSource.IList list in _buckets)
            {
                foreach (int value in list)
                {
                    int index = GetIndex(value);
                    newBuckets[index].Append(value);
                }
            }

            _buckets = newBuckets;
        }

        private int GetIndex(int value) => Math.Abs(value.GetHashCode()) % _capacity;

        /// <summary>
        /// Масиисв списков
        /// </summary>
        private class Buckets : IEnumerable
        {
            private LinkedListSource.IList[] _array;

            public Buckets(int capacity)
            {
                _array = new LinkedListSource.IList[capacity];
                for (var i = 0; i < _array.Length; ++i)
                {
                    _array[i] = new UniqueList();
                }
            }

            public LinkedListSource.IList this[int index] => _array[index];

            public int Length => _array.Length;

            public IEnumerator GetEnumerator() => _array.GetEnumerator();
        }
    }
}
