namespace Source
{
    using System;

    /// <summary>
    /// Интерфейс цикла, генерирующего события для перемещения
    /// </summary>
    public abstract class MotionEventLoop : AbstractLoop
    {
        /// <summary>
        /// Событие, возникающее при движении
        /// </summary>
        public abstract event EventHandler<MotionVectorEventArgs> Motion;
    }
}