namespace Source
{
    using System.IO;

    public class Map : IMap
    {
        private MapConfig _params;
        private FieldTypes[,] _map;

        public MapConfig Params => _params;

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
                        _map[i, j] = FieldTypes.TheWall;
                    }
                    else if (currentField == _params.Keywords["freespace"])
                    {
                        _map[i, j] = FieldTypes.FreeSpace;
                    }
                    else if (currentField == _params.Keywords["playerAvatar"])
                    {
                        if (avatarIsExist)
                        {
                            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                            throw new System.Exception();
                        }

                        _map[i, j] = FieldTypes.Player;
                        avatarIsExist = true;
                        initPlayerCoords = new Coordinates(i, j);  // поработать над координатами
                    }
                    else if (currentField == _params.Keywords["destnation"])
                    {
                        _map[i, j] = FieldTypes.Destination;
                        destinationIsExist = true;
                    }
                    else 
                    {
                        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        throw new System.Exception();
                    }
                }

                inputStream.ReadLine();
            }

            if (!destinationIsExist || !avatarIsExist)
            {
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                throw new System.Exception();
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

            return _map[x, y];
        }
    }
}