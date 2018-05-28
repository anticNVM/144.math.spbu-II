namespace Source
{
    /// <summary>
    /// Интерфейс для взаимодействия с картой
    /// </summary>
    public interface IMap
    {
        FieldTypes this[Coordinates coords] { get; set; }

        /// <summary>
        /// Параметры карты
        /// </summary>
        /// <returns></returns>
        MapConfig Params { get; }
    }
}