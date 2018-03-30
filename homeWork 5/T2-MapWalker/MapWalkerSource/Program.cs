using System;

namespace MapWalkerSource
{
    class Program
    {
        private static void Main(string[] args)
        {
            var boardPath = @"./Board.txt";

            var mainloop = new EventLoop();
            var game = new Game(boardPath);

            mainloop.LeftHandler += game.OnLeft;
            mainloop.RightHandler += game.OnRight;
            mainloop.UpHandler += game.OnUp;
            mainloop.DownHandler += game.OnDown;

            mainloop.Run();
        }
    }
}
