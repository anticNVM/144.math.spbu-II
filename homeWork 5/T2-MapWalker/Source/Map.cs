namespace Source
{
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    public class Map : IMap
    {
        private MapConfig _params;
        private FieldTypes[,] _board;

        public MapConfig Params => _params;

        public FieldTypes this[Coordinates coords]
        {
            get => _board[coords.X, coords.Y];
            set => _board[coords.X, coords.Y] = value;
        }

        public Map(MapConfig config, StreamReader inputStream, out Coordinates initPlayerCoords)
        {
            ConfigureMap(config);
            BuildMap(inputStream, out initPlayerCoords);
        }

        private void ConfigureMap(MapConfig config) => _params = config;

        private void BuildMap(StreamReader inputStream, out Coordinates initPlayerCoords)
        {
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
                    else if (currentField == _params.Keywords["destnation"])
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

        public FieldTypes GetFieldTypeOn(Coordinates coordinates)
        {
            var x = coordinates.X;
            var y = coordinates.Y;

            if (x >= _params.MapSize["width"] || x < 0 ||
                y >= _params.MapSize["height"] || y < 0)
            {
                return FieldTypes.BeyondMap;
            }

            return _board[x, y];
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
                            board.Append(_params.Keywords["playersAvatar"]);
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