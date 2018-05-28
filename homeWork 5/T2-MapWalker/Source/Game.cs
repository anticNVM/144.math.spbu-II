namespace Source
{
    using System;
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

        public void Start()
        {
            var mainloop = new EventLoop();

            mainloop.ArrowPressed += _player.MovePlayer;
            _player.SuccessfulMovement += (object sender, EventArgs args) => DisplayMap();
            _player.DestinationReached += (object sender, EventArgs args) => CongratulatePlayer();

            mainloop.Run();
        }

        // TODO
        private void DisplayMap()
        {
            _player.Map.ToString();
        }

        // TODO
        private void CongratulatePlayer()
        {

        }
    }
}