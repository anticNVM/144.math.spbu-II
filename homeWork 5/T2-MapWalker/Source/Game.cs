namespace Source
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;

    public class Game
    {
        private Player _player;

        public Game(string pathToConfig, string pathToMap)
        {
            var config = JsonConvert.DeserializeObject<MapConfig>(File.ReadAllText(pathToConfig));
            var inputStream = new StreamReader(pathToMap);

            Coordinates initialPlayerCoordinates = null;
            var map = new Map(config, inputStream, out initialPlayerCoordinates);

            _player = new Player(map, initialPlayerCoordinates);
        }

        public void Run()
        {
            var mainloop = new EventLoop();

            mainloop.MoveHandler += _player.OnMove;
            mainloop.Run();
        }
    }
}