using System;

namespace Source
{
    public class EventLoop
    {
        private bool _exit = false;

        public event EventHandler<ArrowPressedEventArgs> ArrowPressed;
        protected virtual void OnArrowPressed(ArrowPressedEventArgs args) => ArrowPressed?.Invoke(this, args);

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

        public void Exit() => _exit = true;        
    }
}
