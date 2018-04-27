namespace QueueSource
{
    /// <summary>
    /// Интерфейс, реализующий очередь с приоритетом
    /// </summary>
    /// <typeparam name="T">Тип элементов в очереди</typeparam>
    public interface IQueue<T>
    {
        /// <summary>
        /// Добавляет элемент в очередь
        /// </summary>
        /// <param name="item">Добавляемый элемент</param>
        /// <param name="priority">Численный приоритет</param>
        void Enqueue(T item, int priority);

        /// <summary>
        /// Возвращает элемент с наименьшим приоритетом и удаляет из очереди
        /// </summary>
        /// <returns>Элемент с наименьшим приоритетом</returns>
        T Dequeue();

        bool IsEmpty();
    }
}