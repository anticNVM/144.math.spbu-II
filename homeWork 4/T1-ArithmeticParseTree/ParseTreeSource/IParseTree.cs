namespace ParseTreeSource
{
    /// <summary>
    /// Интерфейс, реализующий ф-ть дерева разбора арифметического выражения для целых чисел
    /// </summary>
    public interface IParseTree
    {
        /// <summary>
        /// Посчитать значение выражения, хранимого в дереве
        /// </summary>
        /// <returns>Значение арифметического выражения</returns>
        int Evaluate();
    }
}