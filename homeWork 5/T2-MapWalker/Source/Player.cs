namespace Source
{
    using System;

    public class Player
    {
        private IMap _map;
        private Coordinates _currentCoordinates;
        public event EventHandler<EventArgs> SuccessfulMovement = (sender, args) => { };
        public event EventHandler<EventArgs> DestinationReached = (sender, args) => { };
        public IMap Map { get => _map; } 

        public Player(IMap gameMap, Coordinates initialPlayerCoordinates)
        {
            if (initialPlayerCoordinates == null)
            {
                throw new Exception("jq jq jq");
            }

            _map = gameMap;
            _currentCoordinates = initialPlayerCoordinates;
        }

        public void MovePlayer(object sender, ArrowPressedEventArgs args)
        {
            var nextCoord = _currentCoordinates + args.Coordinates;

            if (_map[nextCoord] == FieldTypes.FreeSpace)
            {
                _map[_currentCoordinates] = FieldTypes.FreeSpace;
                _map[nextCoord] = FieldTypes.Player;
                _currentCoordinates = nextCoord;
                SuccessfulMovement(this, EventArgs.Empty);
            }

            if (_map[nextCoord] == FieldTypes.Destination)
            {
                DestinationReached(this, EventArgs.Empty);
            }
        }
    }
}