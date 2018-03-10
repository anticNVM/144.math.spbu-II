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
        /// Свойство, определяющее размер стека (кол-во элементов в нем).
        /// </summary>
        /// <returns>Количество элементов в стеке.</returns>
        int Count { get; }
    }

    // Экстеншн класс, который реализует методы, общие для всех потомков интерфейса
    // (можно переопределять в классах даже без override)    
    // https://metanit.com/sharp/tutorial/3.18.php
    public static class IStackExtensions
    {
        /// <summary>
        /// Проверяет стек на пустоту.
        /// </summary>
        /// <returns>.true если стек пуст, иначе .false</returns>
        public static bool IsEmpty(this IStack obj)
        {
            return obj.Count == 0;
        }
    }
}