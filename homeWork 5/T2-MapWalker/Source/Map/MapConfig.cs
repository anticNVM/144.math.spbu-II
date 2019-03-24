namespace Source
{
    using System.Collections.Generic;

    /// <summary>
    /// Класс, содержащий информацию о карте
    /// </summary>
    public class MapConfig
    {
        /// <summary>
        /// Размеры карты
        /// </summary>
        /// <returns>
        /// "width" : ширина карты
        /// "height" : высота карты
        /// </returns>
        public IReadOnlyDictionary<string, int> MapSize { get; set; }

        /// <summary>
        /// Легенда карты
        /// </summary>
        /// <returns>
        /// "wall" : стены
        /// "freespace" : свободное пространство
        /// "playerAvatar" : иконка игрока
        /// "destination" : место назначения
        /// </returns>
        public IReadOnlyDictionary<string, char> Keywords { get; set; }
    }
}