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
        /// <exceptions cref="InvalidExpressionException">Бросается в случае некоректности expression</exception>
        /// <returns>Целочистенный результат выражения.`</returns>
        int Calculate(string expression);
    }
}