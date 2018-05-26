namespace Source
{
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Coordinates Left { get; private set; } = new Coordinates(-1, 0);
        public static Coordinates Right { get; private set; } = new Coordinates(1, 0);
        public static Coordinates Up { get; private set; } = new Coordinates(0, 1);
        public static Coordinates Down { get; private set; } = new Coordinates(0, -1);

        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Coordinates operator +(Coordinates a, (int, int) b) => new Coordinates(a.X + b.Item1, a.Y + b.Item2);
        public static Coordinates operator -(Coordinates a, (int, int) b) => new Coordinates(a.X - b.Item1, a.Y - b.Item2);
    }
}