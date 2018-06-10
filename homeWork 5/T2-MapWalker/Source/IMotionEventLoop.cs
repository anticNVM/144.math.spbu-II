namespace Source
{
    using System;

    /// <summary>
    /// Интерфейс цикла, генерирующего события для перемещения
    /// </summary>
    public interface IMotionEventLoop
    {
        event EventHandler<MotionVectorEventArgs> Motion;

        /// <summary>
        /// Запускает цикл
        /// </summary>
        void Run();

        /// <summary>
        /// Выходит из цикла
        /// </summary>
        void Exit();
    }
}