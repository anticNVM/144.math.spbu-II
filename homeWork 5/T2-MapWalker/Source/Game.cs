namespace Source
{
    public class Game
    {
        private string _pathToMap;
        private Player _player;

        public Game(string path)
        {
            _pathToMap = path;

            var parsedMap = BuildMap();
            _player = new Player(parsedMap.Item1, parsedMap.Item2);
        }

        public void Run()
        {
            var mainloop = new EventLoop();

            mainloop.MoveHandler += _player.OnMove;
            mainloop.Run();
        }

        private (IMap, Coordinates) BuildMap()
        {

        }
    }
}