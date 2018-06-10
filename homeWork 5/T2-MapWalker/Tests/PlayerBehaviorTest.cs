using Microsoft.VisualStudio.TestTools.UnitTesting;
using Source;
using System;

namespace Tests
{
    [TestClass]
    public class PlayerBehaviorTest
    {
        private const string _pathToCorrectMap = @"TestResources/CorrectMap/config.json";        

        [DataTestMethod]
        [DataRow("www", 0, 1)]
        [DataRow("ssss", 2, 1)]
        [DataRow("ssdddddwawd", 1, 6)]
        [DataRow("ssdddww", 1, 4)]
        public void PlayerMovementsTest(string sequenceOfCommands, int expectedX, int expectedY)
        {
            var game = new GameClassForTest(_pathToCorrectMap, new ManualCommandsEventLoop(sequenceOfCommands));
            game.Start();

            var expected = new Coordinates(expectedX, expectedY);
            var actual = game.GetPlayer().CurrentCoordinates;

            // AreEqual требует перегрузки ==, но с этим как-то не задалось(
            Assert.IsTrue(actual.Equals(expected));
        }

        [DataTestMethod]
        [DataRow("ssdddww")]
        public void WhenDestinationReachedEventShouldCalled(string sequenceOfCommands)
        {
            var game = new GameClassForTest(_pathToCorrectMap, new ManualCommandsEventLoop(sequenceOfCommands));
            bool flag = false;
            game.GetPlayer().DestinationReached += (object sender, EventArgs args) => flag = true;
            game.Start();

            Assert.IsTrue(flag);
        }
    }
}