namespace Source
{
    using System;

    public class Player
    {
        private readonly IMap _map;
        private Coordinates _currentCoordinates;

        public Player(IMap gameMap, Coordinates initialPlayerCoordinates)
        {
            if (initialPlayerCoordinates == null)
            {
                throw new Exception("jq jq jq");
            }
            
            _map = gameMap;
            _currentCoordinates = initialPlayerCoordinates;
        }

        public void OnMove(object sender, Coordinates args)
        {
            
        }
    }
}