namespace T1_Stack
{
    public class Stack : IStack
    {
        private class StackElement
        {
            public int Value {get;}
            public StackElement Next {get;}

            public StackElement()
            {
            }

            public StackElement(int value, StackElement next)
            {
                Value = value;
                Next = next;
            }
        }

        private static int count;
        private StackElement head;

        public Stack()
        {
            count = 0;
            head = null;
        }

        public void Push(int value)
        {
            head = new StackElement(value, head);
            count++;
        }

        public int Pop()
        {
            var tempValue = head.Value;
            head = head.Next;
            count--;
            return tempValue;
        }

        public int Peek()
        {
            return head.Value;
        }

        public void Clear()
        {
            while (count > 0)
            {
                this.Pop();
            }
        }
    }
}