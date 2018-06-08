using Microsoft.VisualStudio.TestTools.UnitTesting;
using Source;
using System;

namespace Tests
{
    /// <summary>
    /// Класс облегчающий тестирование игры.
    /// </summary>
    public class TestGame : Game
    {
        public TestGame(string pathToGameConfig) : base(pathToGameConfig)
        {
        }

        public IMap GetMap() => base.CurrentMap;
    }

    [TestClass]
    public class MapCorrectnessTest
    {
        private TestGame _game;

        private string _pathToMapWith2Avatars = @"/home/guardian/git/144.math.spbu-II/homeWork 5/T2-MapWalker/Tests/TestResources/0Destinations/map.txt";
        private string _pathToMapWith0Avatars = @"/home/guardian/git/144.math.spbu-II/homeWork 5/T2-MapWalker/Tests/TestResources/0Avatars/config.json";
        private string _pathToMapWith0Destinations = @"/home/guardian/git/144.math.spbu-II/homeWork 5/T2-MapWalker/Tests/TestResources/0Destinations/map.txt";
        private string _pathToMapWithUnsupportedSymbols = @"/home/guardian/git/144.math.spbu-II/homeWork 5/T2-MapWalker/Tests/TestResources/0Destinations/map.txt";
        private string _pathToCorrectMap = @"/home/guardian/git/144.math.spbu-II/homeWork 5/T2-MapWalker/Tests/TestResources/0Destinations/map.txt";

        /// <summary>
        /// Создание карты с 2 аватврами должно бросать исключение
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidNumberOfAvatarsException))]
        public void MapWith2AvatarsShoulsThrowExceptionWhileBuilding()
        {
            _game = new TestGame(_pathToMapWith2Avatars);
        }

        /// <summary>
        /// Создание карты с 0 аватврами должно бросать исключение
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidNumberOfAvatarsException))]
        public void MapWith0AvatarsShoulsThrowExceptionWhileBuilding()
        {
            _game = new TestGame(_pathToMapWith0Avatars);
        }

        /// <summary>
        /// Создание карты с 0 точек назначения должно бросать исключение
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidNumberOfDestinationsException))]
        public void MapWith0DestinationsShoulsThrowExceptionWhileBuilding()
        {
            _game = new TestGame(_pathToMapWith0Destinations);
        }

        /// <summary>
        /// Создание карты с неподдерживаемыми символами должно бросать исключение
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(UnsupportedSymbolException))]
        public void MapWithUnsupportedSymbolsShoulsThrowExceptionWhileBuilding()
        {
            _game = new TestGame(_pathToMapWithUnsupportedSymbols);
        }

        /// <summary>
        /// Попытка присвоить значение в несуществующую (отрицательную) координату
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TryingSetFieldOnWrongCoordinatesShouldThrowException()
        {
            _game = new TestGame(_pathToCorrectMap);
            var map = _game.GetMap();

            map[new Coordinates(-1, 0)] = FieldTypes.Player;
        }

        [TestMethod]
        public void Kek()
        {
            _game = new TestGame(_pathToCorrectMap);
            var map = _game.GetMap();

            var foo = map[new Coordinates(map.Params.MapSize["height"], map.Params.MapSize["width"])];
        }
    }
}