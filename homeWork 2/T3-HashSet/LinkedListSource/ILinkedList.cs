using System.Collections;

namespace LinkedListSource
{
    /// <summary>
    /// Интерфейс, реализующий функциональность связного списка.
    /// </summary>
    public interface ILinkedList : IEnumerable
    {
        /// <summary>
        /// Доступ к значению элемента списка по индексу
        /// </summary>
        int this[int index] { get; }

        /// <summary>
        /// Добавляет значение в конец списка
        /// </summary>
        /// <param name="value">Добавляемое значение</param>
        void Append(int value);

        /// <summary>
        /// Добавляет значение в начало списка
        /// </summary>
        /// <param name="value">Добавляемое значение</param>
        void AddToBegin(int value);

        /// <summary>
        /// Добавляет значение в список после указаного индекса
        /// </summary>
        /// <param name="value">Добавляемое значение</param>
        /// <param name="after">Индекс списка</param>
        /// <exception cref="IndexOutOfRangeException">
        /// Бросается при некорректном значении after
        /// </exception>
        void Insert(int value, int after);

        /// <summary>
        /// Удаляет первое вхождение указанного значения в списке
        /// </summary>
        /// <param name="value"> Удаляемое значение </param>
        /// <exception cref="Exception.ValueIsNotInListException">
        /// Бросается при попытке удалить несуществующее значение.
        /// </exception>
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
        ILinkedList Copy();

        /// <summary>
        /// Возвращает значение головы списка
        /// </summary>
        /// <returns>Значение головы списка</returns>
        int GetHead();

        /// <summary>
        /// Возвращает неполную копию списка, состоящего из всех элементов, кроме первого
        /// </summary>
        /// <returns>Неполную копию списка, состоящего из всех элементов, кроме первого</returns>
        ILinkedList GetTail();

        /// <summary>
        /// Длина списка
        /// </summary>
        /// <returns>Кол-во элементов в списке</returns>
        int Count { get; }
    }
}