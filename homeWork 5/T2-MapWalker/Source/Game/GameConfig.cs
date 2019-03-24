namespace Source
{
    using Newtonsoft.Json;

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
        public string PathToMap { get; set; }
    }
}