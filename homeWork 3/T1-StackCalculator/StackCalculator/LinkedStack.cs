namespace StackCalculator
{
    public class LinkedStack : IStack
    {
        private class StackElement
        {
            public int Value { get; }
            public StackElement Next { get; }

            public StackElement(int value, StackElement next)
            {
                Value = value;
                Next = next;
            }
        }

        public int Count { get; private set; }
        private StackElement head;

        public LinkedStack()
        {
            Count = 0;
            head = null;
        }

        public void Push(int value)
        {
            head = new StackElement(value, head);
            Count++;
        }

        public int? Pop()
        {
            if (this.IsEmpty())
            {
                return null;
            }
            
            var tempValue = head.Value;
            head = head.Next;
            Count--;
            return tempValue;
        }

        public int? Peek()
        {
            if (this.IsEmpty())
            {
                return null;
            }
            
            return head.Value;
        }

        public void Clear()
        {
            while (Count > 0)
            {
                this.Pop();
            }
        }

        public bool IsEmpty() => head == null;
    }
}