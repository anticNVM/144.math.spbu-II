namespace T2_LinkedList
{
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
        bool Insert(int value, int after);

        /// <summary>
        /// Удаляет первое вхождение указанного значения в списке
        /// </summary>
        /// <param name="value"> Удаляемое значение </param>
        /// <returns> .false если знасение не найденно в списке, .true иначе </returns>
        bool Remove(int value);

        /// <summary>
        /// Проверяет, сожержится ли значение в списке
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Contains(int value);

        /// <summary>
        /// Очищает список
        /// </summary>
        void Clear();

        /// <summary>
        /// Проверяет список на пустоту
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// Возвращает неполную копию списка
        /// </summary>
        /// <returns></returns>
        LinkedList Copy();

        /// <summary>
        /// Возвращает значение головы списка
        /// </summary>
        /// <returns></returns>
        int GetHead();

        /// <summary>
        /// Возвращает неполную копию списка, состоящего из всех элементов, кроме первого
        /// </summary>
        /// <returns></returns>
        LinkedList GetTail();

        /// <summary>
        /// Длина списка
        /// </summary>
        /// <returns></returns>
        int Count { get; }
    }
}