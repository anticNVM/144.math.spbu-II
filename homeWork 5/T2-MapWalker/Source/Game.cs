namespace Source
{
    using System;
    using Newtonsoft.Json;
    using System.IO;

    /// <summary>
    /// Класс, реализующий логику игры
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Назавание игры
        /// </summary>
        private static string _title = "SUPER_MEGA_RPG_4";

        /// <summary>
        /// Игрок)
        /// </summary>
        private Player _player;

        /// <summary>
        /// Создает новую игру, с настройками из <paramref name="pathToGameConfig"/>
        /// </summary>
        /// <param name="pathToGameConfig">Путь до файла в формате json с параметрами игры в требуемом формате</param>
        public Game(string pathToGameConfig)
        {
            // парсинг настроек из фала в GameConfig
            var gameConfig = JsonConvert.DeserializeObject<GameConfig>(File.ReadAllText(pathToGameConfig));
            var inputStream = new StreamReader(gameConfig.pathToMap);
            var map = new Map(gameConfig.MapConfig, inputStream, out Coordinates initialPlayerCoordinates);
            _player = new Player(map, initialPlayerCoordinates);
        }

        /// <summary>
        /// Метод, запускающий игру в консоле
        /// </summary>
        public void Start()
        {
            var mainloop = new EventLoop();

            mainloop.ArrowPressed += _player.MovePlayer;
            _player.SuccessfulMovement += (object sender, EventArgs args) => ClearConsoleAndDispalyMap();
            _player.DestinationReached += (object sender, EventArgs args) => CongratulatePlayer();
            _player.DestinationReached += (object sender, EventArgs args) => mainloop.Exit();

            ConsoleSettings.SetCustom();
            ClearConsoleAndDispalyMap();
            mainloop.Run();

            ConsoleSettings.SetDefault();
        }

        /// <summary>
        /// Печатает карту в консоль
        /// </summary>
        private void DisplayMap() => System.Console.WriteLine(_player.Map.ToString());

        /// <summary>
        /// Очищает консоль и печатает карту
        /// </summary>
        private void ClearConsoleAndDispalyMap()
        {
            Console.Clear();
            DisplayMap();
        }

        /// <summary>
        /// Печатает поздравления игрока с победой в консоль
        /// </summary>
        private void CongratulatePlayer()
        {
            System.Console.WriteLine("!!!!");
        }

        /// <summary>
        /// Класс с настройками консоли
        /// </summary>
        private static class ConsoleSettings
        {
            public static void SetCustom()
            {
                Console.CursorVisible = false;
                Console.Title = _title;
            }

            public static void SetDefault()
            {
                Console.CursorVisible = true;
            }
        }
    }
}