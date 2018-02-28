namespace StackCalculator
{
    public class ArrayStack : IStack
    {
        private static readonly int _defaultSize = 10;
        private int _capacity;
        private int _positionAfterTop;
        private int[] _stack;

        public ArrayStack() : this(_defaultSize)
        {
        }

        public ArrayStack(int size)
        {
            if (size <= 0)
            {
                size = _defaultSize;
            }

            _stack = new int[size];
            _capacity = size;
            _positionAfterTop = 0;
        }

        public void Push(int value)
        {
            _stack[_positionAfterTop] = value;
            _positionAfterTop++;

            if (_positionAfterTop >= _capacity)
            {
                this.Resize();
            }
        }

        public int? Pop()
        {
            if (_positionAfterTop == 0)
            {
                return null;
            }
            else
            {
                return _stack[--_positionAfterTop];
            }
        }

        public int? Peek()
        {
            if (_positionAfterTop == 0)
            {
                return null;
            }
            else
            {
                return _stack[_positionAfterTop - 1];
            }
        }

        public void Clear() => _positionAfterTop = 0;

        public bool IsEmpty() => Count == 0;

        public int Count
        {
            get => _positionAfterTop;
        }

        private void Resize()
        {
            int factor = 2;
            _capacity *= factor;
            int[] newStack = new int[_capacity];
            _stack.CopyTo(newStack, 0);
            _stack = newStack;
        }
    }
}