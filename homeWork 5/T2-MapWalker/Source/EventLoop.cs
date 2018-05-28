using System;

namespace Source
{
    public class EventLoop
    {
        public event EventHandler<ArrowPressedEventArgs> ArrowPressed;

        // это каноническое объявление событий)
        protected virtual void OnArrowPressed(ArrowPressedEventArgs args)
        {
            // = ArrowPressed?.Invoke(this, args)
            if (ArrowPressed != null)
            {
                ArrowPressed(this, args);
            }
        }

        public void Run()
        {
            bool exit = false;
            while (!exit)
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
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
