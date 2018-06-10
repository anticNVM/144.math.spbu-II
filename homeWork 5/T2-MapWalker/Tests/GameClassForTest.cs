namespace Tests
{
    using Source;
    using System;

    public class GameClassForTest : Game
    {
        public GameClassForTest(string pathToGameConfig, IMotionEventLoop loop) : base(pathToGameConfig, loop)
        {
        }

        public GameClassForTest(string pathToGameConfig) : base(pathToGameConfig, new ArrowPressEventLoop())
        {
        }

        public IMap GetMap() => _player.Map;

        public Player GetPlayer() => _player;
    }
}