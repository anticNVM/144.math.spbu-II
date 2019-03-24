using Microsoft.VisualStudio.TestTools.UnitTesting;
using Source;
using System;

namespace Tests
{
    /// <summary>
    /// Тесты для проверки поведения игрока (перемещение и тп)
    /// </summary>
    [TestClass]
    public class PlayerBehaviorTest
    {
        private const string _pathToCorrectMap = @"TestResources/CorrectMap/config.json";        

        /// <summary>
        /// Тест на различные случаи передвижения персонажа
        /// </summary>
        /// <param name="sequenceOfCommands">Последовательность комманд (char)</param>
        /// <param name="expectedX">Ожидаемое значение по X</param>
        /// <param name="expectedY">Ожидаемое значение по Y</param>
        [DataTestMethod]
        // игра не должна падать при попытке выйти за границы карты
        [DataRow("www", 0, 1)]
        // стена должна ограничивать передвижение игрока
        [DataRow("ssss", 2, 1)]
        // а если стены с 3 сторон?
        [DataRow("ssdddddwawd", 1, 6)]
        // персонаж не должен перемещаться при достижении пункта назначения
        [DataRow("ssdddww", 1, 4)]
        public void PlayerMovementsTest(string sequenceOfCommands, int expectedX, int expectedY)
        {
            var game = new GameClassForTest(_pathToCorrectMap, new CommandsEventLoop(sequenceOfCommands));
            game.Start();

            var expected = new Coordinates(expectedX, expectedY);
            var actual = game.GetPlayer().CurrentCoordinates;

            // AreEqual требует перегрузки ==, но с этим как-то не задалось(
            Assert.IsTrue(actual.Equals(expected));
        }

        /// <summary>
        /// Тест проверяет, что при достижении точки назначения вызовется верное событие
        /// </summary>
        /// <param name="sequenceOfCommands"></param>
        [TestMethod]
        public void WhenDestinationReachedEventShouldCalled()
        {
            string sequenceOfCommands = "ssdddww";
            var game = new GameClassForTest(_pathToCorrectMap, new CommandsEventLoop(sequenceOfCommands));
            bool flag = false;
            game.GetPlayer().DestinationReached += (object sender, EventArgs args) => flag = true;
            game.Start();

            Assert.IsTrue(flag);
        }
    }
}