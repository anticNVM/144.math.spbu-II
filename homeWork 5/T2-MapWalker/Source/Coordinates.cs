namespace Source
{
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Coordinates Left { get; } = new Coordinates(0, -1);
        public static Coordinates Right { get; } = new Coordinates(0, 1);
        public static Coordinates Up { get; } = new Coordinates(-1, 0);
        public static Coordinates Down { get; } = new Coordinates(1, 0);

        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Coordinates operator +(Coordinates a, Coordinates b) => new Coordinates(a.X + b.X, a.Y + b.Y);
        public static Coordinates operator -(Coordinates a, Coordinates b) => new Coordinates(a.X - b.X, a.Y - b.Y);
    }
}