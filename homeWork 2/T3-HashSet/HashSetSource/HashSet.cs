using System;
using System.Collections;
using LinkedListSource;
using UniqueListSource;

namespace HashSetSource
{
    public class HashSet : IHashSet
    {
        /// <summary>
        /// Размерность таблицы по умолчанию.
        /// </summary>
        private const int _defaultCapacity = 10;

        private ILinkedList[] _buckets;

        private int _capacity;

        private int _count;

        public HashSet()
        {
            _buckets = new ILinkedList[_defaultCapacity];
            for (var i = 0; i < _buckets.Length; ++i)
            {
                _buckets[i] = new UniqueList();
            }

            _capacity = _defaultCapacity;
        }

        public void Add(int value)
        {
            int index = Math.Abs(value.GetHashCode()) % _capacity;
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
            foreach (var list in _buckets)
            {
                list.Clear();
            }
        }

        public bool Contains(int value)
        {
            int index = Math.Abs(value.GetHashCode()) % _capacity;
            return _buckets[index].Contains(value);
        }

        public void Remove(int value)
        {
            int index = Math.Abs(value.GetHashCode()) % _capacity;
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
        }

        public int Count => _count;

        public float Factor => (float)_count / (float)_capacity;

        private void Resize()
        {
            int factor = 2;
            _capacity *= factor;
            var newBuckets = new ILinkedList[_capacity];
            for (var i = 0; i < _buckets.Length; ++i)
            {
                newBuckets[i] = new UniqueList();
            }

            foreach (var list in _buckets)
            {
                foreach (int value in list)
                {
                    int index = Math.Abs(value.GetHashCode()) % _capacity;
                    newBuckets[index].Append(value);
                }
            }

            _buckets = newBuckets;
        }
    }
}
