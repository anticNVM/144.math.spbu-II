namespace Source
{
    using System;

    /// <summary>
    /// Абстрактный цикл
    /// </summary>
    public abstract class AbstractLoop
    {
        protected bool _exit;

        /// <summary>
        /// Запускает цикл
        /// </summary>
        protected abstract void Run();

        /// <summary>
        /// Устанавливает значение _exit = false, тем самым останавливает цикл
        /// </summary>
        protected void Exit() => _exit = true;

        /// <summary>
        /// Подписывается на события процесса
        /// (по событию <see cref="IContinuationProcess.Started"/> запускает цикл
        /// по событию<see cref="IContinuationProcess.Finished"/> останавливает цикл (выходит из него)
        /// </summary>
        /// <param name="process">Регистрируемый прцесс</param>
        public void Register(IContinuationProcess process)
        {
            process.Started += (object sender, EventArgs args) => this.Run();
            process.Finished += (object sender, EventArgs args) => this.Exit();
        }
    }
}