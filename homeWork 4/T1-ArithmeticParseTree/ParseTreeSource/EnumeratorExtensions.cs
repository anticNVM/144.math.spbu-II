namespace ParseTreeSource
{   
    using System.Collections.Generic;

    /// <summary>
    /// Расширение методов класса <see cref="IEnumerator">
    /// </summary>
    public static class EnumeratorExtensions
    {
        /// <summary>
        /// Возвращает следующий элемент коллекции
        /// </summary>
        /// <param name="iter">Итератор по текущей коллекции</param>
        /// <returns>Элемент коллекции</returns>
        public static string GetNext(this IEnumerator<string> iter)
        {
            return iter.MoveNext() ? iter.Current : null;
        }
    }
}