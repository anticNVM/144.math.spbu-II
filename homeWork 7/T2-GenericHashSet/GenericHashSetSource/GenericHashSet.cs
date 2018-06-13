using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericHashSetSource
{
    public class GenericHashSet<T> : ISet<T>
    {
        private const int _defaultCapacity = 20;
        private const float _criticalFactor = 1f;

        private List<T>[] _buckets;

        private int _capacity;

        private int _count;

        private bool _isReadonly;

        public GenericHashSet()
        {
            _buckets = InitBuckets(_defaultCapacity);
            _capacity = _defaultCapacity;
        }

        // можно без this, нужно копировать из норм конструкторы, он сам все сделает?
        public GenericHashSet(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                this.Add(item);
            }
        }

        private List<T>[] InitBuckets(int capacity)
        {
            var buckets = new List<T>[capacity];
            for (var i = 0; i < _buckets.Length; ++i)
            {
                buckets[i] = new List<T>();
            }

            return buckets;
        }

        /// <summary>
        /// Получает число элементов, содержащихся в интерфейсе <see cref="ICollection"/>.
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Получает значение, указывающее, является ли объект <see cref="ICollection"/> доступным только для чтения.
        /// </summary>
        public bool IsReadOnly => _isReadonly;

        private float Factor => _count / _capacity;

        /// <summary>
        /// Добавляет элемент в текущий набор и возвращает значение, 
        /// указывающее, что элемент был добавлен успешно.
        /// </summary>
        /// <param name="item">Добавляемое значение</param>
        /// <returns>.true если добавление прошло успешно, .false иначе</returns>
        public bool Add(T item)
        {
            if (_isReadonly)
            {
                throw new NotSupportedException("Объект ICollection<T> доступен только для чтения.");
            }

            var index = GetHashOf(item);
            if (_buckets[index].Contains(item))
            {
                return false;
            }

            _buckets[index].Add(item);
            _count++;
            if (Factor > _criticalFactor)
            {
                this.Resize();
            }

            return true;
        }

        private void Resize()
        {
            int factor = 2;
            _capacity *= factor;
            var newBuckets = InitBuckets(_capacity);
            foreach (var item in this)
            {
                int index = GetHashOf(item);
                newBuckets[index].Add(item);
            }

            _buckets = newBuckets;
        }

        /// <summary>
        /// Удаляет все элементы из коллекции <see cref="ICollection"/>
        /// </summary>
        public void Clear()
        {
            if (_isReadonly)
            {
                throw new NotSupportedException("Объект ICollection<T> доступен только для чтения.");
            }

            _buckets = InitBuckets(_defaultCapacity);
            _capacity = _defaultCapacity;
            _count = 0;
        }

        /// <summary>
        /// Определяет, содержит ли коллекция <see cref="ICollection"/> указанное значение.
        /// </summary>
        /// <param name="item">Значение для проверки</param>
        /// <returns>.true если содержит, .false иначе</returns>
        public bool Contains(T item)
        {
            var index = GetHashOf(item);
            return _buckets[index].Contains(item);
        }

        /// <summary>
        /// Копирует элементы коллекции ICollection<T> в массив Array, начиная с указанного индекса массива Array.
        /// </summary>
        /// <param name="array">Одномерный массив Array, в который копируются элементы из интерфейса ICollection<T>. 
        /// Массив Array должен иметь индексацию, начинающуюся с нуля.</param>
        /// <param name="arrayIndex">Отсчитываемый от нуля индекс в массиве array, указывающий начало копирования.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(
                    $"Аргумент {nameof(array)} имеет значение {null}."
                );
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(
                    $"Значение параметра {nameof(arrayIndex)} меньше 0."
                );
            }

            if (array.Length - arrayIndex < this._count)
            {
                throw new ArgumentException(
                    "Количество элементов в исходной коллекции больше, " +
                    $"чем свободное пространство от {nameof(arrayIndex)} до конца массива назначения {nameof(array)}."
                );
            }

            var currentIndex = arrayIndex;
            foreach (var item in this)
            {
                array[currentIndex] = item;
                currentIndex++;
            }
        }

        /// <summary>
        /// Удаляет все элементы указанной коллекции из текущего набора.
        /// </summary>
        /// <param name="other">Коллекция элементов, которые нужно удалить из набора.</param>
        public void ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Свойство other имеет значение null.");
            }

            foreach (var item in other)
            {
                this.Remove(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var bucket in _buckets)
            {
                foreach (var item in bucket)
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Изменяет текущий набор, чтобы он содержал только элементы, которые также имеются в заданной коллекции.
        /// </summary>
        /// <param name="other">Коллекция для сравнения с текущим набором.</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Свойство other имеет значение null.");
            }

            var included = other.Where(item => this.Contains(item));
            this.Clear();
            foreach (var item in included)
            {
                this.Add(item);
            }
        }

        private (int covering, int otherSize) GetInfoAbout(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Свойство other имеет значение null.");
            }

            int covering = 0;
            int otherSize = 0;
            foreach (var item in other)
            {
                if (this.Contains(item))
                {
                    covering++;
                }

                otherSize++;
            }

            return (covering, otherSize);
        }

        /// <summary>
        /// Определяет, является ли текущий набор должным (строгим) подмножеством заданной коллекции.
        /// </summary>
        /// <param name="other">Коллекция для сравнения с текущим набором.</param>
        /// <returns>Значение true, если текущий набор является строгим подмножеством объекта other; в противном случае — значение false.</returns>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            var info = GetInfoAbout(other);
            return info.covering == _count && info.otherSize > _count;
        }

        /// <summary>
        /// Определяет, является ли текущий набор должным (строгим) надмножеством заданной коллекции.
        /// </summary>
        /// <param name="other">Коллекция для сравнения с текущим набором.</param>
        /// <returns>Значение true, если текущий набор является строгим надмножеством объекта other; в противном случае — значение false.</returns>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            var info = GetInfoAbout(other);
            return info.covering == info.otherSize && info.otherSize < _count;
        }

        /// <summary>
        /// Определяет, является ли набор подмножеством заданной коллекции.
        /// </summary>
        /// <param name="other">Коллекция для сравнения с текущим набором.</param>
        /// <returns>Значение true, если текущий набор является подмножеством объекта other; в противном случае — значение false.</returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            var info = GetInfoAbout(other);
            return info.covering == _count && info.otherSize >= _count;
        }

        /// <summary>
        /// Определяет, является ли текущий набор надмножеством заданной коллекции.
        /// </summary>
        /// <param name="other">Коллекция для сравнения с текущим набором.</param>
        /// <returns>Значение true, если текущий набор является надмножеством объекта other; в противном случае — значение false.</returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            var info = GetInfoAbout(other);
            return info.covering == info.otherSize && info.otherSize <= _count;
        }

        /// <summary>
        /// Определяет, пересекаются ли текущий набор и указанная коллекция.
        /// </summary>
        /// <param name="other">Коллекция для сравнения с текущим набором.</param>
        /// <returns>Значение true, если в текущем наборе и объекте other есть хотя бы один общий элемент; в противном случае — значение false.</returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            var info = GetInfoAbout(other);
            return info.covering == 0;
        }

        /// <summary>
        /// Удаляет объект из множества
        /// </summary>
        /// <param name="item">Удаляемый объект</param>
        /// <returns>
        /// Значение true, если объект item успешно удален из <see cref="ICollection"/>; в противном случае — значение false. 
        /// Этот метод также возвращает значение false, если значение item не найдено в исходной коллекции <see cref="ICollection"/>.
        /// </returns>
        public bool Remove(T item)
        {
            if (_isReadonly)
            {
                throw new NotSupportedException("Объект ICollection<T> доступен только для чтения.");
            }

            var index = GetHashOf(item);
            if (!_buckets[index].Contains(item))
            {
                return false;
            }

            _buckets[index].Remove(item);
            return true;
        }

        /// <summary>
        /// Определяет, содержат ли текущий набор и указанная коллекция одни и те же элементы.
        /// </summary>
        /// <param name="other">Коллекция для сравнения с текущим набором.</param>
        /// <returns>true Если текущий набор равен other; в противном случае — значение false.</returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            var info = GetInfoAbout(other);
            return info.covering == _count && info.otherSize == _count;
        }

        /// <summary>
        /// Изменяет текущий набор таким образом, чтобы он содержал только элементы, 
        /// которые есть либо в нем, либо в указанной коллекции, но не одновременно там и там.
        /// </summary>
        /// <param name="other">Коллекция для сравнения с текущим набором.</param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Свойство other имеет значение null.");
            }

            var otherSet = new GenericHashSet<T>(other);

        }

        /// <summary>
        /// Изменяет текущий набор так, чтобы он содержал все элементы, которые имеются в текущем наборе, в указанной коллекции либо в них обоих.
        /// </summary>
        /// <param name="other">Коллекция для сравнения с текущим набором.</param>
        public void UnionWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Свойство other имеет значение null.");
            }

            foreach (var item in other)
            {
                this.Add(item);
            }
        }

        void ICollection<T>.Add(T item)
        {
            this.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private int GetHashOf(T item) => Math.Abs(item.GetHashCode()) % _capacity;
    }
}
