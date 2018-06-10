using Microsoft.VisualStudio.TestTools.UnitTesting;
using Source;
using System;

namespace Tests
{
    [TestClass]
    public class MapCorrectnessTest
    {
        private GameClassForTest _game;

        private const string _pathToMapWith2Avatars = @"TestResources/2Avatars/config.json";
        private const string _pathToMapWith0Avatars = @"TestResources/0Avatars/config.json";
        private const string _pathToMapWith0Destinations = @"TestResources/0Destinations/config.json";
        private const string _pathToMapWithUnsupportedSymbols = @"TestResources/UnsupportedSymbols/config.json";
        private const string _pathToCorrectMap = @"TestResources/CorrectMap/config.json";
        private const string _pathToMapWithIncorrectSize = @"TestResources/IncorrectSize/config.json";

        /// <summary>
        /// Создание карты с 2 аватврами должно бросать исключение
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidNumberOfAvatarsException))]
        public void MapWith2AvatarsShoulsThrowExceptionWhileBuilding()
        {
            _game = new GameClassForTest(_pathToMapWith2Avatars);
        }

        /// <summary>
        /// Создание карты с 0 аватврами должно бросать исключение
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidNumberOfAvatarsException))]
        public void MapWith0AvatarsShoulsThrowExceptionWhileBuilding()
        {
            _game = new GameClassForTest(_pathToMapWith0Avatars);
        }

        /// <summary>
        /// Создание карты с 0 точек назначения должно бросать исключение
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidNumberOfDestinationsException))]
        public void MapWith0DestinationsShoulsThrowExceptionWhileBuilding()
        {
            _game = new GameClassForTest(_pathToMapWith0Destinations);
        }

        /// <summary>
        /// Создание карты с неподдерживаемыми символами должно бросать исключение
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(UnsupportedSymbolException))]
        public void MapWithUnsupportedSymbolsShoulsThrowExceptionWhileBuilding()
        {
            _game = new GameClassForTest(_pathToMapWithUnsupportedSymbols);
        }

        [TestMethod]
        public void BuildingCorrectMapShouldNotCrash()
        {
            _game = new GameClassForTest(_pathToCorrectMap);
        }

        [TestMethod]
        [ExpectedException(typeof(UnsupportedSymbolException))]
        public void MapWithIncorrectSizeShouldThrowException()
        {
            // непонятно почему такое исключение и не все тест case`ы покрыты
            _game = new GameClassForTest(_pathToMapWithIncorrectSize);
        }

        /// <summary>
        /// Попытка присвоить значение в несуществующую (отрицательную) координату
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TryingSetFieldOnWrongCoordinatesShouldThrowException()
        {
            _game = new GameClassForTest(_pathToCorrectMap);

            var map = _game.GetMap();

            map[new Coordinates(-1, 0)] = FieldTypes.Player;
        }

        [TestMethod]
        public void GetValueFromWrongCoordinatesShouldReturnCorrectValue()
        {
            _game = new GameClassForTest(_pathToCorrectMap);
            var map = _game.GetMap();

            var actual = map[new Coordinates(map.Params.MapSize["height"], map.Params.MapSize["width"])];

            Assert.AreEqual(FieldTypes.BeyondMap, actual);
        }
    }
}