using System;
using System.Collections.Generic;

namespace BubbleSortSource
{
    /// <summary>
    /// Статический класс, содежащий в себе обобщенный метод пузарьковой сортировки
    /// </summary>
    public static class BubbleSort
    {
        /// <summary>
        /// Обобщенный метод пузарьковой сортировки
        /// </summary>
        /// <param name="array">Массив объектов произвольного типа</param>
        /// <param name="comparer">Объект-компаратор, позволяющий их сравнивать</param>
        /// <returns>Массив, отсортированный в соответствии с порядком, заданным объектом-компаратором.</returns>
        public static T[] Sort<T>(T[] array, IComparer<T> comparer)
        {
            bool exit = false;
            while (!exit)
            {
                exit = true;
                for (int i = 1; i < array.Length; ++i)
                {
                    if (comparer.Compare(array[i], array[i - 1]) < 0)
                    {
                        Swap(ref array[i], ref array[i - 1]);
                        exit = false;
                    }
                }
            }

            return array;
        }

        private static void Swap<T>(ref T item1, ref T item2) => (item1, item2) = (item2, item1);
    }
}
