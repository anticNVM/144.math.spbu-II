namespace Tests
{
    using Source;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Цикл генерирующий собите <see cref="Motion"/> на основе последовательности команд
    /// </summary>
    public class CommandsEventLoop : IMotionEventLoop
    {
        public event EventHandler<MotionVectorEventArgs> Motion;
        protected virtual void OnManualCommand(MotionVectorEventArgs args) => Motion?.Invoke(this, args);    
        /// <summary>
        /// Последовательность символьных команд
        /// </summary>
        private IEnumerable<char> _sequence;
        private Dictionary<char, MotionVectorEventArgs> _commands = new Dictionary<char, MotionVectorEventArgs> {
            ['w'] = MotionVectorEventArgs.Up,
            ['a'] = MotionVectorEventArgs.Left,
            ['s'] = MotionVectorEventArgs.Down,
            ['d'] = MotionVectorEventArgs.Right
        };
        private bool _exit = false;

        public CommandsEventLoop(IEnumerable<char> sequence) => _sequence = sequence;

        public void Run()
        {
            foreach (var command in _sequence)
            {
                if (_exit) break;
                OnManualCommand(_commands[command]);
            }
        }

        public void Exit() => _exit = true;        
    }
}