using System;

namespace HeapSortBuild
{
    public static class HeapSort
    {
        /// <summary>
        /// Сортирует массив целых чисел по возрастанию
        /// </summary>
        /// <param name="array">Сортируемый массив</param>
        public static void Sort(int[] array)
        {
            // создание кучи
            MakeHeap(array);

            // сам процесс сортировки
            int tail = array.Length - 1;
            while (tail > 0)
            {
                Swap(ref array[0], ref array[tail]);
                tail--;
                SiftDown(array, 0, tail);
            }
        }

        /// <summary>
        /// Формирует кучу из массива
        /// </summary>
        /// <param name="array">Массив для формирования кучи</param>
        private static void MakeHeap(int[] array)
        {
            // просеиваем всех родителей сквозь кучу
            for (int i = array.Length / 2; i >= 0; --i)
            {
                SiftDown(array, i, array.Length);
            }
            // в итоге построили кучу
        }

        /// <summary>
        /// Просеить элемент в основание кучи
        /// </summary>
        /// <param name="array">Массив для просеивания</param>
        /// <param name="index">Просеиваемый индекс</param>
        /// <param name="tail">Индекс, начиная с которого массив отсортирован</param>
        private static void SiftDown(int[] array, int index, int tail)
        {
            // пока по крайней мере левый сын входит в кучу [0, tailIndex)
            while (2 * index + 1 < tail)
            {
                // индекс максимального по значеню сына элемента с индексом index
                int maxSonIndex = 0;
                // если только 1 сын
                if (2 * index + 2 >= tail)
                {
                    maxSonIndex = 2 * index + 1;
                }
                else
                {
                    int maxSonValue = Math.Max(array[2 * index + 1], array[2 * index + 2]);
                    maxSonIndex = (array[2 * index + 1] == maxSonValue) ? (2 * index + 1) : (2 * index + 2);
                }

                // меняет отца с сыном -> формирует подкучу
                if (array[index] < array[maxSonIndex])
                {
                    Swap(ref array[index], ref array[maxSonIndex]);
                    index = maxSonIndex;
                }
                else
                {
                    // без break вроде зацикливание при формировании, но это не точно)
                    break;
                }
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }
    }
}
