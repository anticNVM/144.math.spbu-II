namespace Source
{
    using System;
    using Newtonsoft.Json;
    using System.IO;

    /// <summary>
    /// Класс, реализующий логику игры
    /// </summary>
    public class Game : IContinuationProcess
    {
        /// <summary>
        /// Назавание игры
        /// </summary>
        private static string _title = "SUPER_MEGA_RPG_4";

        /// <summary>
        /// Игрок)
        /// </summary>
        private Player _player;
        protected Player Player
        {
            get => _player;
            private set => _player = value;
        }

        public event EventHandler<EventArgs> Started = (sender, args) => { };
        public event EventHandler<EventArgs> Finished = (sender, args) => { };

        /// <summary>
        /// Создает новую игру, с настройками из <paramref name="pathToGameConfig"/>
        /// </summary>
        /// <param name="pathToGameConfig">Путь до файла в формате json с параметрами игры в требуемом формате</param>
        public Game(string pathToGameConfig, MotionEventLoop loop)
        {
            // парсинг настроек из фала в GameConfig
            var gameConfig = JsonConvert.DeserializeObject<GameConfig>(File.ReadAllText(pathToGameConfig));
            var inputStream = new StreamReader(gameConfig.PathToMap);
            var map = new Map(gameConfig.MapConfig, inputStream, out Coordinates initialPlayerCoordinates);
            _player = new Player(map, initialPlayerCoordinates);
            loop.Motion += (object sender, MotionVectorEventArgs args) => _player.MoveOnVector(args.Coordinates);
            loop.Register(this);
        }

        /// <summary>
        /// Метод, запускающий игру в консоле
        /// </summary>
        public void Start()
        {
            _player.SuccessfulMovement += (object sender, EventArgs args) => ClearConsoleAndDispalyMap();
            _player.DestinationReached += (object sender, EventArgs args) => CongratulatePlayer();
            _player.DestinationReached += (object sender, EventArgs args) => Finished(this, EventArgs.Empty);

            ConsoleSettings.SetCustom();
            ClearConsoleAndDispalyMap();

            Started(this, EventArgs.Empty);

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
            System.Console.WriteLine(
                "Congratulations! You win! \n");
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