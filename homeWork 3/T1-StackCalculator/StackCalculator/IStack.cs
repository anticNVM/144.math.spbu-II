namespace StackCalculator
{
    /// <summary>
    /// Интерфейс, реализующий функциональность стека.
    /// </summary>
    public interface IStack
    {
        /// <summary>
        /// Добавляет значение в стек.
        /// </summary>
        /// <param name="value">Добавляемое значение.</param>
        void Push(int value);

        /// <summary>
        /// Забирает значение из вершины стека.
        /// </summary>
        /// <exception cref="EmptyStackException">Если стек пуст</exception>
        /// <returns>Элемент на вершине стека.</returns>
        int Pop();

        /// <summary>
        /// Возвращает значение из вершины стека (не удаляя его).
        /// </summary>
        /// <exception cref="EmptyStackException">Если стек пуст</exception>
        /// <returns>Элемент на вершине стека.</returns>
        int Peek();

        /// <summary>
        /// Очищает стек, удаляя из него все элементы.
        /// </summary>
        void Clear();

        /// <summary>
        /// Проверяет стек на пустоту.
        /// </summary>
        /// <returns>.true если стек пуст, иначе .false</returns>
        bool IsEmpty();

        /// <summary>
        /// Свойство, определяющее размер стека (кол-во элементов в нем).
        /// </summary>
        /// <returns>Количество элементов в стеке.</returns>
        int Count { get; }
    }
}