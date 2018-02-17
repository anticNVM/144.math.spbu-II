using System;

namespace T5_ColumnsSorting
{
    // Отсортировать столбцы матрицы по первым элементам
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = ReadMatrix();
            SortMatrix(matrix);
            Console.WriteLine("Отсортированная матрица: ");
            PrintMatrix(matrix);
        }

        public static int[,] ReadMatrix()
        {
            int lines = 0;
            int columns = 0;
            Console.Write("Введите размерность матрица через пробел: ");
            var inputStr = Console.ReadLine();
            lines = Convert.ToInt32(inputStr.Split(' ')[0]);
            columns = Convert.ToInt32(inputStr.Split(' ')[1]);

            int[,] matrix = new int[lines, columns];
            Console.WriteLine($"Заполните матрицу {lines}x{columns} числами: ");
            for (var i = 0; i < lines; ++i)
            {
                inputStr = Console.ReadLine();
                for (var j = 0; j < columns; ++j)
                {
                    matrix[i, j] = Convert.ToInt32(inputStr.Split(' ')[j]);
                }
            }

            return matrix;
        }

        public static void SortMatrix(int[,] matrix)
        {
            for (var i = 1; i < matrix.GetLength(1); ++i)
            {
                var j = i - 1;
                while ((j >= 0) && (matrix[0, j] > matrix[0, j + 1]))
                {
                    SwapColumns(matrix, j, j + 1);
                    j--;
                }
            }
        }

        public static void SwapColumns(int[,] matrix, int firstColumnIndex, int secondColumnIndex)
        {
            for (var i = 0; i < matrix.GetLength(0); ++i)
            {
                var temp = matrix[i, firstColumnIndex];
                matrix[i, firstColumnIndex] = matrix[i, secondColumnIndex];
                matrix[i, secondColumnIndex] = temp;
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); ++i)
            {
                for (var j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write($"|{matrix[i, j], -2} ");
                }
                Console.WriteLine("|");
            }
        }
    }
}
