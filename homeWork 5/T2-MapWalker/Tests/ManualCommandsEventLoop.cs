namespace Tests
{
    using Source;
    using System;
    using System.Collections.Generic;

    public class ManualCommandsEventLoop : IMotionEventLoop
    {
        public event EventHandler<MotionVectorEventArgs> Motion;
        protected virtual void OnManualCommand(MotionVectorEventArgs args) => Motion?.Invoke(this, args);    
        private IEnumerable<char> _sequence;
        private Dictionary<char, MotionVectorEventArgs> _commands = new Dictionary<char, MotionVectorEventArgs> {
            ['w'] = MotionVectorEventArgs.Up,
            ['a'] = MotionVectorEventArgs.Left,
            ['s'] = MotionVectorEventArgs.Down,
            ['d'] = MotionVectorEventArgs.Right
        };
        private bool _exit = false;

        public ManualCommandsEventLoop(IEnumerable<char> sequence) => _sequence = sequence;

        public void Exit() => _exit = true;

        public void Run()
        {
            foreach (var command in _sequence)
            {
                if (_exit) break;
                OnManualCommand(_commands[command]);
            }
        }
    }
}