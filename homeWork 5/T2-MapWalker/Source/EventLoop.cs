using System;

namespace Source
{
    public class EventLoop
    {
        public event EventHandler<Coordinates> ArrowPressed;

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        ArrowPressed(this, Coordinates.Left); 
                        break;
                    case ConsoleKey.RightArrow:
                        ArrowPressed(this, Coordinates.Right); 
                        break;
                    case ConsoleKey.UpArrow:
                        ArrowPressed(this, Coordinates.Up); 
                        break;
                    case ConsoleKey.DownArrow:
                        ArrowPressed(this, Coordinates.Down); 
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
