using System;

namespace Source
{
    public class EventLoop
    {
        public event EventHandler<Coordinates> MoveHandler = (sender, args) => { };

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        MoveHandler(this, Coordinates.Left); 
                        break;
                    case ConsoleKey.RightArrow:
                        MoveHandler(this, Coordinates.Right); 
                        break;
                    case ConsoleKey.UpArrow:
                        MoveHandler(this, Coordinates.Up); 
                        break;
                    case ConsoleKey.DownArrow:
                        MoveHandler(this, Coordinates.Down); 
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
