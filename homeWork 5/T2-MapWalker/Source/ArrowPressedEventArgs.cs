namespace Source
{
    using System;

    /// <summary>
    /// Параметр события <see cref="EventLoop.ArrowPressed"/>
    /// </summary>
    public class ArrowPressedEventArgs : EventArgs
    {
        public Coordinates Coordinates { get; }

        public ArrowPressedEventArgs(Coordinates coords)
        {
            Coordinates = coords;
        }

        public static ArrowPressedEventArgs Left { get; } = new ArrowPressedEventArgs(new Coordinates(0, -1));
        public static ArrowPressedEventArgs Right { get; } = new ArrowPressedEventArgs(new Coordinates(0, 1));
        public static ArrowPressedEventArgs Up { get; } = new ArrowPressedEventArgs(new Coordinates(-1, 0));
        public static ArrowPressedEventArgs Down { get; } = new ArrowPressedEventArgs(new Coordinates(1, 0));
    }
}