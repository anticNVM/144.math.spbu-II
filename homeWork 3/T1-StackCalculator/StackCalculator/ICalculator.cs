namespace StackCalculator
{
    /// <summary>
    /// Реализует функциональность калькулятора для данного выражения.
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Вычисляет результат арифметического выражения
        /// </summary>
        /// <param name="expression">Вычисляемое арифметическое выражение.</param>
        /// <returns>Целочистенный результат выражения или .null, если выражение некорректно.</returns>
        int? Calculate(string expression);
    }
}