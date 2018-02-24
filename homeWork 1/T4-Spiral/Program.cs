using System;

namespace T4_Spiral
{
    class Program
    {
        // Дан массив размерностью N x N, N - нечетное число.
        // Вывести элементы массива при обходе его по спирали, начиная с центра.
        static void Main(string[] args)
        {
            var matrix = ReadMatrix();
            var spiral = SpitalTour(matrix);
            Console.WriteLine("Элементы матрицы {0}x{0} при обходе её по спирали: ", matrix.GetLength(0));
            PrintArray(spiral);
        }

        public static int[] SpitalTour(int[,] matrix)
        {
            int[] way = new int[matrix.Length];
            int half = matrix.GetLength(0) / 2;

            int lineCoord = half;
            int columnCoord = half;

            way[0] = matrix[lineCoord, columnCoord];
            int k = 1;
            for (var i = 1; i <= half; ++i)
            {
                Moves.Left(ref lineCoord, ref columnCoord);
                way[k++] = matrix[lineCoord, columnCoord];

                for (var j = 0; j < (i * 2 - 1); ++j)
                {
                    Moves.Up(ref lineCoord, ref columnCoord);
                    way[k++] = matrix[lineCoord, columnCoord];
                }
                for (var j = 0; j < (i * 2); ++j)
                {
                    Moves.Right(ref lineCoord, ref columnCoord);
                    way[k++] = matrix[lineCoord, columnCoord];
                }
                for (var j = 0; j < (i * 2); ++j)
                {
                    Moves.Down(ref lineCoord, ref columnCoord);
                    way[k++] = matrix[lineCoord, columnCoord];
                }
                for (var j = 0; j < (i * 2); ++j)
                {
                    Moves.Left(ref lineCoord, ref columnCoord);
                    way[k++] = matrix[lineCoord, columnCoord];
                }
            }

            return way;
        }

        public static int[,] ReadMatrix()
        {
            Console.Write("Введите размерность матрица NxN (N - нечетное): ");
            int size = Convert.ToInt32(Console.ReadLine());
            while (size % 2 == 0)
            {
                Console.Write("Wrong Input. Введите нечетный размер N: ");
                size = Convert.ToInt32(Console.ReadLine());
            }

            int[,] matrix = new int[size, size];
            Console.WriteLine($"Заполните матрицу {size}x{size} числами: ");
            for (var i = 0; i < size; ++i)
            {
                var inputStr = Console.ReadLine();
                for (var j = 0; j < size; ++j)
                {
                    matrix[i, j] = Convert.ToInt32(inputStr.Split(' ')[j]);
                }
            }

            return matrix;
        }

        public static void PrintArray(int[] array)
        {
            foreach (var elem in array)
            {
                Console.Write($"{elem} ");
            }
            Console.WriteLine();
        }
    }

    public struct Moves
    {
        public static void Left(ref int lineCoord, ref int columnCoord) => columnCoord -= 1;
        public static void Right(ref int lineCoord, ref int columnCoord) => columnCoord += 1;
        public static void Up(ref int lineCoord, ref int columnCoord) => lineCoord -= 1;
        public static void Down(ref int lineCoord, ref int columnCoord) => lineCoord += 1;
    }
}
