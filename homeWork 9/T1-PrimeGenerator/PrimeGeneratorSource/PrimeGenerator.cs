using System;
using System.Collections.Generic;

namespace PrimeGeneratorSource
{
    /// <summary>
    /// Класс, содержащий метод для генерации последовательности простых чисел
    /// </summary>
    public static class PrimeGenerator
    {
        /// <summary>
        /// Генерирует бесконечную последовательность простых чисел
        /// </summary>
        /// <returns>Итератор по последовательности простых чисел</returns>
        public static IEnumerable<int> Generate()
        {
            return Filter<int>(GenerateInts(), IsPrime);
        }

        /// <summary>
        /// Возвращает <see cref="IEnumerable"/> простых чисел размера <paramref name="amount"/>
        /// </summary>
        /// <param name="amount">Количество чисел, начиная с 2</param>
        /// <returns>Коллекция простых чисел</returns>
        public static IEnumerable<int> GenerateOf(int amount)
        {
            var list = new List<int>(amount);
            foreach (var prime in Generate())
            {
                list.Add(prime);
            }

            return list;
        }

        /// <summary>
        /// Генерирует бесконечную последовательность целых чисел
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<int> GenerateInts()
        {
            int current = 0;
            while (true)
            {
                yield return current++;
            }
        }

        /// <summary>
        /// Фильтрует коллекцию по данному предикату
        /// </summary>
        /// <param name="collection">Фильтруемая коллекция</param>
        /// <param name="predicate">Предикат, согласно которому будет производиться фильтрование</param>
        /// <returns>Фильтрованная коллекция</returns>
        private static IEnumerable<T> Filter<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Предикт, проверяющий число на простоту
        /// </summary>
        /// <param name="number">Проверяемое число</param>
        /// <returns>true если простое, else иначе</returns>
        private static bool IsPrime(int number)
        {
            if (number == 1)
            {
                return false;
            }

            var i = 2;
            while (i * i <= number)
            {
                if (number % i == 0)
                {
                    return false;
                }

                i++;
            }

            return true;
        }
    }
}
