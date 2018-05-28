namespace Source
{
    using System;
    using Newtonsoft.Json;
    using System.IO;

    public class Game
    {
        private Player _player;

        public Game(string pathToGameConfig)
        {
            var gameConfig = JsonConvert.DeserializeObject<GameConfig>(File.ReadAllText(pathToGameConfig));
            var inputStream = new StreamReader(gameConfig.pathToMap);
            var map = new Map(gameConfig.MapConfig, inputStream, out Coordinates initialPlayerCoordinates);
            _player = new Player(map, initialPlayerCoordinates);
        }

        public void Start()
        {
            var mainloop = new EventLoop();

            mainloop.ArrowPressed += _player.MovePlayer;
            _player.SuccessfulMovement += (object sender, EventArgs args) => 
                {
                    Console.Clear();
                    DisplayMap();
                };
            _player.DestinationReached += (object sender, EventArgs args) => CongratulatePlayer();
            _player.DestinationReached += (object sender, EventArgs args) => mainloop.Exit();

            Console.CursorVisible = false;
            DisplayMap();
            mainloop.Run();
        }

        private void DisplayMap()
        {
            System.Console.WriteLine(_player.Map.ToString());
        }

        private void CongratulatePlayer()
        {
            System.Console.WriteLine("!!!!");
            Console.CursorVisible = true;
        }
    }
}