using System;
using System.Collections.Generic;

namespace FuncsLib
{
    /// <summary>
    /// Класс, реализующий Map, Filter, Fold
    /// </summary>
    public static class Funcs<T>
    {
        /// <summary>
        /// Возвращает список, полученный применением переданной функции к каждому элементу переданного списка.
        /// </summary>
        /// <param name="list">Список</param>
        /// <param name="function">Функция, по которой строится новый список</param>
        /// <returns>Полученный список</returns>
        public static List<T> Map(List<T> list, Func<T, T> function)
        {
            var newList = new List<T>();
            foreach (var element in list)
            {
                newList.Add(function(element));
            }

            return newList;
        }

        /// <summary>
        /// Возвращается список, составленный из тех элементов переданного списка, для которых переданная функция вернула true.
        /// </summary>
        /// <param name="list">Список</param>
        /// <param name="function">Функция-фильтр</param>
        /// <returns>Фильтрованный список</returns>
        public static List<T> Filter(List<T> list, Func<T, bool> function)
        {
            var newList = new List<T>();
            foreach (var element in list)
            {
                if (function(element))
                {
                    newList.Add(element);
                }
            }

            return newList;
        }

        /// <summary>
        /// Возвращает накопленное значение, получившееся после всего прохода списка.
        /// </summary>
        /// <param name="list">Список</param>
        /// <param name="initValue">Начальное значение аккумулятора</param>
        /// <param name="function">Берёт текущее накопленное значение и текущий элемент списка, и возвращает следующее накопленное значение</param>
        /// <returns>Накопленный элемент</returns>
        public static T Fold(List<T> list, T initValue, Func<T, T, T> function)
        {
            T accumulator = initValue;
            foreach (var element in list)
            {
                accumulator = function(accumulator, element);
            }

            return accumulator;
        }
    }
}
