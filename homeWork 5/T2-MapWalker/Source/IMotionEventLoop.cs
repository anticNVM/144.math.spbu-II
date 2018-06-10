namespace Source
{
    using System;

    public interface IMotionEventLoop
    {
        event EventHandler<MotionVectorEventArgs> Motion;

        void Run();

        void Exit();
    }
}