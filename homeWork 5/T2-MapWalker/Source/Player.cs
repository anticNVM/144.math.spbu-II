namespace Source
{
    using System;

    public class Player
    {
        /// <summary>
        /// У игрока есть карты, что логично
        /// </summary>
        private IMap _map;

        /// <summary>
        /// Текущие координаты игрока на карте
        /// </summary>
        private Coordinates _currentCoordinates;

        /// <summary>
        /// Событие, возникающее при успешном перемещении игрока
        /// (т.е. только тогда, когда он перешел на соседнюю клетку)
        /// </summary>
        /// <returns></returns>
        public event EventHandler<EventArgs> SuccessfulMovement = (sender, args) => { };

        /// <summary>
        /// Событие, возникающее при достижении игроком точки назначения
        /// </summary>
        /// <returns></returns>
        public event EventHandler<EventArgs> DestinationReached = (sender, args) => { };

        public IMap Map { get => _map; }

        /// <summary>
        /// Создает нового игрока
        /// </summary>
        /// <param name="gameMap">Карта, по которой игрок может передвигаться</param>
        /// <param name="initialPlayerCoordinates">Начальные координаты игрока</param>
        public Player(IMap gameMap, Coordinates initialPlayerCoordinates)
        {
            // это по идее вообще не должно выполниться никогда, но на всякий случай
            if (initialPlayerCoordinates == null)
            {
                throw new Exception("ой ой ой");
            }

            _map = gameMap;
            _currentCoordinates = initialPlayerCoordinates;
        }

        /// <summary>
        /// Обработчик события <see cref="ArrowPressEventLoop.ArrowPressed"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args">Координаты вектора перемещения</param>
        public bool MoveOnVector(Coordinates vector)
        {
            var nextCoord = _currentCoordinates + vector;
            bool success = false;

            switch (_map[nextCoord])
            {
                case FieldTypes.FreeSpace:
                    _map[_currentCoordinates] = FieldTypes.FreeSpace;
                    _map[nextCoord] = FieldTypes.Player;
                    _currentCoordinates = nextCoord;
                    success = true;
                    SuccessfulMovement(this, EventArgs.Empty);
                    break;

                case FieldTypes.Destination:
                    DestinationReached(this, EventArgs.Empty);
                    break;

                default:
                    break;
            }

            return success;
        }
    }
}