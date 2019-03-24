using System;

namespace Source
{
    /// <summary>
    /// Цикл, генерирующий события по нажатию
    /// </summary>
    public class ArrowPressEventLoop : MotionEventLoop
    {
        /// <summary>
        /// Событие, возникающее при нажатии на стрелки 
        /// <see cref="ConsoleKey.LeftArrow"/>
        /// <see cref="ConsoleKey.RightArrow"/>
        /// <see cref="ConsoleKey.UpArrow"/>
        /// <see cref="ConsoleKey.DownArrow"/>
        /// </summary>
        public override event EventHandler<MotionVectorEventArgs> Motion;

        /// <summary>
        /// Метод, вызывающий событие <see cref="ArrowPressed"/>
        /// </summary>
        /// <param name="args">Аргументы события</param>
        protected virtual void OnArrowPressed(MotionVectorEventArgs args) => Motion?.Invoke(this, args);

        /// <summary>
        /// Метод, запускающий бесконечный цикл, регистрирующий нажатия стрелок и <see cref="ConsoleKey.Escape"/>
        /// </summary>
        protected override void Run()
        {
            while (!_exit)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        OnArrowPressed(MotionVectorEventArgs.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        OnArrowPressed(MotionVectorEventArgs.Right); 
                        break;
                    case ConsoleKey.UpArrow:
                        OnArrowPressed(MotionVectorEventArgs.Up); 
                        break;
                    case ConsoleKey.DownArrow:
                        OnArrowPressed(MotionVectorEventArgs.Down); 
                        break;
                    case ConsoleKey.Escape:
                        Exit();
                        break;
                    default:
                        break;
                }
            }
        }       
    }
}
