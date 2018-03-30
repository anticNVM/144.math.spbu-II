using System;
using System.IO;

namespace MapWalkerSource
{
    public class Game
    {
        private string[] _map;
        private WalkerCoordinates _walkerCoordinates;
        private const string _avatar = "@";

        public Game(string gameBoardFilePath)
        {
            _map = BuildMap(gameBoardFilePath);
            for (var i = 0; i < _map.Length; ++i)
            {
                if (_map[i].Contains(_avatar))
                {
                    _walkerCoordinates.lineCoord = i;
                    _walkerCoordinates.columnCoord = _map[i].IndexOf(_avatar);
                }
            }
        }

        public void OnLeft(object sender, EventArgs args)
        {
        }

        public void OnRight(object sender, EventArgs args)
        {
        }

        public void OnUp(object sender, EventArgs args)
        {
        }

        public void OnDown(object sender, EventArgs args)
        {
        }

        private static string[] BuildMap(string filepath)
        {
            int mapHeight = 0;
            using (var file = new StreamReader(filepath, System.Text.Encoding.Default))
            {
                string line = "";
                while ((line = file.ReadLine()) != null)
                {
                    mapHeight++;
                }
            }

            var map = new string[mapHeight];
            using (var file = new StreamReader(filepath, System.Text.Encoding.Default))
            {
                for (var i = 0; i < mapHeight; ++i)
                {
                    map[i] = file.ReadLine();
                }
            }

            return map;
        }

        private struct WalkerCoordinates
        {
            public int lineCoord;
            public int columnCoord; 
        }
    }
}