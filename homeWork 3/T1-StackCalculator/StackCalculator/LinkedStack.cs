using System;
using Exceptions;

namespace StackCalculator
{
    public class LinkedStack : IStack
    {
        public int Count { get; private set; }
        private StackElement head;

        public void Push(int value)
        {
            head = new StackElement(value, head);
            Count++;
        }

        public int Pop()
        {
            if (this.IsEmpty())
            {
                throw new EmptyStackException(
                    "Попытка доступа к элементам пустого стека"
                );
            }

            var tempValue = head.Value;
            head = head.Next;
            Count--;
            return tempValue;
        }

        public int Peek()
        {
            if (this.IsEmpty())
            {
                throw new EmptyStackException(
                    "Попытка доступа к элементам пустого стека"
                );
            }

            return head.Value;
        }

        public void Clear()
        {
            Count = 0;
            head = null;
        }

        public bool IsEmpty() => head == null;

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
    }
}