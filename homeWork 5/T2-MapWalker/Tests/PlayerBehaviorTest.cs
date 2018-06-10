using Microsoft.VisualStudio.TestTools.UnitTesting;
using Source;
using System;

namespace Tests
{
    [TestClass]
    public class PlayerBehaviorTest
    {
        private GameClassForTest _game;
        private Player _player;
        private const string _pathToCorrectMap = @"TestResources/CorrectMap/config.json";        

        [TestInitialize]
        public void Init()
        {
            _game = new GameClassForTest(_pathToCorrectMap);
            _player = _game.GetPlayer();
        }
    }
}