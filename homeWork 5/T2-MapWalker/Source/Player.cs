namespace Source
{
    using System;

    public class Player
    {
        private const string _avatar = "@";
        private readonly IMap _map;
        private Coordinates _currentCoordinates;

        public Player(IMap gameMap, Coordinates initialPlayerCoordinates)
        {
            _map = gameMap;
            _currentCoordinates = initialPlayerCoordinates;
        }

        public void OnMove(object sender, Coordinates args)
        {
            
        }
    }
}