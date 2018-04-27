namespace HashSetSource
{
    /// <summary>
    /// Интерфейс, реализующий ножество целочисленных знячений int
    /// </summary>
    public interface IHashSet
    {
        /// <summary>
        /// Добавляет значение в множество
        /// </summary>
        /// <param name="value">Добавляемое значение</param>
        /// <exception cref="HashSetSource.ValueIsAlreadyInSetException"></exception>
        void Add(int value);

        /// <summary>
        /// Очищает множество, удаляя из него все элементы
        /// </summary>
        void Clear();

        /// <summary>
        /// Проверяет принадлежность значения множеству
        /// </summary>
        /// <param name="value">Проверяемое значение</param>
        /// <returns>.true если принадлежит, .false иначе</returns>
        bool Contains(int value);

        /// <summary>
        /// Удаляет элемент из множества
        /// </summary>
        /// <param name="value">Удаляемый элемент</param>
        /// <exception cref="HashSetSource.ValueIsNotInSetException"/>
        void Remove(int value);

        /// <summary>
        /// Возвращает число размер множеста
        /// </summary>
        /// <returns>Число элементов в множестве</returns>
        int Count { get; }

        /// <summary>
        /// Возвращает коэффициент заполнения хеш-таблицы
        /// </summary>
        /// <returns>Коэффициент заполнения хеш-таблицы</returns>
        float Factor { get; }
    }
}