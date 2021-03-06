﻿using System;
using System.Collections.Generic;

namespace FuncsLib
{
    /// <summary>
    /// Класс, реализующий Map, Filter, Fold
    /// </summary>
    public static class Funcs
    {
        /// <summary>
        /// Возвращает список, полученный применением переданной функции
        /// к каждому элементу переданного списка.
        /// </summary>
        /// <param name="list">Список</param>
        /// <param name="function">Функция, по которой строится новый список</param>
        /// <typeparam name="TIn">Тип входного значения</typeparam>
        /// <typeparam name="TOut">Тип выходного значения</typeparam>
        /// <returns>Полученный список</returns>
        public static List<TOut> Map<TIn, TOut>(List<TIn> list, Func<TIn, TOut> function)
        {
            var newList = new List<TOut>();
            foreach (var element in list)
            {
                newList.Add(function(element));
            }

            return newList;
        }

        /// <summary>
        /// Возвращается список, составленный из тех элементов переданного списка,
        /// для которых переданная функция вернула true.
        /// </summary>
        /// <param name="list">Список</param>
        /// <param name="function">Функция-фильтр</param>
        /// <typeparam name="T">Тип значений списка</typeparam>
        /// <returns>Фильтрованный список</returns>
        public static List<T> Filter<T>(List<T> list, Predicate<T> predicate)
        {
            var newList = new List<T>();
            foreach (var element in list)
            {
                if (predicate(element))
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
        /// <param name="function">
        /// Берёт текущее накопленное значение и текущий элемент списка,
        /// и возвращает следующее накопленное значение
        /// </param>
        /// <typeparam name="TIn">Тип входного значения</typeparam>
        /// <typeparam name="TOut">Тип выходного значения</typeparam>
        /// <returns>Накопленное значение</returns>
        public static TOut Fold<TIn, TOut>(List<TIn> list, TOut initValue, Func<TOut, TIn, TOut> function)
        {
            TOut accumulator = initValue;
            foreach (var element in list)
            {
                accumulator = function(accumulator, element);
            }

            return accumulator;
        }
    }
}
