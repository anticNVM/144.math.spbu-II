namespace Source
{
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Coordinates operator +(Coordinates a, Coordinates b) => new Coordinates(a.X + b.X, a.Y + b.Y);
        public static Coordinates operator -(Coordinates a, Coordinates b) => new Coordinates(a.X - b.X, a.Y - b.Y);
    }
}