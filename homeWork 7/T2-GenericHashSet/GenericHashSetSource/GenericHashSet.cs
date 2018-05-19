using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericHashSetSource
{
    public class GenericHashSet<T> : ISet<T> where T : class
    {
        private const int _defaultCapacity = 20;

        private const float _criticalFactor = 0.7f;

        private T[] _buckets;

        private bool[] _deleted;

        private int _capacity;

        private int _count;

        private bool _isReadonly;

        public GenericHashSet()
        {
            _buckets = new T[_defaultCapacity];
            _deleted = new bool[_defaultCapacity];
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

            var hashValue = GetHashOf(item);
            var hashStep = GetAnotherHashOf(item);
            for (int i = 0; i < _capacity; i++)
            {
                if (_buckets[hashValue].Equals(item))
                {
                    return false;
                }

                if (_buckets[hashValue].Equals(default(T)))
                {
                    _buckets[hashValue] = item;
                    _count++;
                    return true;
                }
                else
                {
                    hashValue = (hashValue + hashStep) % _capacity;
                }
            }

            if (Factor > _criticalFactor)
            {
                this.Resize();
            }

            return true;
        }

        private void Resize()
        {
            throw new NotImplementedException();
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

            _buckets = new T[_defaultCapacity];
            _deleted = new bool[_defaultCapacity];
            _capacity = _defaultCapacity;
            _count = 0;
        }

        private bool GetRealIndexOf(T item, out int index)
        {
            index = 0;
            var hashValue = GetHashOf(item);
            var hashStep = GetAnotherHashOf(item);

            for (int i = 0; i < _capacity; i++)
            {
                if (_buckets[hashValue] == null && !_deleted[hashValue])
                {
                    break;
                }
                else if (_buckets[hashValue].Equals(item))
                {
                    index = hashValue;
                    return true;
                }
                else
                {
                    hashValue = (hashValue + hashStep) % _capacity;
                }
            }

            return false;
        }

        /// <summary>
        /// Определяет, содержит ли коллекция <see cref="ICollection"/> указанное значение.
        /// </summary>
        /// <param name="item">Значение для проверки</param>
        /// <returns>.true если содержит, .false иначе</returns>
        public bool Contains(T item)
        {
            return GetRealIndexOf(item, out int _);
        }

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
                if (item != null)
                {
                    array[currentIndex] = item;
                    currentIndex++;
                }
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
            return (IEnumerator<T>)_buckets.GetEnumerator();
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

            var covering = new bool[_capacity];
            foreach (var item in other)
            {
                if (this.GetRealIndexOf(item, out int index))
                {
                    covering[index] = true;
                }
            }

            for (int i = 0; i < covering.Length; i++)
            {
                if (!covering[i])
                {
                    if (_buckets[i] != null)
                    {
                        _buckets[i] = null;
                        _deleted[i] = true;
                        _count--;
                    }
                }
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

            if (info.covering == _count && info.otherSize > _count)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Определяет, является ли текущий набор должным (строгим) надмножеством заданной коллекции.
        /// </summary>
        /// <param name="other">Коллекция для сравнения с текущим набором.</param>
        /// <returns>Значение true, если текущий набор является строгим надмножеством объекта other; в противном случае — значение false.</returns>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            var info = GetInfoAbout(other);

            if (info.covering == info.otherSize && info.otherSize < _count)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Определяет, является ли набор подмножеством заданной коллекции.
        /// </summary>
        /// <param name="other">Коллекция для сравнения с текущим набором.</param>
        /// <returns>Значение true, если текущий набор является подмножеством объекта other; в противном случае — значение false.</returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            var info = GetInfoAbout(other);


            if (info.covering == _count && info.otherSize >= _count)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Определяет, является ли текущий набор надмножеством заданной коллекции.
        /// </summary>
        /// <param name="other">Коллекция для сравнения с текущим набором.</param>
        /// <returns>Значение true, если текущий набор является надмножеством объекта other; в противном случае — значение false.</returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            var info = GetInfoAbout(other);

            if (info.covering == info.otherSize && info.otherSize <= _count)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Определяет, пересекаются ли текущий набор и указанная коллекция.
        /// </summary>
        /// <param name="other">Коллекция для сравнения с текущим набором.</param>
        /// <returns>Значение true, если в текущем наборе и объекте other есть хотя бы один общий элемент; в противном случае — значение false.</returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            var info = GetInfoAbout(other);

            if (info.covering == 0)
            {
                return true;
            }

            return false;
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

            if (GetRealIndexOf(item, out int index))
            {
                _buckets[index] = null;
                _deleted[index] = true;
                _count--;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Определяет, содержат ли текущий набор и указанная коллекция одни и те же элементы.
        /// </summary>
        /// <param name="other">Коллекция для сравнения с текущим набором.</param>
        /// <returns>true Если текущий набор равен other; в противном случае — значение false.</returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            var info = GetInfoAbout(other);

            if (info.covering == _count && info.otherSize == _count)
            {
                return true;
            }

            return false;
        }

//////////////////////////////////////////////////////////////////////////////////////////

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

/////////////////////////////////////////////////////////////////////////////////////////

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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _buckets.GetEnumerator();
        }

        private int GetHashOf(T item) => Math.Abs(item.GetHashCode()) % _capacity;
        private int GetAnotherHashOf(T item) => Math.Abs(item.GetHashCode()) % _capacity;
    }
}
