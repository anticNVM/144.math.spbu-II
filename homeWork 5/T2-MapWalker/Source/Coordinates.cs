namespace Source
{
    /// <summary>
    /// Класс предстовляющий собой координату вектора на плоскости
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// Координата по оси Y
        /// </summary>
        /// <returns></returns>
        public int X { get; set; }

        /// <summary>
        /// Координата по оси Y
        /// </summary>
        /// <returns></returns>
        public int Y { get; set; }

        /// <summary>
        /// Создает новый вектор с соответствующими значениями координат по соответствующим осям
        /// </summary>
        /// <param name="x">Значение по оси X</param>
        /// <param name="y">Значение по оси Y</param>
        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Оператор сложения, который складывает значения векторов покоординатно
        /// </summary>
        /// <param name="a">Координаты вектора а</param>
        /// <param name="b">Координаты вектора b</param>
        /// <returns>Координаты результирующего вектора a + b</returns>
        public static Coordinates operator +(Coordinates a, Coordinates b) => 
            new Coordinates(a.X + b.X, a.Y + b.Y);
    }
}