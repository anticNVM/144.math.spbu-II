namespace Tests
{
    using Source;
    using System;

    /// <summary>
    /// Класс, который расширяет функциональность <see cref="Source.Game"/> для тестирования
    /// (через этот класс можно по поправить инкапсуляцию в Game, но это не точно)
    /// </summary>
    public class GameClassForTest : Game
    {
        public GameClassForTest(string pathToGameConfig, MotionEventLoop loop) : base(pathToGameConfig, loop)
        {
        }

        public GameClassForTest(string pathToGameConfig) : base(pathToGameConfig, new ArrowPressEventLoop())
        {
        }

        public IMap GetMap() => _player.Map;

        public Player GetPlayer() => _player;
    }
}