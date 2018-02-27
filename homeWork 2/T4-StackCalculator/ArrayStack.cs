namespace T4_StackCalculator
{
    public class ArrayStack : IStack
    {
        private static readonly int defaultSize = 10;
        private int[] stack;
        private int positionAfterTop;
        private int capacity;
        public int Count
        {
            get => positionAfterTop;
        }

        public ArrayStack() : this(defaultSize)
        {
        }

        public ArrayStack(int size)
        {
            if (size <= 0)
            {
                size = defaultSize;
            }

            stack = new int[size];
            positionAfterTop = 0;
            capacity = size;
        }

        public void Push(int value)
        {
            stack[positionAfterTop] = value;
            positionAfterTop++;

            if (positionAfterTop >= capacity)
            {
                this.Resize();
            }
        }

        public int? Pop()
        {
            if (positionAfterTop == 0)
            {
                return null;
            }
            else
            {
                return stack[--positionAfterTop];
            }
        }

        public int? Peek()
        {
            if (positionAfterTop == 0)
            {
                return null;
            }
            else
            {
                return stack[positionAfterTop - 1];
            }
        }

        public void Clear()
        {
            positionAfterTop = 0;
        }

        public bool IsEmpty() => Count == 0;

        private void Resize()
        {
            int factor = 2;
            capacity *= factor;
            int[] newStack = new int[capacity];
            stack.CopyTo(newStack, 0);
            stack = newStack;
        }
    }
}