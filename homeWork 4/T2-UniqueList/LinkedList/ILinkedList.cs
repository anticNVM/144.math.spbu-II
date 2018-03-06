namespace LinkedList
{
    /// <summary>
    /// Интерфейс, реализующий функциональность связного списка
    /// </summary>
    public interface ILinkedList
    {
        /// <summary>
        /// Добавляет значение в конец списка
        /// </summary>
        /// <param name="value"> Добавляемое значение </param>
        void Append(int value);

        /// <summary>
        /// Добавляет значение в начало списка
        /// </summary>
        /// <param name="value"> Добавляемое значение </param>
        void AddToBegin(int value);

        /// <summary>
        /// Добавляет значение в список после указаного индекса
        /// </summary>
        /// <param name="value"> Добавляемое значение </param>
        /// <param name="after"> Индекс списка </param>
        /// <returns> .true, если значение было успешно добавлено, .false иначе </returns>
        void Insert(int value, int after);

        /// <summary>
        /// Удаляет первое вхождение указанного значения в списке
        /// </summary>
        /// <param name="value"> Удаляемое значение </param>
        /// <returns> .false если знасение не найденно в списке, .true иначе </returns>
        void Remove(int value);

        /// <summary>
        /// Проверяет, сожержится ли значение в списке
        /// </summary>
        /// <param name="value">Проверяемое значение</param>
        /// <returns>.true, если содержится, .false иначе</returns>
        bool Contains(int value);

        /// <summary>
        /// Очищает список
        /// </summary>
        void Clear();

        /// <summary>
        /// Проверяет список на пустоту
        /// </summary>
        /// <returns>.true, если список пуст, .false иначе</returns>
        bool IsEmpty();

        /// <summary>
        /// Возвращает неполную копию списка
        /// </summary>
        /// <returns>Неполную копию списка</returns>
        LinkedList Copy();

        /// <summary>
        /// Возвращает значение головы списка
        /// </summary>
        /// <returns>Значение головы списка</returns>
        int GetHead();

        /// <summary>
        /// Возвращает неполную копию списка, состоящего из всех элементов, кроме первого
        /// </summary>
        /// <returns>Неполную копию списка, состоящего из всех элементов, кроме первого</returns>
        LinkedList GetTail();

        /// <summary>
        /// Длина списка
        /// </summary>
        /// <returns>Кол-во элементов в списке</returns>
        int Count { get; }
    }
}