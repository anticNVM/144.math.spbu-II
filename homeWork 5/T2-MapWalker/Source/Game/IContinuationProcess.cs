namespace Source
{
    using System;

    /// <summary>
    /// Интерфейс длящегося процесса, который имеет начало и конец
    /// </summary>
    public interface IContinuationProcess
    {
        /// <summary>
        /// Начало процесса
        /// </summary>
        event EventHandler<EventArgs> Started;

        /// <summary>
        /// Завершение процесса
        /// </summary>
        event EventHandler<EventArgs> Finished;
    }
}