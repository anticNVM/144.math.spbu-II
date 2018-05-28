namespace Source
{
    using System;
    using System.IO;
    using System.Text;

    public class Map : IMap
    {
        /// <summary>
        /// Параметры карты
        /// </summary>
        private MapConfig _params;

        /// <summary>
        /// Игровое поле
        /// </summary>
        private FieldTypes[,] _board;

        /// <summary>
        /// Создает карту и определяет начальные координаты игрока
        /// </summary>
        /// <param name="config">Настройки карты</param>
        /// <param name="inputStream">Поток символов, для построения карты</param>
        /// <param name="initPlayerCoords">Начальные координаты игрока</param>
        public Map(MapConfig config, StreamReader inputStream, out Coordinates initPlayerCoords)
        {
            ConfigureMap(config);
            BuildMap(inputStream, out initPlayerCoords);
        }

        /// <summary>
        /// Параметры карты
        /// </summary>
        public MapConfig Params => _params;

        public FieldTypes this[Coordinates coords]
        {
            get
            {
                if (coords.X < 0 || coords.Y < 0)
                {
                    return FieldTypes.BeyondMap;
                }

                return _board[coords.X, coords.Y];
            }

            set
            {
                if (coords.X < 0 || coords.Y < 0)
                {
                    throw new IndexOutOfRangeException("Координаты не могут быть отрицательны");
                }

                _board[coords.X, coords.Y] = value;
            }
        }

        private void ConfigureMap(MapConfig config) => _params = config;

        private void BuildMap(StreamReader inputStream, out Coordinates initPlayerCoords)
        {
            _board = new FieldTypes[_params.MapSize["height"], _params.MapSize["width"]];

            bool avatarIsExist = false;
            bool destinationIsExist = false;
            initPlayerCoords = null;

            for (int i = 0; i < _params.MapSize["height"]; i++)
            {
                for (int j = 0; j < _params.MapSize["width"]; j++)
                {
                    var currentField = inputStream.Read();

                    if (currentField == _params.Keywords["wall"])
                    {
                        _board[i, j] = FieldTypes.TheWall;
                    }
                    else if (currentField == _params.Keywords["freespace"])
                    {
                        _board[i, j] = FieldTypes.FreeSpace;
                    }
                    else if (currentField == _params.Keywords["playerAvatar"])
                    {
                        if (avatarIsExist)
                        {
                            throw new InvalidNumberOfAvatarsException("Возможен лишь 1 аватар на поле");
                        }

                        _board[i, j] = FieldTypes.Player;
                        avatarIsExist = true;
                        initPlayerCoords = new Coordinates(i, j);
                    }
                    else if (currentField == _params.Keywords["destination"])
                    {
                        _board[i, j] = FieldTypes.Destination;
                        destinationIsExist = true;
                    }
                    else
                    {
                        throw new UnsupportedSymbolException(
                            "Поле содержит неподдерживаемые символы. " +
                            "Проверьте используемое поле в соответствии с файлом конфигурации");
                    }
                }

                inputStream.ReadLine();
            }

            if (!destinationIsExist)
            {
                throw new InvalidNumberOfDestinationsException(
                    "Необходим хотя бы 1 пункт назначения на поле");
            }

            if (!avatarIsExist)
            {
                throw new InvalidNumberOfDestinationsException(
                    "Единственный аватар обязан присутствовать на поле");
            }
        }

        public override string ToString()
        {
            var board = new StringBuilder(
                (_params.MapSize["height"] + 1) * _params.MapSize["width"]
            );

            for (int i = 0; i < _params.MapSize["height"]; i++)
            {
                for (int j = 0; j < _params.MapSize["width"]; j++)
                {
                    switch (_board[i, j])
                    {
                        case FieldTypes.TheWall:
                            board.Append(_params.Keywords["wall"]);
                            break;
                        case FieldTypes.FreeSpace:
                            board.Append(_params.Keywords["freespace"]);
                            break;
                        case FieldTypes.Player:
                            board.Append(_params.Keywords["playerAvatar"]);
                            break;
                        case FieldTypes.Destination:
                            board.Append(_params.Keywords["destination"]);
                            break;
                        default:
                            break;
                    }
                }

                board.AppendLine();
            }

            return board.ToString();
        }
    }
}