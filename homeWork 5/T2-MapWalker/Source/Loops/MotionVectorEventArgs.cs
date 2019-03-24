namespace Source
{
    using System;

    /// <summary>
    /// Аргументы события <see cref="MotionEventLoop.Motion"/>
    /// (представляет собой вектор перемещения)
    /// </summary>
    public class MotionVectorEventArgs : EventArgs
    {
        public Coordinates Coordinates { get; }

        public MotionVectorEventArgs(Coordinates coords)
        {
            Coordinates = coords;
        }

        public static MotionVectorEventArgs Left { get; } = new MotionVectorEventArgs(new Coordinates(0, -1));
        public static MotionVectorEventArgs Right { get; } = new MotionVectorEventArgs(new Coordinates(0, 1));
        public static MotionVectorEventArgs Up { get; } = new MotionVectorEventArgs(new Coordinates(-1, 0));
        public static MotionVectorEventArgs Down { get; } = new MotionVectorEventArgs(new Coordinates(1, 0));
    }
}