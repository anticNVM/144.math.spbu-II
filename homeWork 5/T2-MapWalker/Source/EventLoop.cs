using System;

namespace Source
{
    /// <summary>
    /// Цикл, генерирующий события по нажатию
    /// </summary>
    public class EventLoop
    {
        private bool _exit = false;

        /// <summary>
        /// Событие, возникающее при нажатии на стрелки 
        /// <see cref="ConsoleKey.LeftArrow"/>
        /// <see cref="ConsoleKey.RightArrow"/>
        /// <see cref="ConsoleKey.UpArrow"/>
        /// <see cref="ConsoleKey.DownArrow"/>
        /// </summary>
        public event EventHandler<ArrowPressedEventArgs> ArrowPressed;

        /// <summary>
        /// Метод, вызывающий событие <see cref="ArrowPressed"/>
        /// </summary>
        /// <param name="args">Аргументы события</param>
        protected virtual void OnArrowPressed(ArrowPressedEventArgs args) => ArrowPressed?.Invoke(this, args);

        /// <summary>
        /// Метод, запускающий бесконечный цикл, регистрирующий нажатия стрелок и <see cref="ConsoleKey.Escape"/>
        /// </summary>
        public void Run()
        {
            while (!_exit)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        OnArrowPressed(ArrowPressedEventArgs.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        OnArrowPressed(ArrowPressedEventArgs.Right); 
                        break;
                    case ConsoleKey.UpArrow:
                        OnArrowPressed(ArrowPressedEventArgs.Up); 
                        break;
                    case ConsoleKey.DownArrow:
                        OnArrowPressed(ArrowPressedEventArgs.Down); 
                        break;
                    case ConsoleKey.Escape:
                        Exit();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Метод, который останавливает (выходит из) <see cref="EventLoop"/>
        /// </summary>
        public void Exit() => _exit = true;        
    }
}
