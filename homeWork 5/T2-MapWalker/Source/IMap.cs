namespace Source
{
    /// <summary>
    /// Интерфейс для взаимодействия с картой
    /// </summary>
    public interface IMap
    {
        /// <summary>
        /// Параметры карты
        /// </summary>
        /// <returns></returns>
        MapConfig Params { get; }

        /// <summary>
        /// Значение поле по соответствующей координате
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        FieldTypes GetFieldTypeOn(Coordinates coordinates);
    }
}