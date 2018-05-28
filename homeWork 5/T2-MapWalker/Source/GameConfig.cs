namespace Source
{
    /// <summary>
    /// Класс с настройками игры
    /// </summary>
    public class GameConfig
    {
        /// <summary>
        /// Настройки карты
        /// </summary>
        /// <returns></returns>
        public MapConfig MapConfig { get; set; }

        /// <summary>
        /// Путь до карты
        /// </summary>
        /// <returns></returns>
        public string pathToMap { get; set; }
    }
}